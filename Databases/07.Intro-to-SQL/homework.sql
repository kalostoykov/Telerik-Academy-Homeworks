--4. Write a SQL query to find all information about all departments.
SELECT *
FROM Departments

--5. Write a SQL query to find all department names.
SELECT Name
FROM Departments

--6. Write a SQL query to find the salary of each employee.
SELECT Salary
FROM Employees

--7. Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName
FROM Employees

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. 
--Emails should look like “John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses]
FROM Employees

--9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary
FROM Employees

--10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM Employees as e
WHERE e.JobTitle = 'Sales Representative'

--11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT e.FirstName + ' ' + e.LastName as [Full name]
FROM Employees as e
WHERE e.FirstName LIKE 'SA%'

--12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT e.FirstName + ' ' + e.LastName as [Full name]
FROM Employees as e
WHERE e.LastName LIKE '%ei%'

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT e.FirstName + ' ' + e.LastName as [Full name], e.Salary
FROM Employees as e
WHERE e.Salary >= 20000 AND e.Salary <= 30000

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT e.FirstName + ' ' + e.LastName as [Full name], e.Salary
FROM Employees as e
WHERE e.Salary = 12500 OR 
	e.Salary = 14000 OR
	e.Salary = 23600 OR
	e.Salary = 25000

--15. Write a SQL query to find all employees that do not have manager.
SELECT e.FirstName + ' ' + e.LastName as [Full name]
FROM Employees as e
WHERE e.ManagerID IS NOT NULL

--16. Write a SQL query to find all employees that have salary more than 50000. 
--Order them in decreasing order by salary.
SELECT e.FirstName + ' ' + e.LastName as [Full name], e.Salary
FROM Employees as e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

--17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 10 e.FirstName + ' ' + e.LastName as [Full name], e.Salary
FROM Employees as e
ORDER BY e.Salary DESC

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName as [Full name], a.AddressText + ' ' + t.Name as [Full address]
FROM Employees as e
INNER JOIN Addresses as a
ON e.AddressID = a.AddressID
INNER JOIN Towns as t
ON a.TownID = t.TownID

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName + ' ' + e.LastName as [Full name], a.AddressText + ' ' + t.Name as [Full address]
FROM Employees as e, Addresses as a, Towns as t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

--20. Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName as [Full name], managers.FirstName + ' ' + managers.LastName as [Full manager name]
FROM Employees as e, Employees as managers
WHERE e.ManagerID = managers.EmployeeID

--21. Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a	
SELECT e.FirstName + ' ' + e.LastName as [Full name], m.FirstName + ' ' + m.LastName as [Full manager name], a.AddressText
FROM Employees as e
INNER JOIN Employees as m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses as a
ON e.AddressID = a.AddressID

--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
-- Please confirm that this is right :)
SELECT d.Name
FROM Departments as d

UNION

SELECT t.Name
FROM Towns as t

--23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
--Use right outer join. 
SELECT e.FirstName + ' ' + e.LastName as [Full employee name], m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees as e
RIGHT OUTER JOIN Employees as m
ON m.EmployeeID = e.ManagerID
where e.FirstName IS NOT NULL AND e.LastName IS NOT NULL

--Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName as [Full employee name], m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees as e
LEFT OUTER JOIN Employees as m
ON m.EmployeeID = e.ManagerID
where m.FirstName IS NOT NULL AND m.LastName IS NOT NULL

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName as [Full name]
FROM Employees as e
LEFT JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND (e.HireDate > 1996 OR e.HireDate < 2005)
