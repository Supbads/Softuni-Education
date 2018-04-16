Use SoftUni
GO

-- problem 1
CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
SELECT E.FirstName, E.LastName FROM Employees AS E
WHERE E.Salary > 35000 

GO
-- problem 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@minSalary DECIMAL(18,4)) AS
SELECT E.FirstName, E.LastName FROM Employees AS E
WHERE E.Salary >= @minSalary 

GO
-- Problem 3
CREATE PROC usp_GetTownsStartingWith (@firstLetter NVARCHAR(50)) AS
SELECT T.Name FROM Towns AS T
WHERE T.Name LIKE @firstLetter + '%'

GO
--Problem 4
CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50)) AS
SELECT E.FirstName, E.LastName FROM Employees AS E
JOIN Addresses AS A ON E.AddressID = A.AddressID
JOIN Towns AS T ON A.TownID = T.TownID
WHERE T.Name = @townName

GO
-- Problem 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY) 
RETURNS NVARCHAR(10) AS
BEGIN
DECLARE @salaryLevel NVARCHAR(10)
	IF (@salary < 30000 )
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF (@salary > 50000)
	BEGIN
		SET @salaryLevel = 'High'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'Average'
	END
	
	RETURN @salaryLevel; 
END


GO
--problem 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10))
AS
SELECT FirstName, LastName FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel


EXEC dbo.usp_EmployeesBySalaryLevel 'High'

-- Problem 7
GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(max), @word VARCHAR(max))
RETURNS BIT
AS
BEGIN
  DECLARE @currentIndex INT = 1;
  DECLARE @currentChar CHAR;

  WHILE(@currentIndex <= LEN(@word))
  BEGIN

    SET @currentChar = SUBSTRING(@word, @currentIndex, 1);
    IF(CHARINDEX(@currentChar, @setOfLetters) = 0)
      RETURN 0;
    SET @currentIndex += 1;

  END

  RETURN 1;

END

GO
-- problem 8
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN 
(
	SELECT EmployeeID FROM Employees
	WHERE DepartmentID = @departmentId
)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN 
(
SELECT EmployeeID FROM Employees
WHERE DepartmentID = @departmentId
)


UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN 
(
SELECT EmployeeID FROM Employees
WHERE DepartmentID = @departmentId
)

DELETE FROM Employees
WHERE EmployeeID IN 
(
SELECT EmployeeID FROM Employees
WHERE DepartmentID = @departmentId
)

DELETE FROM Departments
WHERE DepartmentID = @departmentId
SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

GO
--Problem 9
USE Bank

GO
CREATE PROC usp_GetHoldersFullName AS
SELECT (A.FirstName + ' ' + A.LastName) AS [Full Name] FROM AccountHolders AS A

GO
-- Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Amount DECIMAL(15, 2)) AS
(
SELECT AH.FirstName, Ah.LastName FROM Accounts AS ACC
JOIN AccountHolders AS AH ON AH.Id = ACC.AccountHolderId
GROUP BY FirstName, LastName
HAVING SUM(Acc.Balance) > @Amount
)

GO
-- problem 11
CREATE FUNCTION ufn_CalculateFutureValue (@initialAmount DECIMAL(20,4), @yearlyInterestRate FLOAT, @numberOfYears INT) 
RETURNS DECIMAL(20,4) AS
BEGIN
	DECLARE @futureValue DECIMAL(20,4) ;
	DECLARE @asd FLOAT = POWER((1 + @yearlyInterestRate), @numberOfYears)
	SET @futureValue = @asd * @initialAmount
	RETURN @futureValue
END

GO
-- Problem 12 FOR JUDGE THE INPUT SHOULD BE 2 PARAMETERS WITH STATIC YEARS COUNT = 5
CREATE PROC usp_CalculateFutureValueForAccount AS
SELECT Acc.Id AS [Account Id], AH.FirstName AS [First Name], AH.LastName AS [Last Name], ACC.Balance AS [Current Balance], dbo.ufn_CalculateFutureValue(ACC.Balance, 0.1, 5) AS [Balance in 5 years] FROM Accounts AS ACC
JOIN AccountHolders AS AH ON ACC.AccountHolderId = AH.Id

GO
-- Problem 13
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN SELECT SUM(ByCash.Cash) AS SumCash FROM
	(
	SELECT UG.Cash, ROW_NUMBER() OVER (ORDER BY UG.Cash DESC) AS [RowNumber] FROM Games AS G
	JOIN UsersGames AS UG ON G.Id = UG.GameId
	WHERE G.Name = @gameName
	) AS ByCash
	WHERE ByCash.RowNumber % 2 = 1


Select * FROM ufn_CashInUsersGames('Lily Stargazer');

