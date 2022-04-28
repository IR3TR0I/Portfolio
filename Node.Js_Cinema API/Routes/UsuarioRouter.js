const router = require('express').Router()
const res = require('express/lib/response')
const Usuario = require('../models/Usuarios')
const bcrypt = require('bcrypt')


//Cadastro Usuario
router.post('/cadastro', async(req,res) => {
    const {Nome, Email, Idade, Senha, ConfirmarSenha } = req.body

    //Validando
    if (!Nome) {
        return res.status(422).json({message: 'O nome é Obrigatório!'})
    }
    if (!Email) {
        return res.status(422).json({message: 'O Email é Obrigatório!'})
    }
    if (!Idade) {
        return res.status(422).json({message: 'A Idade é Obrigatória!'})
    }
    if (!Senha) {
      return res.status(422).json({message: 'A senha é Obrigatória!'})
    }
    if (!Senha !== ConfirmarSenha) {
       return res.status(422).json({message: 'As Senhas não Coincidem!'})   
    }

    //verificando 
    const userExists = await Usuario.findOne({ Email : Email})

    if (userExists) {
        return res.status(422).json({message: 'Este email já esta sendo usado!'})
    }

    //Senha

    const salt = await bcrypt.gensalt(14)
    const PasswordHash = await bcrypt.hash(Senha,salt)

    //Creating Usuario

    const user = new Usuario({
        Nome,
        Email,
        Idade,
        Senha: PasswordHash,
    })

    try {
        await user.save()
        res.status(201).json({msg: 'User created with Success :)'})
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: 'SERVER ERROR!!!, TRY AGAIN LATER'})
    }
})

//LOGIN


router.post('/auth/UserLogin')




module.exports = router