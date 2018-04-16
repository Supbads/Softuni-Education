CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] nvarchar(200) NOT NULL,
	Picture varbinary CHECK(DATALENGTH(Picture)<900*1024),
	Height Decimal(10,2),
	Weight Decimal(10,2),
	Gender varchar(1) NOT NULL Check(Gender ='m' OR Gender ='f'),
	Birthdate INT NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('NAPRAVO GI UBIVAM', NULL, 1.44, 48, 'f', 1956, 'NA GERITO'),
('Vankata',NULL, NULL,3.6, 'm', 32, 'captain'),
('Muckata',NULL, NULL,7.8, 'f', 14, 'Driver'),
('Trupkata',NULL, NULL,20.22, 'm', 15, 'Pilot'),
('GERITYNIKOL', 25348, NULL,NULL, 'f', 17, 'Peeshta')

----8th prob
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username nvarchar(30) UNIQUE,
	Password NVARCHAR(26),
	ProfilePicture varbinary CHECK(DATALENGTH(ProfilePicture)<900*1024),
	LastLoginTime date,
	IsDeleted nvarchar(5) NOT NULL CHECK(IsDeleted='true' or isDeleted='false') 
)

INSERT INTO Users (Username, Password, ProfilePicture,LastLoginTime, IsDeleted) VALUES
('Melik', 'Melik123456789', 36, Null, 'true'),
('Gosho', 'Gosho1234', 450,Null,'false'),
('Pesho', 'Pesho123', 21,Null,'true'),
('Vankata', 'Vankata123321',500,Null,'false'),
('Baba', 'Baba54212', 352,Null,'false')


--9 prob , almost
DECLARE @ConstraintName nvarchar(200)
SELECT @ConstraintName = Name FROM SYS.DEFAULT_CONSTRAINTS WHERE PARENT_OBJECT_ID = OBJECT_ID('Users') AND PARENT_COLUMN_ID = (SELECT column_id FROM sys.columns WHERE NAME = N'Id' AND object_id = OBJECT_ID(N'Users'))
IF @ConstraintName IS NOT NULL
EXEC('ALTER TABLE Users DROP CONSTRAINT ' + @ConstraintName)

ALTER TABLE Users ADD PrimaryKey AS CONCAT(Username ,' ', Id)

ALTER TABLE Users DROP CONSTRAINT PK__Users__3214EC07719B1CAD
USE Minions
ALTER TABLE Users DROP COLUMN Id

ALTER TABLE Users ADD CONSTRAINT pk_Concat PRIMARY KEY (PrimaryKey)

Select * FROM Users

GO
--10 prob Add Check Constraint
USE Minions
ALTER TABLE Users
ADD CONSTRAINT chk_PasswordLength CHECK ( LEN(Password) >= 5)

GO
--11 prob Set Default Value of a Field
DECLARE @ConstraintName nvarchar(200)
SELECT @ConstraintName = Name FROM SYS.DEFAULT_CONSTRAINTS WHERE PARENT_OBJECT_ID = OBJECT_ID('Users') AND PARENT_COLUMN_ID = (SELECT column_id FROM sys.columns WHERE NAME = N'LastLoginTime' AND object_id = OBJECT_ID(N'Users'))
IF @ConstraintName IS NOT NULL
EXEC('ALTER TABLE Users DROP CONSTRAINT ' + @ConstraintName)

ALTER TABLE Users
ADD CONSTRAINT ck_DefaultTime DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users (Username, Password, ProfilePicture,LastLoginTime, IsDeleted) VALUES
('Melik', 'Melik123456789', 36, Null, 'true')
SELECT * FROM Users


--13
GO
CREATE DATABASE Movies

USE Movies
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50),
	Notes NVARCHAR(100)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50),
	Notes NVARCHAR(100)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50),
	Notes NVARCHAR(100)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255),
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear date,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NVARCHAR(100)
)

INSERT INTO Directors VALUES
('Geco', NULL),
('Pisho', NULL),
('Marko', NULL),
('Haralampi', NULL),
('Evlogi', NULL)
 
INSERT INTO Genres VALUES
('Horror', NULL),
('Morror', NULL),
('Comedy', NULL),
('Drama', NULL),
('Fantasy', NULL)
 
INSERT INTO Categories VALUES
('1', NULL),
('12', NULL),
('42', NULL),
('1337', NULL),
('80085', NULL)
 
INSERT INTO Movies VALUES
('Hard Die', 1, NULL, 155, 1, 2, NULL, NULL),
('Suka Love', 2, NULL, NULL, 2, 2, 5, 'sbvnsanv a.svn .asflvn a;fnv. afnv. a,m'),
('Idi na Kino', 3, NULL, 390, 3, 2, 4, NULL),
('Nascar', 4, NULL, NULL, 2, 2, NULL, NULL),
('Anonimous', 5, NULL, NULL, 5, 2, NULL, 'mdlfkjvna.va h,as >KJ HG>AK HF.skdfhg> DKgjf.')

--prob 14 Car Rental db
--done

--todo backups

--prob 19 Basic Select All fields
USE SoftUni

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees


-- Prob 20 
SELECT * FROM Towns
ORDER BY Towns.Name ASC
SELECT * FROM Departments
ORDER BY Departments.Name ASC
SELECT * FROM Employees
ORDER BY Employees.Salary DESC

-- Prob 21
SELECT Name FROM Towns
ORDER BY Towns.Name ASC
SELECT Name FROM Departments
ORDER BY Departments.Name ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Employees.Salary DESC


--Prob 22
UPDATE Employees
SET Salary *= 1.1
SELECT Salary From Employees

Go
--Prob 23
UPDATE Payments
SET TaxRate *= 0.97
SELECT TaxRate FROM Payments