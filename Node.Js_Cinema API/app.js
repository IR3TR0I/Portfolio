require('dotenv').config()
const express = require('express')
const app = express()
const  jwt = require('jsonwebtoken')
const mongoose = require('mongoose')
const bcrypt = require('bcrypt')
const path = require('path')

//fazendo express ler json usando middlewares
app.use(express.urlencoded({
        extended:true,
    }),
)

const UsuarioRotas = require('./Routes/UsuarioRouter')

app.use('/Usuario', UsuarioRotas)

app.use(express.json())

app.get('/', async(req,res)=> {
    res.status(200).json({message: "API Positiva e Operante"})
})

//CRUD
app.post()









//Credentials
const DbUsuario = process.env.DB_USUARIO
const DbPass = encodeURIComponent(process.env.DB_SENHA)

//conectando ao BD
mongoose.connect(
    `mongodb+srv://${DbUsuario}:${DbPass}@cinemacluster.4vd76.mongodb.net/myFirstDatabase?retryWrites=true&w=majority`
)
.then(() => {
    console.log('Banco Conectado :)');
    app.listen(3000);
})
.catch((error)=> console.log(error));



// app.listen(process.env.port || 3000);


