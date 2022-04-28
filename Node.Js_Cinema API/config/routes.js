//arquivo criado para organização de rotas e obrigações
const express = require('express')
const res = require('express/lib/response')
const routes = express.Router()

//criando banco local
// let BD = [
//     {"1":{Filme:'The Batman'  , Dublado , Sessao:'19:30'} },
//     {"2":{Filme:'Star Wars'   , Dublado , Sessao:'21:45' } },
//     {"3":{Filme:'Jogador Nº 2', Dublado ,Sessao:'22:15'} },
//     {"4":{Filme:'Spider-Man: Homies', Dublado , Sessao:'14:20'} },
//     {"5":{Filme:'Doutor Estranho 2', Dublado , Sessao:'16:40'} }
// ]

//Utilizando protocolos HTTP(GET POST PUT DELETE UPDATE/CRUD)
//rotas
// routes.get('/ListarTudo',(req, res) =>{
//     return res.json(BD)//retorna valor em json
// })

// //Cadastrar Filme
// routes.post('/AddnewMovie',(req, res) => {
//     const body = req.body

//     if (!body) {
//         return res.status(400).end()//retorna resposta status code 400-BAD REQUEST

//     }
//     BD.push(body)
//     return res.json(body)    
// })


// //Deletar Filme por numero id
// routes.delete('/DeletarFilmePorid',(req,ras) => {
//     const id = req.params.id

//     let novoBD = BD.filter(item => {
//         if (item[id]) {
//             return item
//         }
//     })
//     BD = novoBD
    
//     return res.send(novoBD)
// })

// routes.delete('/:DeletarFilmePornome',(req,ras) => {
//     const nome = req.params.nome

//     let novoBD = BD.filter(item => {
//         if (item[nome]) {
//             return item
//         }
//     })
//     BD = novoBD

//     return res.send(novoBD)
// })

// module.exports = routes //exportando o modulo de rotas