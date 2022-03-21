-- DDL

--Criando o banco
CREATE DATABASE GUFI_Senai;
GO--Pausa a leitura E executa o bloco de código Acima.

--Usando o banco
USE GUFI_Senai;
Go


--Criando Tabelas

CREATE TABLE TiposUsuario (
	IdTipoUsuario int Primary Key Identity --Chave Primária
	,tituloTipoUsuario VARCHAR(200) UNIQUE NOT NULL --Definindo como única e não nula
);
GO

CREATE TABLE Usuarios (
	IdUsuario Int PRIMARY KEY IDENTITY,
	IdTipoUsuario Int FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario),
	NomeUsuario VARCHAR(100) NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL --EMAIL é unico para cada Pessoa
	,Senha VARCHAR(220) NOT NULL
);
GO

CREATE TABLE Instituicoes (
 Idinstituicao INT PRIMARY KEY IDENTITY,
 NomeFantasia VARCHAR(200) UNIQUE NOT NULL,
 CNPJ Char(14) UNIQUE NOT NULL --Char permite apenas numeros
 ,Endereco VARCHAR(255) UNIQUE NOT NULL
);
GO

CREATE TABLE TiposEventos (
	IdTipoEvento INT PRIMARY KEY IDENTITY,
	tituloTipoEvento VARCHAR(255) UNIQUE NOT NULL,
);
GO

CREATE TABLE Eventos (
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoEvento INT FOREIGN KEY REFERENCES TiposEventos(IdTipoEvento),
	Idinstituicao INT FOREIGN KEY REFERENCES Instituicoes(Idinstituicao),
	nomeEvento VARCHAR(225) NOT NULL,
	acessoLivre BIT DEFAULT (1),--bit armazena valores de sim ou não como o boolean
	DataEvento DATE NOT NULL,
	Descricao VARCHAR (250)
);
GO

CREATE TABLE Presencas (
	IdPresenca INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
	IdEvento INT FOREIGN KEY REFERENCES Eventos(IdEvento),
	situacao VARCHAR(100) NOT NULL
);
GO
