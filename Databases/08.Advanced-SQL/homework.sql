--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
	--Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.Salary
FROM Employees AS e
WHERE e.Salary = 
	(SELECT MIN(Employees.Salary)
	FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.Salary
FROM Employees AS e
WHERE e.Salary <= 
	(SELECT MIN(Employees.Salary)
	FROM Employees) * 1.1
	
--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
	--Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.Salary, d.Name
FROM Employees AS e, Departments AS d
WHERE e.Salary =
	(SELECT MIN(Employees.Salary)
	FROM Employees
	WHERE Employees.DepartmentID = d.DepartmentID)
ORDER BY d.Name

--4. Write a SQL query to find the average salary in the department #1.
SELECT e.DepartmentID AS [DepartmentNumber], AVG(e.Salary) AS [AverageSalary]
FROM Employees AS e
WHERE e.DepartmentID = 1
GROUP BY e.DepartmentID

--5. Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name AS [DepartmentName], AVG(e.Salary) AS [AverageSalary]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.Name AS [DepartmentName], COUNT(e.EmployeeID) AS [NumberOfEmployees]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.EmployeeID) AS [NoManagerEmployeeCount]
FROM Employees AS e
WHERE e.ManagerID IS NOT NULL

--8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.EmployeeID) AS [ManagersCount]
FROM Employees AS e
WHERE e.ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS [DepartmentName], AVG(e.Salary) AS [AverageSalary]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS [DepartmentName], t.Name AS [Town], COUNT(e.EmployeeID) AS [EmployeesCount]
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
SELECT e.FirstName + ' ' + e.LastName AS [EmployeeName], ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [EmployeeManager]
FROM Employees AS e
LEFT JOIN Employees AS m
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
PassHash varchar(160),
FullName nvarchar(100) NOT NULL,
LastLogin datetime
)

ALTER TABLE Users
ADD CONSTRAINT [MinLengthConstraint] CHECK (DATALENGTH([PassHash]) >= 5)

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
	--Test if the view works correctly.
GO

CREATE VIEW UsersView AS
SELECT u.FullName, u.Username
FROM Users AS u

GO

SELECT * from UsersView

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
	--Define primary key and identity column.
CREATE TABLE Groups
(
Id int NOT NULL IDENTITY PRIMARY KEY,
Name varchar(50) UNIQUE
)

