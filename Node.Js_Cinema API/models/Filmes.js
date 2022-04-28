const mongoose = require('mongoose')

const Movies = mongoose.model('Filme', {
    Nome: String,
    Genero: String,
    Descricao: String,
    HoraSessao: String

})