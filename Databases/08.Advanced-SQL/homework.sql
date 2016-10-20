--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
	--Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees AS e
WHERE e.Salary = 
	(SELECT MIN(Employees.Salary)
	FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees AS e
WHERE e.Salary <= 
	(SELECT MIN(Employees.Salary)
	FROM Employees) * 1.1
	
--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
	--Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary, d.Name
FROM Employees AS e, Departments AS d
WHERE e.Salary =
	(SELECT MIN(Employees.Salary)
	FROM Employees
	WHERE Employees.DepartmentID = d.DepartmentID)
ORDER BY d.Name

--4. Write a SQL query to find the average salary in the department #1.
SELECT e.DepartmentID as [DepartmentNumber], AVG(e.Salary) as [AverageSalary]
FROM Employees AS e
WHERE e.DepartmentID = 1
GROUP BY e.DepartmentID

--5. Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name as [DepartmentName], AVG(e.Salary) as [AverageSalary]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.Name as [DepartmentName], COUNT(e.EmployeeID) as [NumberOfEmployees]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.EmployeeID) as [NoManagerEmployeeCount]
FROM Employees AS e
WHERE e.ManagerID IS NOT NULL

--8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.EmployeeID) as [ManagersCount]
FROM Employees AS e
WHERE e.ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name as [DepartmentName], AVG(e.Salary) as [AverageSalary]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name as [DepartmentName], t.Name as [Town], COUNT(e.EmployeeID) as [EmployeesCount]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
LEFT JOIN Addresses AS a
ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t
ON a.TownID = t.TownID
GROUP BY e.DepartmentID, d.Name, t.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName + ' ' + m.LastName AS [FullName] 
FROM Employees  AS m
WHERE m.EmployeeID IN
	(SELECT e.ManagerID
	FROM Employees AS e
	GROUP BY e.ManagerID
	HAVING COUNT(e.ManagerID) = 5)

--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS [EmployeeName], ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') as [EmployeeManager]
FROM Employees AS e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID
/*TODO: check LEFT JOIN or LEFT OUTHER JOIN*/

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName + ' ' + e.LastName AS [EmployeeName]
FROM Employees AS e
WHERE LEN(e.LastName) = 5

--14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(VARCHAR(20),GETDATE(), 104) + ' ' + CONVERT(VARCHAR(11),GETDATE(), 114)

--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
    --Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
    --Define the primary key column as identity to facilitate inserting records.
    --Define unique constraint to avoid repeating usernames.
    --Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
(
Id int NOT NULL IDENTITY PRIMARY KEY,
Username varchar(50) UNIQUE NOT NULL,
Password varchar(160) NOT NULL,
FullName nvarchar(100) NOT NULL,
LastLogin datetime,
CHECK(Password >= 5)
)

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
	--Test if the view works correctly.
GO

CREATE VIEW UsersView AS
SELECT u.FullName, u.Username
FROM Users as u

GO

SELECT * from UsersView

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
	--Define primary key and identity column.
CREATE TABLE Groups
(
Id int NOT NULL IDENTITY PRIMARY KEY,
Name varchar(50) UNIQUE NOT NULL
)

--18. Write a SQL statement to add a column GroupID to the table Users.
    --Fill some data in this new column and as well in the `Groups table.
    --Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users 
ADD GroupId int NOT NULL

ALTER TABLE Users
ADD CONSTRAINT FK_USERS_GROUPS
FOREIGN KEY(GroupId)
REFERENCES Groups(Id)

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupId)
VALUES ('Gosho', 'q123', NULL, 2),
	('Pesho', 'q123', NULL, 3),
	('Mariq', 'q123', NULL, 4)
		
INSERT INTO Groups (name)
VALUES ('1'),
	('2'),
	('3'),
	('4')

--19. 
--20.
--21.
--22.
--23.
--24.
--25.
--26.
--27.
--28.
--29.