USE SoftUni

-- Prob 1
SELECT TOP 5 E.EmployeeID, E.JobTitle, E.AddressID, E.AddressID FROM Employees AS E
ORDER BY E.AddressID

-- Prob 2
SELECT TOP 50 E.FirstName, E.LastName, T.Name AS Town, A.AddressText FROM Employees AS E
JOIN Addresses AS A ON E.AddressID = A.AddressID
JOIN Towns AS T ON A.TownID = T.TownID
ORDER BY E.FirstName, E.LastName

-- Prob 3
SELECT E.EmployeeID, E.FirstName, E.LastName, D.Name AS DepartmentName FROM Employees AS E
JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
WHERE D.Name = 'Sales'
ORDER BY E.EmployeeID

-- Prob 4
SELECT TOP 5 E.EmployeeID, E.FirstName, E.Salary, D.Name AS DepartmentName FROM Employees AS E
JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
WHERE E.Salary > 15000
ORDER BY E.DepartmentID

-- Prob 5
SELECT TOP 3 E.EmployeeID, E.FirstName FROM Employees AS E
LEFT JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
WHERE EP.ProjectID IS NULL
ORDER BY E.EmployeeID

-- Prob 6
SELECT E.FirstName, E.LastName, E.HireDate, D.Name AS DeptName FROM Employees AS E
JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
WHERE (d.Name = 'Finance' OR d.Name = 'Sales') AND e.HireDate > '1999-01-01'
ORDER BY E.HireDate

-- Prob 7
SELECT TOP 5 E.EmployeeID, E.FirstName, P.Name AS ProjectName  FROM Employees AS E
JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
JOIN Projects AS P ON P.ProjectID = EP.ProjectID
WHERE P.StartDate > '08-13-2002' AND P.EndDate IS NULL
ORDER BY E.EmployeeID

-- Prob 8
SELECT E.EmployeeID, E.FirstName,
IIF(P.StartDate > '2005-01-01', NULL, P.Name) AS ProjectName
  FROM Employees AS E
  JOIN EmployeesProjects AS EP ON E.EmployeeID = EP.EmployeeID
  JOIN Projects AS P ON P.ProjectID = EP.ProjectID
 WHERE E.EmployeeID = 24

-- Prob 9
SELECT E.EmployeeID, E.FirstName, E.ManagerID, M.FirstName AS ManagerName FROM Employees AS E
JOIN Employees AS M ON E.ManagerID = M.EmployeeID
WHERE E.ManagerID IN (3, 7)
ORDER BY E.EmployeeID

-- Prob 10
SELECT TOP 50 E.EmployeeID, (E.FirstName + ' ' + E.LastName) AS [EmployeeName],
(M.FirstName + ' ' + M.LastName) AS [ManagerName], D.Name AS [DepartmentName]
FROM Employees AS E
JOIN Employees AS M ON E.ManagerID = M.EmployeeID
JOIN Departments AS D ON E.DepartmentID = D.DepartmentID
ORDER BY E.EmployeeID

-- Prob 11
SELECT MIN(AverageSalary) AS MinAverageSalary FROM (
SELECT E.DepartmentID, AVG(E.Salary) AS AverageSalary FROM Employees AS E
GROUP BY E.DepartmentID
) AS Average

-- Prob 12
USE Geography
SELECT C.CountryCode, M.MountainRange, P.PeakName, P.Elevation FROM Countries AS C
JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
JOIN Mountains AS M ON MC.MountainId = M.Id
JOIN Peaks AS P ON P.MountainId = M.Id
WHERE C.CountryCode = 'BG' AND P.Elevation > 2835
ORDER BY Elevation DESC

-- prob 13
SELECT MC.CountryCode, COUNT(MC.MountainId) AS MountainRanges FROM MountainsCountries AS MC
WHERE CountryCode IN ('US', 'RU', 'BG')
GROUP BY CountryCode

--prob 14
SELECT TOP 5 C.CountryName, R.RiverName FROM Countries AS C
JOIN Continents AS CONT ON C.ContinentCode = CONT.ContinentCode
LEFT JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers AS R ON CR.RiverId = R.Id
WHERE cont.ContinentName = 'Africa'
ORDER BY C.CountryName

-- Prob 15
WITH CurContUsage_CTE (ContinentCode, CurrencyCode, CurrencyUsage) AS (
  SELECT ContinentCode, CurrencyCode, COUNT(CountryCode) AS CurrencyUsage
  FROM Countries 
  GROUP BY ContinentCode, CurrencyCode
  HAVING COUNT(CountryCode) > 1
)

SELECT ContMax.ContinentCode, ccy.CurrencyCode, ContMax.CurrencyUsage FROM 
(
SELECT ContinentCode, MAX(CurrencyUsage) AS CurrencyUsage
   FROM CurContUsage_CTE 
   GROUP BY ContinentCode
   ) AS ContMax
JOIN CurContUsage_CTE AS ccy ON 
(ContMax.ContinentCode = ccy.ContinentCode AND ContMax.CurrencyUsage = ccy.CurrencyUsage)
ORDER BY ContMax.ContinentCode


-- Problem 16
SELECT COUNT(*) AS CountryCode FROM Countries AS C
LEFT JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
WHERE MC.MountainId IS NULL


-- Problem 17
WITH CountryMaxPeak_CTE (CountryName, Elevation) AS (
SELECT C.CountryName, MAX(P.Elevation) FROM Countries AS C
JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
JOIN Mountains AS M ON MC.MountainId = M.Id
JOIN Peaks AS P ON P.MountainId = M.Id
GROUP BY C.CountryName
), CountryMaxRiver_CTE (CountryName, [Length]) AS (
SELECT C.CountryName, MAX(R.Length) FROM Countries AS C
JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
JOIN Rivers AS R ON R.Id = CR.RiverId
GROUP BY C.CountryName
)

SELECT TOP 5 C.CountryName, MaxPeak.Elevation AS HighestPeakElevation, MaxRiver.Length AS LongestRiverLength FROM Countries AS C
JOIN CountryMaxRiver_CTE AS MaxRiver ON MaxRiver.CountryName = C.CountryName
JOIN CountryMaxPeak_CTE AS MaxPeak ON MaxPeak.CountryName = C.CountryName
ORDER BY MaxPeak.Elevation DESC, MaxRiver.Length DESC, C.CountryName


--Problem 18
WITH PeaksMountains_CTE (Country, PeakName, Elevation, Mountain) AS (
  SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange
  FROM Countries AS c
  LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
  LEFT JOIN Peaks AS p ON p.MountainId = m.Id
)

SELECT
  TopElevations.Country AS Country,
  ISNULL(pm.PeakName, '(no highest peak)') AS HighestPeakName,
  ISNULL(TopElevations.HighestElevation, 0) AS HighestPeakElevation,	
  ISNULL(pm.Mountain, '(no mountain)') AS Mountain
FROM 
  (SELECT Country, MAX(Elevation) AS HighestElevation
   FROM PeaksMountains_CTE 
   GROUP BY Country) AS TopElevations
LEFT JOIN PeaksMountains_CTE AS pm 
ON (TopElevations.Country = pm.Country AND TopElevations.HighestElevation = pm.Elevation)
ORDER BY Country, HighestPeakName 

