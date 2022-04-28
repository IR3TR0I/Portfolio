const express = require('express')
const app = express()
const mongoose = require('mongoose')




//ler JSON / Middlewares
app.use(//criando middleware
    express.urlencoded({
        extended: true,
    }),
)

app.use(express.json())

//ROTAS
const PessoaRotas = require('./Routes/PessoaRotas')

app.use('/Pessoa', PessoaRotas)


app.post('/Pessoas', async(req,res) => {
    //função assincrona para respeitar tempo do BD

    //Cria tres variaveis a partir do body
    //Saida : {nome; salario: 5000, aproved: true} Destructur
    const {Nome,Salario,Aprovacao} = req.body

    //validando
    if (!Nome) {
        res.status(422).json({error: 'Nome é Obrigatório'})
        //422 erros de recurso não processado
    }
    
    //passando objetos para inserir no banco
    const pessoa = {
        Nome,
        Salario,
        Aprovacao
    }

    //Create Mongoose

    try {
        //Criando dados 
        //espera salvar
        await Pessoa.create(pessoa)
        //201 criado
        res.status(201).json({returnMessage: 'Pessoa Inserida com Sucesso'})

    } catch (error) {
        //500 Erro interno de Servidor
        res.status(500).json({error: error})
    }

})




//endPoint Inicial
app.get('/', (req,res) => {


    //mensagem
    res.json({returnMessage: "teste" })
})



//Entregar porta para acesso de app
const DB_USER = process.env.DB_USER
const DB_PASSWORD = encodeURIComponent(process.env.DB_PASSWORD)

mongoose.connect(//String de conexão 
    `mongodb+srv://${DB_USER}:${DB_PASSWORD}@apicluster.gpqte.mongodb.net/BancoAPI?retryWrites=true&w=majority`, 
)
.then(() => {
    console.log("Conectando Ao Mongo")
    app.listen(3000)
})
.catch((err) => console.log(err))
