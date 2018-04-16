--Problem 1 One to One Realtionship

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber NVARCHAR(50) NOT NULL
)

CREATE TABLE Persons(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(15,4),
	PassportID INT NOT NULL
)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons_PersonID PRIMARY KEY (PersonID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_PassportID FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)

-- Problem 2 One to Many Relationship

CREATE TABLE Models(
	ModelID INT NOT NULL,
	Name NVARCHAR(50),
	ManufacturerID INT
)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY,
	Name NVARCHAR(50),
	EstablishedOn DATE
)

INSERT INTO Manufacturers VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

INSERT INTO Models VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

ALTER TABLE Models
ADD CONSTRAINT PK_Models_ModelID PRIMARY KEY (ModelID)

ALTER TABLE Models
ADD CONSTRAINT FK_Models_ManufacturerID FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

-- Problem 3 Many to Many Relationship
CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	Name NVARCHAR(50)
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	Name NVARCHAR(255)
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
)

INSERT INTO Students VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)

-- Problem 4 Self-Referencing
CREATE TABLE Teachers(
	TeacherID INT IDENTITY(101,1),
	Name NVARCHAR(20),
	ManagerID INT,
	CONSTRAINT PK_Teachers_TeacherID PRIMARY KEY(TeacherID),
	CONSTRAINT FK_Teachers_TeacherID FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- Problem 5 Online Store DB
CREATE TABLE Cities(
  CityID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Customers(
  CustomerID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  Birthday DATE,
  CityID INT,
  CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
  OrderID INT PRIMARY KEY,
  CustomerID INT NOT NULL,
  CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
  ItemTypeID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Items(
  ItemID INT PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  ItemTypeID INT NOT NULL,
  CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
  OrderID INT NOT NULL,
  ItemID INT NOT NULL,
  CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
  CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

-- Problem 6 University Database
CREATE TABLE Majors(
  MajorID INT PRIMARY KEY,
  Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Students(
  StudentID INT PRIMARY KEY,
  StudentNumber INT NOT NULL UNIQUE,
  StudentName NVARCHAR(200) NOT NULL,
  MajorID INT,
  CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)


CREATE TABLE Payments(
  PaymentID INT PRIMARY KEY,
  PaymentDate DATE NOT NULL,
  PaymentAmount MONEY NOT NULL,
  StudentID INT NOT NULL,
  CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
  SubjectID INT PRIMARY KEY,
  SubjectName NVARCHAR(50) NOT NULL,
)

CREATE TABLE Agenda(
  StudentID INT NOT NULL,
  SubjectID INT NOT NULL,
  CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
  CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
  CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

-- Problem 9 Peaks in Rila
SELECT M.MountainRange, P.PeakName, P.Elevation FROM Mountains as M
JOIN Peaks AS P ON p.MountainId = M.Id
WHERE M.MountainRange = 'Rila'
ORDER BY Elevation DESC