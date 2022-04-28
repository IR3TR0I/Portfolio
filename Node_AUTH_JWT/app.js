require('dotenv').config()
const express = require('express')
const mongoose = require('mongoose')
const bcrypt = require('bcrypt')
const jwt = require('jsonwebtoken')


const Usuario = require('./models/Usuario')
const res = require('express/lib/response')

const app = express()

//lendo JSON

app.use(express.json())

//abrindo rota
app.get('/', (req,res) => {
    res.status(200).json({msg : "API Positiva e Operante :)"})
})


//Credenciais
const DBUsuario = process.env.DB_USUARIO
const DBPassword = process.env.DB_PASSWORD

//Rota Privada
app.get('/user/:id', checaToken,async(req,res)=> {
    const id = req.params.id

    //consultando se existe no banco
    //-senha filtro utilizado para esconder a senha no retorno da requisição
    const user = await Usuario.findById(id,'-senha')

    if (!user) {
        return res.status(404).json({msg: 'Usuário não encontrado'})
    }

    //retorna usuário caso encontrado
    res.status(200).json({user})
})

//função que checa o token

function checaToken(req,res,next) {

    const authHeader = req.headers['authorization']
    const token = authHeader && authHeader.split(' ')[1]

    if (!token) {
        return res.status(401).json({msg: 'Acesso negado!'})
    }

    //validando 
    try {
        const secret = process.env.SECRET

        jwt.verify(token, secret)

        next()
    } catch (error) {
        res.status(400).json({msg: "TOKEN INVÁLIDO!"})
    }
}

//Registrando primeiro usuario
app.post('/auth/cadastro', async(req,res) => {
    const { nome, email, senha, confirmarSenha} = req.body

    //validções
    if (!nome) {
      return res.status(422).json({msg: 'Nome é obrigatório'})
    }
    if (!email) {
        return res.status(422).json({msg: 'Email é obrigatório'})
    }
    if (!senha) {
        return res.status(422).json({msg: 'Senha é obrigatória'})
    }
    
    if (senha !== confirmarSenha) {
        return res.status(422).json({msg: 'As Senhas não são Iguais!'})
       
    }

    //verificando se usuario existe 

    const usuarioExiste = await Usuario.findOne({ email: email });

    if (usuarioExiste) {
        return res.status(422).json({msg:'Este email já esta sendo utilizado!'})
    }

    //criando senha 

    const salt = await bcrypt.genSalt(12)
    const senhaHash = await bcrypt.hash(senha,salt)

    //criando usuario

    const usuario = new Usuario({
        nome,
        email,
        senha: senhaHash,
    })

    try {
        await usuario.save()

        res.status(201).json({msg: 'Usuário criado com sucesso'})
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: 'Erro de Servidor, tente novamente depois!'})
    }
})

//login

app.post('/auth/LoginUser', async (req, res) => {
    const {email,senha} = req.body

    if (!email) {
        return res.status(422).json({msg: 'Email é obrigatório'})
    }
    if (!senha) {
        return res.status(422).json({msg: 'Senha é obrigatória'})
    }

    //validando se o usuario está logado
    const usuarioLogado = await Usuario.findOne({email:email})

    if (!usuarioLogado) {
        return res.status(404).json({msg:'Usuário não Encontrado!'})
    }

    //validando senha 
    const checkPassword = await bcrypt.compare(senha, usuarioLogado.senha)

    if (!checkPassword) {
        return res.status(422).json({msg: 'Senha Inválida' })
    }

    //autenticação
    try {
        
        const secret= process.env.SECRET

        const token = jwt.sign(
            {
                id: usuarioLogado._id,
            },
            secret,
        )

        res.status(200).json({msg : "Autenticação feita", token})

    } catch (err) {
        console.log(error)
        res.status(500).json({msg: 'Erro de Servidor, tente novamente depois!'})
    }
})



//Comunicando com o BD
mongoose.connect(
    `mongodb+srv://${DBUsuario}:${DBPassword}@authcluster.oykhm.mongodb.net/BancoNodeAuth?retryWrites=true&w=majority`
)    
.then(() => {
    console.log('Conectando ao banco!');
    app.listen(3000);
})
.catch((err)=> console.log(err));


//Ligando server
//app.listen(3000)