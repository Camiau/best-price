-- Create a new database called 'mejorprecio6'
-- Connect to the 'master' database to run this snippet
USE mejorprecio6
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
    idRol INT,
    emailIsConfirmed BIT DEFAULT 0 NOT NULL,
    active BIT DEFAULT 1 NOT NULL
    -- specify more columns here
);
GO
/*ALTER TABLE users
ADD emailIsConfirmed BIT DEFAULT 0 NOT NULL,
 active BIT DEFAULT 1 NOT NULL
GO*/
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
    descriptionProuct text,
    active BIT DEFAULT 1 NOT NULL
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
    price money NOT NULL,
    idProduct INT NOT NULL,
    idUser INT NOT NULL,
    latitude FLOAT DEFAULT 0.0000000000000 NOT NULL ,
    longitude FLOAT DEFAULT 0.0000000000000 NOT NULL,
    dateOfUpload DATETIMEOFFSET,
    descriptionProuct text,
    active BIT DEFAULT 1 NOT NULL
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
    idSearch INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    active BIT DEFAULT 1 NOT NULL
    -- specify more columns here
);
GO
IF OBJECT_ID('dbo.stores', 'U') IS NOT NULL
DROP TABLE dbo.stores
GO

-- Create the table in the specified schema
CREATE TABLE dbo.stores
(
    idStore INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    -- primary key column
    nameStore [VARCHAR](50) NOT NULL,
    descriptionStore[VARCHAR](50),
    imagePath[VARCHAR](50),
    latitude FLOAT DEFAULT 0.0000000000000 NOT NULL ,
    longitude FLOAT DEFAULT 0.0000000000000 NOT NULL,
    active BIT DEFAULT 1 NOT NULL

    -- specify more columns here
);
GO
-- Insert rows into table 'users'
INSERT INTO users
    ([nameUser],[lastName],[dni],[mail],[idRol])
VALUES
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1),
    ( 'gasti', 'H', 39244338, 'asdkddskds@adskjds.com', 1)
    
GO
INSERT INTO products
    ([codeBar],[descriptionProuct])
VALUES
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba'),
    ( '0123456789012', 'ashdhbakdakjbbksakbdasbdbbasbasbbadbahasasba')
    
GO
INSERT INTO users
    (nameUser,lastName,dni,mail,imagePath,idRol)
VALUES('fer', 'G', 38324779, 'fer@123.com', '', 1) 
GO
SELECT TOP 15
    *
FROM prices
WHERE idProduct=1
ORDER BY price ASC 
GO
INSERT INTO prices
    (price,latitude,longitude,idProduct,idUser,dateOfUpload)
VALUES
    (19, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (2, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (19, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (7, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (14, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (22, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (8, -34.706911, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9, -34.706921, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (29, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9.44, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9, -34.706901, -58.436451, 1, 1, '1/1/0001 12:00:00 AM'),
    (11.43, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (6, -34.706901, -58.436341, 1, 1, '1/1/0001 12:00:00 AM'),
    (7, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (4.9999, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (22, -34.706981, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM'),
    (9, -34.706901, -58.436441, 1, 1, '1/1/0001 12:00:00 AM') 
GO
SELECT *
FROM users
WHERE users.mail='asdkddskds@adskjds.com' AND users.dni=39244338
GO