-- task 1
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
