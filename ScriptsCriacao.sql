-- Criar Banco
CREATE DATABASE programacao_do_zero;

-- Usar o banco
USE programacao_do_zero

-- Criar tabela usuário
CREATE TABLE usuario (
	id int NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOTNULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

-- Criar tabela de endereço
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(200) NOT NULL,
	numero VARCHAR(20) NOT NULL,
	bairro VARCHAR(200) NOT NULL,
	complemento VARCHAR(200) NULL,
	cidade VARCHAR(200) NOT NULL,
	estado VARCHAR(2) NOT NULL,
	cep VARCHAR(9) NOT NULL,
	PRIMARY KEY (id)
	);

-- Alterar tabela Endereço
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- Adicionar chave estrangeira
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- Inserir Usuário
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha) VALUES ('Gustavo', 'Juvencio', '(11) 93008-2773', 'gustavo.desouza19@gmail.com', 'Masculino', '123')

INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha) VALUES ('Ana', 'Juvencio', '(11) 96169-3270', 'paulaapds.22@gmail.com', 'Feminino', '456')

-- Selecionar todos os Usuários
SELECT * FROM usuario;

-- Selecionar um usuário específico com Where
SELECT * FROM usuario WHERE email = 'gustavo.desouza19@gmail.com';

-- Alterar usuários
UPDATE usuario SET telefone = '11 94555-1805' where id = 1;

-- Excluir Usuàrio
DELETE FROM usuario WHERE id = 2;

INSERT INTO endereco (rua, numero, bairro, complemento, cidade, estado, cep, usuario_id) VALUES ('R. Indalécio Pereira da Silva', '199', 'Parque Vitória', 'Casa', 'Franco da Rocha', 'SP', '07855-020', '1');
INSERT INTO endereco (rua, numero, bairro, complemento, cidade, estado, cep, usuario_id) VALUES ('R. Oslo', '1091', 'Parque Vitória', 'Casa', 'Franco da Rocha', 'SP', '07855-340', '2');
