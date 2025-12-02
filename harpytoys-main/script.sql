CREATE DATABASE BD_HARPYTOYS;  

 

USE BD_HARPYTOYS; 

 

CREATE TABLE Administrador  

(  

Cod_Admin INT PRIMARY KEY,  

Email VARCHAR(100) NOT NULL,  

Senha VARCHAR(100) NOT NULL  

); 

 

CREATE TABLE Usuario (  

Cod_Usuario INT PRIMARY KEY,  

Email VARCHAR(100) NOT NULL,  

Senha VARCHAR(100) NOT NULL,  

Cod_Admin INT,  

FOREIGN KEY (Cod_Admin) REFERENCES Administrador(Cod_Admin)  

); 

 

CREATE TABLE Produto (  

ID_Produto INT PRIMARY KEY,  

Cod_Imagem VARCHAR(100),  

Cod_Barras VARCHAR(50),  

Descricao VARCHAR(255),  

Valor DECIMAL(10,2),  

Cod_Usuario INT,  

FOREIGN KEY (Cod_Usuario) REFERENCES Usuario(Cod_Usuario)  

); 

 

CREATE TABLE Cliente (  

Cod_Cliente INT PRIMARY KEY,  

Nome VARCHAR(100),  

CPF VARCHAR(20) NOT NULL,  

Senha VARCHAR(100) NOT NULL,  

CEP VARCHAR(15),  

Email VARCHAR(100) NOT NULL  

); 

 

CREATE TABLE Pedido (  

Cod_Pedido INT PRIMARY KEY,  

Cod_Cliente INT,  

Data_Pedido DATETIME,  

Status_Pedido VARCHAR(50),  

FOREIGN KEY (Cod_Cliente) REFERENCES Cliente(Cod_Cliente)  

); 

 

CREATE TABLE Item_Pedido (  

Cod_Item INT PRIMARY KEY,  

ID_Produto INT,  

Cod_Pedido INT,  

Quantidade INT,  

Valor_Unitario DECIMAL(10,2),  

FOREIGN KEY (ID_Produto) REFERENCES Produto(ID_Produto),  

FOREIGN KEY (Cod_Pedido) REFERENCES Pedido(Cod_Pedido)  

); 

 

CREATE TABLE Pagamento (  

ID_Pagamento INT PRIMARY KEY,  

Cod_Pedido INT,  

Valor_Total DECIMAL(10,2), 

Metodo VARCHAR(50), 

Data_Pagamento DATETIME,  

Situacao VARCHAR(50),  

FOREIGN KEY (Cod_Pedido) REFERENCES Pedido(Cod_Pedido)  

); 

 

CREATE TABLE Endereco_Entrega (  

ID_Endereco INT PRIMARY KEY,  

Cod_Pedido INT,  

Cidade VARCHAR(100),  

Estado VARCHAR(100),  

Bairro VARCHAR(100),  

Numero INT,  

Rua VARCHAR(100),  

CEP VARCHAR(20) NOT NULL,  

FOREIGN KEY (Cod_Pedido) REFERENCES Pedido(Cod_Pedido)  

); 

 

SELECT * FROM Administrador; 

SELECT * FROM Usuario; 

SELECT * FROM Produto; 

SELECT * FROM Cliente; 

SELECT * FROM Pedido; 

SELECT * FROM Item_Pedido; 

SELECT * FROM Pagamento; 

SELECT * FROM Endereco_Entrega; 