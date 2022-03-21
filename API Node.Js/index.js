//Index direcionado a servidor
const express = require('express')
const morgan = require('morgan')
const cors = require('cors')
const bodyparser = require('body-parser')
const morgan = require('morgan')
const req = require('express/lib/request')
const routes = require('./config/routes.js')


const app = express()

app.use(morgan('dev'))
app.use(bodyparser.urlencoded({extends : false})) 
app.use(express.json())
app.use(cors())
app.use(routes)


//iniciando servidor local
app.listen(5000, () => {
    console.log('Express started at http://localhost:5000')
})