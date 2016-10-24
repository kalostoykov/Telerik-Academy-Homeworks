-- task 1 Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
	--Insert few records for testing.
    --Write a stored procedure that selects the full names of all persons.

CREATE TABLE Persons
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	SSN NVARCHAR(50)
)

GO

CREATE TABLE Accounts
(
	Id INT IDENTITY PRIMARY KEY,
	PersonId INT FOREIGN KEY REFERENCES Persons(Id),
	Balance MONEY
)

GO

INSERT INTO Persons 
VALUES ('Gosho', 'Goshev', '123123'),
	('Pesho', 'Peshov', '124124'),
	('Mariq', 'Marinova', '125125')

GO

INSERT INTO Accounts
	VALUES
	(1, 42),
	(2, 43),
	(3, 44)

GO

CREATE PROCEDURE usp_GetFullName
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full name]
	FROM Persons AS p

GO

EXEC usp_GetFullName
