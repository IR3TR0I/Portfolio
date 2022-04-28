const mongoose = require('mongoose')

const Pessoa = mongoose.model('Pessoa', {
    Nome: String,
    Salario:Number,
    Aprovacao: Boolean,
})


module.exports = Pessoa