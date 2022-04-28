const { Router } = require('express')
const { route } = require('express/lib/application')

const router = require('express').Router()

//Importanto modelo Pessoa
const Pessoa = require('../Models/Pessoa')

//Create/Criar
router.post('/', async(req,res) => {
    //função assincrona para respeitar tempo do BD

    //Cria tres variaveis a partir do body
    //Saida : {nome; salario: 5000, aproved: true} Destructur
    const {Nome,Salario,Aprovacao} = req.body

    //validando
    if (!Nome) {
        res.status(422).json({error: 'Nome é Obrigatório'})
        return//para a requisição e não executa nenhuma linha
        //422 erros de recurso não processado
    }
    
    //passando objetos para inserir no banco
    const pessoa = {
        Nome,
        Salario,
        Aprovacao,
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

//Read/Ler
router.get('/', async(req,res) => {
    try {
        const pessoal = await Pessoa.find()

        res.status(200).json(pessoal)
    } catch (error) {
        res.status(500).json({error: error})
    }
})
//Listar por ID do usuario
router.get('/:id', async(req,res) =>{
    //extrair dados da requisição = req.params
    const id = req.params.id

    try {
        //encontra apenas um unico resultado
        const pessoa = await Pessoa.findOne({ _id: id})

        if (!pessoa) {
            res.status(422).json({returnMessage:'Nenhum usuario com esse id foi encontrado!'})
            return
        }

        res.status(200).json(pessoa)
    } catch (error) {
        res.status(500).json({error:error})
    }
})
//deletar Por iD
router.delete('/:id', async(req,res) => {
    const id = req.params.id
    const pessoa = await Pessoa.findOneAndRemove({_id: id})
    //validando se usuario existe 
    if (!pessoa) {
        res.status(200).json({returnMessage: 'O Usuário Não Foi Encontrado!'})
        return
    }
    
})

//UPDATE/ATUALIZAR
router.patch('/:id', async (req,res)=> {
    const id = req.params.id

    const { Nome , Salario, Aprovacao} = req.body

    const Pessoa = {
        Nome,
        Salario,
        Aprovacao,
    }

    try {
        //envia como segundo argumento a atualização de Pessoa
        const pessoaAtualizada = await Pessoa.updateOne({_id : id}, Pessoa)

        res.status(200).json(Pessoa)

    } catch (error) {
        res.status(500).json({error : error})
    }
})


module.exports = router