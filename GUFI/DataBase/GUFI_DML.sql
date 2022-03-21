--DML

--Usando o banco
USE GUFI_Senai;
GO

Insert INTO TiposUsuario(tituloTipoUsuario)
VALUES					('Administrador'),
						('Comum');
GO

INSERT INTO Usuarios(IdTipoUsuario,NomeUsuario,Email,Senha)
VALUES				(1,'Admnistrador','adm@adm.com','adm123'),
					(2,'Ruan','ruan@email.com','ruan123'),
					(2,'Saulo','saulo@email.com','saulo123');
GO

INSERT INTO Instituicoes(CNPJ,NomeFantasia,Endereco)
VALUES					('89.034.820','Escola SENAI de Informática','Al. Barão de Limeira, 538'),
						('40.085.209','CyberDawn','Av.Paulista, 577'),
						('44.683.225','Senerth','Al. Marechal Santos,982');
GO

INSERT INTO TiposEventos(tituloTipoEvento)
VALUES					('C#'),
						('Python'),
						('NoSQL');
GO

INSERT INTO Eventos(IdTipoEvento,Idinstituicao,nomeEvento,acessoLivre,DataEvento,Descricao)
VALUES				(1, 2, 'S.O.L.I.D', 1, '09/05/2022', 'Introdução aos principios SOLID'),
					(2,2,'GIDEON',0,'23/05/2022','Apresentação Do Projeto GIDEON'),
					(3,3,'Introdução a NoSQL',1,'28/05/2022','Introdução a MongoDB');
GO

INSERT INTO Presencas(IdUsuario,IdEvento,situacao)
VALUES				 (2,1,'Não Confirmada'),
					 (2,2,'Confirmada');
GO
