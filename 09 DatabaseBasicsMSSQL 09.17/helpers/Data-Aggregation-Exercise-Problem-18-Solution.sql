SELECT Departmentid,
       Salary
FROM
(
    SELECT Departmentid,
           Salary,
           DENSE_RANK() OVER(PARTITION BY Departmentid ORDER BY Salary DESC) AS Rank
    FROM Employees
    GROUP BY Departmentid,
             Salary
) AS Rankedsalaries
WHERE Rank = 3