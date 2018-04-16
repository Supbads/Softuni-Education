Use Gringotts

-- prob 1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits

--prob 2
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

-- prob 3
SELECT W.DepositGroup , MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

-- prob 4
SELECT TOP(2) DepositGroup
	FROM (
	SELECT W.DepositGroup, AVG(MagicWandSize) AS AverageWandSize 
	FROM WizzardDeposits AS W
	GROUP BY W.DepositGroup
 ) AS ByAverage
GROUP BY DepositGroup
ORDER BY MIN(AverageWandSize)

-- prob 5
SELECT W.DepositGroup , SUM(W.DepositAmount) AS TotalSum FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

-- prob 6
SELECT W.DepositGroup , SUM(W.DepositAmount) AS TotalSum FROM WizzardDeposits AS W
WHERE W.MagicWandCreator LIKE '%Ollivander family%'
GROUP BY W.DepositGroup

-- prob 7
SELECT W.DepositGroup , SUM(W.DepositAmount) AS TotalSum FROM WizzardDeposits AS W
WHERE W.MagicWandCreator LIKE '%Ollivander family%'
GROUP BY W.DepositGroup
HAVING SUM(W.DepositAmount) < 150000
ORDER BY SUM(W.DepositAmount) DESC

-- prob 8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- prob 9
SELECT ageGroups.AgeGroup, COUNT(*) FROM
(
SELECT 
CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN Age >= 61 THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits
) AS ageGroups
GROUP BY ageGroups.AgeGroup

--prob 10
SELECT ByLetter.FirstLetter
FROM
(
SELECT
CASE
WHEN W.DepositGroup = 'Troll Chest' THEN LEFT(W.FirstName , 1)
ELSE 'irrelevant'
END AS FirstLetter
FROM WizzardDeposits AS W
) AS ByLetter
WHERE ByLetter.FirstLetter != 'irrelevant'
GROUP BY ByLetter.FirstLetter
ORDER BY FirstLetter

--ver 2
SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--problem 11
SELECT W.DepositGroup, W.IsDepositExpired, AVG(W.DepositInterest) AS [AverageInterest] FROM WizzardDeposits AS W
WHERE W.DepositStartDate > CONVERT(DATE,'01/01/1985')
GROUP BY W.DepositGroup, W.IsDepositExpired
ORDER BY W.DepositGroup DESC, IsDepositExpired

--problem 12
SELECT SUM(wizardDeposit.Difference) AS SumDifference FROM
(
SELECT FirstName, DepositAmount,
LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizard,
LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference 
FROM WizzardDeposits
) AS wizardDeposit

USE SoftUni
--Problem 13
SELECT E.DepartmentID, SUM(E.Salary) AS TotalSalary FROM Employees AS E
GROUP BY E.DepartmentID
ORDER BY E.DepartmentID

--problem 14
SELECT E.DepartmentID, MIN(E.Salary) AS TotalSalary FROM Employees AS E
WHERE E.DepartmentID IN (2 ,5 ,7) AND E.HireDate > CONVERT(DATE,'01/01/2000')
GROUP BY E.DepartmentID
ORDER BY E.DepartmentID

--problem 15
SELECT * INTO NewTable FROM Employees
WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT N.DepartmentID, AVG(N.Salary) AS [AverageSalary] FROM NewTable AS N
GROUP BY N.DepartmentID

--prob 16
SELECT E.DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees AS E
GROUP BY E.DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--prob 17
SELECT COUNT(*) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--Prob 18
SELECT *,Salaries.DepartmentID, Salaries.Salary FROM
(
SELECT DepartmentId,
MAX(Salary) AS Salary,
DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
FROM Employees
GROUP BY DepartmentID, Salary
)AS Salaries 
WHERE Rank=3

--prob 19
SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS emp1
WHERE Salary >
(SELECT AVG(Salary) FROM Employees AS emp2
WHERE emp1.DepartmentID = emp2.DepartmentID
GROUP BY DepartmentID)
ORDER BY DepartmentID