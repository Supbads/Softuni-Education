CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50),
	Age INT
)

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,	
)

--ALTER TABLE Minions
--ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

ALTER TABLE Minions
ADD TownId INT
ALTER TABLE Minions
ADD CONSTRAINT FK_Town FOREIGN KEY (TownId) -- makes TownId foreign key and references to Id column of towns table
REFERENCES Towns (Id)

INSERT INTO Towns ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna')

GO
INSERT INTO Minions ([Name], Age, TownID) VALUES
('Kevin' , 22, 1),
('Bob' , 15, 3),
('Steward', NULL, 2)

SELECT * FROM Minions
Select * from Towns

TRUNCATE TABLE Minions
DROP TABLE Minions
DROP TABLE Towns