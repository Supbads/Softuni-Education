USE SoftUni

SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%EI%'

SELECT FirstName FROM Employees
WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%ENGINEER%'

SELECT Name FROM Towns
WHERE LEN(Name) BETWEEN 5 AND 6
ORDER BY Name

SELECT * FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name

SELECT * FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name

GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

GO
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

GO
USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

SELECT PeakName, RiverName, LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName) - 1))) AS Mix FROM Peaks, Rivers
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
ORDER BY Mix

USE Diablo
SELECT TOP(50) Name, FORMAT([Start],'yyyy-MM-dd') AS Start FROM Games
WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start, Name

SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@',Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider], Username

SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

SELECT Name AS Game,
Case 
WHEN DATEPART(HOUR,G.Start) Between 0 and 11 Then 'Morning'
WHEN DATEPART(HOUR,G.Start) Between 12 and 17 Then 'Afternoon'
WHEN DATEPART(HOUR,G.Start) Between 18 and 23 Then 'Evening'
END AS [Part of the Day],
Case
WHEN G.Duration <= 3 THEN 'Extra Short'
WHEN G.Duration Between 4 AND 6 THEN 'Short'
WHEN G.Duration > 6 THEN 'Long'
ELSE 'Extra Long'
END as [Duration]
     FROM Games AS G
ORDER BY Game, Duration,  [Part of the Day]

Use Orders
SELECT O.ProductName,
       O.OrderDate, 
	   DATEADD(DAY, 3, O.OrderDate) AS [Pay Due], 
	   DATEADD(MONTH, 1, O.OrderDate) AS [Deliver Due] FROM Orders as O


SELECT P.Name, 
       DATEDIFF(YEAR, P.Birthdate, GETDATE()) AS [Age in Years], 
	   DATEDIFF(MONTH, P.Birthdate, GETDATE()) AS [Age in Months], 
	   DATEDIFF(DAY, P.Birthdate, GETDATE()) AS [Age in Days], 
	   DATEDIFF(MINUTE, P.Birthdate, GETDATE()) AS [Age in Minutes], 
	   FROM People AS P