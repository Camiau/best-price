-- Create a new database called 'mejorprecio6'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
FROM sys.databases
WHERE name = N'mejorprecio6'
)
CREATE DATABASE mejorprecio6
GO
-- Create a new table called 'users' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.users', 'U') IS NOT NULL
DROP TABLE dbo.users
GO
-- Create the table in the specified schema
CREATE TABLE dbo.users
(
    idUser INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    nameUser [VARCHAR](50) NOT NULL,
    lastName [VARCHAR](50) NOT NULL,
    dni [bigint],
    mail [VARCHAR](50),
    imagePath[VARCHAR](50),
    idRol INT
    -- specify more columns here
);
GO
-- Create a new table called 'roles' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.roles', 'U') IS NOT NULL
DROP TABLE dbo.roles
GO
-- Create the table in the specified schema
CREATE TABLE dbo.roles
(
    idRole INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    role [VARCHAR](50) NOT NULL,
    idUser INT
    -- specify more columns here
);
GO

-- Create a new table called 'products' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.products', 'U') IS NOT NULL
DROP TABLE dbo.products
GO
-- Create the table in the specified schema
CREATE TABLE dbo.products
(
    idProduct INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    codeBar [VARCHAR](50) NOT NULL,
    descriptionProuct text
    -- specify more columns here
);
GO

-- Create a new table called 'prices' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.prices', 'U') IS NOT NULL
DROP TABLE dbo.prices
GO
-- Create the table in the specified schema
CREATE TABLE dbo.prices
(
    idPrice INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    price money,
    descriptionProuct text,
    latitude DECIMAL,
    longitude DECIMAL,
    idProduct INT
    -- specify more columns here
);
GO
-- Create a new table called 'searches' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.searches', 'U') IS NOT NULL
DROP TABLE dbo.searches
GO
-- Create the table in the specified schema
CREATE TABLE dbo.searches
(
    idSearch INT NOT NULL IDENTITY(1,1) PRIMARY KEY
    -- primary key column
    -- specify more columns here
);
GO
-- Insert rows into table 'users'
INSERT INTO users
    ([nameUser],[lastName],[dni],[mail])
VALUES
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com'),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com'),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com'),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com'),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com'),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com')
    
GO
-- Query the total count of employees
SELECT COUNT(*) as users
FROM dbo.users;
-- Query all employee information
SELECT e.idUser, e.nameUser,e.lastName,e.dni,e.idRol,e.mail,e.imagePath
FROM dbo.users as e
GO