--18. Write a SQL statement to add a column GroupID to the table Users.
    --Fill some data in this new column and as well in the `Groups table.
    --Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users 
ADD GroupId int

ALTER TABLE Users
ADD CONSTRAINT FK_USERS_GROUPS
FOREIGN KEY(GroupId)
REFERENCES Groups(Id)
		
--19. Write SQL statements to insert several records in the Users and Groups tables.
	--First add some data to Groups table.
	--Because the next insert can't complete because there is no coresponding Id in Groups.
INSERT INTO Groups (name)
VALUES ('1'),
	('2'),
	('3'),
	('4')

INSERT INTO Users (Username, PassHash, FullName, GroupId)
VALUES ('Gosho', 'q12345', 'Gosho', 2),
	('Pesho', 'q12345', 'Pesho', 3),
	('Mariq', 'q12345', 'Mariq', 4)

--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET FullName = 'Gosho Goshev'
WHERE Username = 'Gosho'

UPDATE Groups
SET Name = 'updated 2'
WHERE Name = '2'

--21. Write SQL statements to delete some of the records from the Users and Groups tables.
	--In the real world you don't delete record! Just all column Deleted or similar and use it as a flag
DELETE FROM Users
WHERE Username = 'Pesho'; 

DELETE FROM Groups
WHERE Name = '1'; 

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
    --Combine the first and last names as a full name.
    --For username use the first letter of the first name + the last name (in lowercase).
    --Use the same for the password, and NULL for last login time.

--This select shows that in the Employees Table there are fields that don't fulfill the Password constraint 
SELECT LOWER(LEFT(e.FirstName, 1) + e.LastName) AS [Username]
FROM Employees AS e

-- The following insert can't  be executed because of the reason above
INSERT INTO Users (Username, PassHash, FullName, LastLogin)
SELECT LOWER(LEFT(e.FirstName, 1) + e.LastName), 
	LOWER(LEFT(e.FirstName, 1) + e.LastName), 
	e.FirstName + ' ' + e.LastName, 
	NULL
FROM Employees AS e

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
	--Dont execute. You know why.
	--I don't think that this query will work but...
UPDATE Users
SET Passhash = NULL
WHERE LastLogin < CONVERT(datetime, '10.03.2010', 4) OR LastLogin IS NULL

--24. Write a SQL statement that deletes all users without passwords (NULL password).
	--Dont execute. You know why...
DELETE FROM Users
WHERE PassHash IS NULL

--25. Write a SQL query to display the average employee salary by department and job title.
SELECT e.JobTitle, d.Name, AVG(e.Salary) AS [AverageSalary]
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

--27. Write a SQL query to display the town where maximal number of employees work.
SELECT t.Name AS [TownName]
FROM Towns AS t
WHERE t.TownID = 
	(SELECT TOP(1) a.TownID
	FROM Employees AS e
	LEFT JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	GROUP BY a.TownID
	ORDER BY COUNT(e.EmployeeID) DESC)

--28. Write a SQL query to display the number of managers from each town.
SELECT t.Name AS [Town], COUNT(*) AS [ManagersCount]
FROM Employees AS e
LEFT JOIN Addresses AS a
ON a.AddressID = e.AddressID
LEFT JOIN Towns AS t
ON t.TownID = a.TownID
WHERE e.EmployeeID IN (
	SELECT m.ManagerID
	FROM Employees AS m)
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
	--Don't forget to define identity, primary key and appropriate foreign key.
    --Issue few SQL statements to insert, update and delete of some data in the table.
    --Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
    --For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours
(
Id int IDENTITY NOT NULL PRIMARY KEY,
EmployeeId int,
Date datetime,
Task nvarchar(100),
HoursWorked int,
Comments ntext
CONSTRAINT FK_WORKHOURS_EMPLOYEES
		FOREIGN KEY(EmployeeID)
		REFERENCES Employees(EmployeeID)
)

CREATE TABLE WorkHoursLogs 
(
Id int IDENTITY PRIMARY KEY,
ChangedOn datetime,
OldRecordData ntext,
NewRecordData ntext,
ChangeType varchar(20)
)

--Triggers for WorkHoursLogs table

--TODO: get old log data before the update and after the update; insert the log info into WorkHoursLogs instead of the NULL values

--on INSERT
GO

CREATE TRIGGER ONINSERT
ON TElerikAcademy.dbo.WorkHours
AFTER INSERT
AS
BEGIN
	INSERT INTO WorkHoursLogs
	VALUES (GETDATE(), NULL, NULL, 'INSERT')
END

--on UPDATE
GO

CREATE TRIGGER ONUPDATE
ON TElerikAcademy.dbo.WorkHours
AFTER UPDATE
AS
BEGIN
	INSERT INTO WorkHoursLogs
	VALUES (GETDATE(), NULL, NULL, 'UPDATE')
END

--on DELETE
GO

CREATE TRIGGER ONDELETE
ON TElerikAcademy.dbo.WorkHours
AFTER DELETE
AS
BEGIN
	INSERT INTO WorkHoursLogs
	VALUES (GETDATE(), NULL, NULL, 'DELETE')
END

--30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
	--At the end rollback the transaction.

--DELETE query can't be executed because the tables have foreign key.
--Maybe it's an option to prevent this from happening but I don't fing the way to disabled it.
BEGIN TRANSACTION

DELETE FROM Employees
WHERE Employees.DepartmentID IN (
	SELECT d.DepartmentID
	FROM Departments AS d
	WHERE d.Name = 'Sales')

DELETE FROM Addresses 
WHERE Addresses.AddressID IN (
	SELECT a.AddressID
	FROM Addresses AS a
	LEFT JOIN Employees AS e
	ON a.AddressID = e.AddressID
	LEFT JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales')

ROLLBACK TRANSACTION

--31. Start a database transaction and drop the table EmployeesProjects. 
GO

--I dont know why this transaction deletes all tables in the db and not only the EmployeesProjects
-- just execute ROLLBACK TRANSACTION to restore the tables

BEGIN TRANSACTION

DROP TABLE EmployeesProjects

