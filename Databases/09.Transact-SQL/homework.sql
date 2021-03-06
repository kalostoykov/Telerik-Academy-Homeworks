-- task 1: Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
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

GO

-- task 2: Create a stored procedure that accepts a number as a parameter and 
--returns all persons who have more money in their accounts than the supplied number.
CREATE PROCEDURE usp_PersonsWithBalanceHigherThen(@amount money = 0)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full name]
	FROM Persons AS p
	LEFT JOIN Accounts AS a
	ON p.Id = a.PersonId
	WHERE a.Balance > @amount

GO

EXEC usp_PersonsWithBalanceHigherThen 43

GO

-- task 3: Create a function that accepts as parameters � sum, yearly interest rate and number of months.
	--It should calculate and return the new sum.
    --Write a SELECT to test whether the function works as expected.

CREATE FUNCTION ufn_CalculateInterest(@amount money, @interestRate money, @mountsCount int)
RETURNS money
AS
BEGIN
	DECLARE @result money, @interest money
	SET @interest = (@interestRate / 12) * @mountsCount
	SET @result = (@amount * @interest) + @amount

	RETURN @result
END

GO

SELECT dbo.ufn_CalculateInterest(10, 11, 12) AS [Interest]

GO

-- task 4: Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
	--It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE usp_ApplyInterestToAccount(@accountId int, @interestRate money)
AS
	UPDATE Accounts
	SET Accounts.Balance = dbo.ufn_CalculateInterest(
		(SELECT a.Balance FROM Accounts AS a WHERE a.Id = @accountId), 
		@interestRate, 
		1)
	WHERE Accounts.Id = @accountId

GO

EXEC usp_ApplyInterestToAccount 1, 42

GO

SELECT a.Balance
FROM Accounts AS a
WHERE a.Id = 1

GO

-- task 5: Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @amount money)
AS
	DECLARE @money money
	SET @money = (SELECT Accounts.Balance FROM Accounts WHERE Accounts.Id = @accountId)

	BEGIN TRANSACTION
	
	UPDATE Accounts
	SET Accounts.Balance = (-@amount) + @money
	WHERE Accounts.Id = @accountId
	
	COMMIT

GO

EXEC usp_WithdrawMoney 1, 42

GO

SELECT a.Balance
FROM Accounts AS a
WHERE a.Id = 1

GO

CREATE PROCEDURE usp_DepositeMoney(@accountId int, @amount money)
AS
	DECLARE @money money
	SET @money = (SELECT Accounts.Balance FROM Accounts WHERE Accounts.Id = @accountId)

	BEGIN TRANSACTION
	
	UPDATE Accounts
	SET Accounts.Balance = (@amount) + @money
	WHERE Accounts.Id = @accountId
	
	COMMIT

GO

EXEC usp_DepositeMoney 1, 42

GO

SELECT a.Balance
FROM Accounts AS a
WHERE a.Id = 1

GO

-- task 6: Create another table � Logs(LogID, AccountID, OldSum, NewSum).
	--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs
(
	Id INT IDENTITY PRIMARY KEY,
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY
)

GO

CREATE TRIGGER tr_OnAccountBalanceChange 
ON Accounts 
AFTER UPDATE
AS
	BEGIN
	DECLARE @oldSum money,
		@newSum money,
		@accountId int

	SET @oldSum = (SELECT DELETED.Balance 
					FROM DELETED)
	SET @newSum = (
		SELECT INSERTED.Balance 
		FROM INSERTED 
		WHERE INSERTED.Id = (
			SELECT DELETED.Id 
			FROM DELETED)
		)

	SET @accountId = (
		SELECT INSERTED.Id
		FROM INSERTED
	)

	INSERT INTO Logs
	VALUES(@accountId, @oldSum, @newSum)
	END
