-- DQL

--Usando o Banco

USE GUFI_Senai;
Go

-- Lista todos os tipos de usuários
SELECT * FROM TiposUsuario;

-- Lista todos os usuários
SELECT * FROM Usuarios;

-- Lista todas as instituições
SELECT * FROM Instituicoes;

-- Lista todos os tipos de eventos
SELECT * FROM TiposEventos;

-- Lista todos os eventos
SELECT * FROM Eventos;

-- Lista todas as presenças
SELECT * FROM Presencas;

--Seleciona os dados do usuario mostrando seu tipo
select IdUsuario, tituloTipoUsuario,nomeUsuario, Email FROM Usuarios
INNER JOIN TiposUsuario
ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario;

-- Seleciona os dados dos eventos, da instituição e dos tipos de eventos
SELECT NomeFantasia [Endereco], IdEventos, nomeEvento,
tituloTipoEvento tema, DataEvento
FROM Eventos E
INNER JOIN Instituicoes I
ON E.Idinstituicao = I.Idinstituicao
INNER JOIN TiposEventos TE
ON E.IdTipoEvento = TE.IdTipoEvento;

-- Seleciona os dados dos eventos, da instituição, dos tipos de eventos e dos usuários
SELECT NomeFantasia [Local], nomeUsuario, Email, nomeEvento,
tituloTipoEvento tema, DataEvento, situacao From Usuarios u
INNER JOIN Presencas P
ON U.IdUsuario = P.IdUsuario
INNER JOIN Eventos E
ON P.IdEvento = E.IdEventos
INNER JOIN TiposEventos TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicoes I
On E.Idinstituicao = I.Idinstituicao;

--Busca um Usuario atraves do seu email e senha
SELECT tituloTipoUsuario [Permissão], nomeUsuario,email FROM Usuarios u
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE Email = 'ruan@email.com' and Senha = 'ruan123';