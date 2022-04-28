const mongoose = require('mongoose')

const Usuario = mongoose.model('User', {
    Nome: String,
    Email: String,
    Idade: Number,
    Senha: String,
})


module.exports = Usuario