-- task 1
CREATE TABLE Cities
(
	CityId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(19) NOT NULL
)

-- task 2
INSERT INTO Cities
SELECT City
	FROM Employees
	WHERE City IS NOT NULL
UNION
SELECT City
	FROM Customers
	WHERE City IS NOT NULL
UNION
SELECT City
	FROM Suppliers
	WHERE City IS NOT NULL

-- task 3
ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

-- task 4
UPDATE Employees
SET Employees.CityId = (SELECT CityId FROM Cities
WHERE Cities.Name = Employees.City)

UPDATE Customers
SET Customers.CityId = (SELECT CityId FROM Cities
WHERE Cities.Name = City)

UPDATE Suppliers
SET Suppliers.CityId = (SELECT CityId FROM Cities
WHERE Cities.Name = City)

-- task 5
ALTER TABLE Cities
ADD UNIQUE (Name)

-- task 6
INSERT INTO Cities
	SELECT DISTINCT ShipCity
	FROM Orders
	WHERE Orders.ShipCity NOT IN (
	SELECT Name
	FROM Cities
)

-- task 7
ALTER TABLE Orders
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

-- task 8
EXECUTE sp_rename 'Orders.CityId', 'ShipCityId', 'COLUMN'

-- task 9
UPDATE Orders
SET Orders.ShipCityId = ( SELECT Cities.CityId
	FROM Cities
	WHERE Orders.ShipCity = Cities.Name)

-- task 10
ALTER TABLE Orders
DROP COLUMN ShipCity

-- task 11
CREATE TABLE Countries
(
	CountryId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(19) NOT NULL UNIQUE
)

-- task 12
ALTER TABLE Cities
ADD CountryId INT FOREIGN KEY REFERENCES Countries(CountryId)

-- task 13
INSERT INTO Countries
SELECT e.Country
	FROM Employees AS e
	WHERE e.Country IS NOT NULL
UNION
SELECT c.Country
	FROM Customers AS c
	WHERE c.Country IS NOT NULL
UNION
SELECT s.Country
	FROM Suppliers AS s
	WHERE s.Country IS NOT NULL
UNION
SELECT o.ShipCountry
	FROM Orders AS o
	WHERE o.ShipCountry IS NOT NULL

-- task 14
-- Should check if this query is correct

UPDATE Cities
SET Cities.CountryId = (
SELECT DISTINCT Countries.CountryId
FROM Countries
LEFT JOIN Employees
ON Countries.Name = Employees.Country
LEFT JOIN Customers
ON Countries.Name = Customers.Country
LEFT JOIN Orders
ON Countries.Name = Orders.ShipCountry
WHERE Cities.Name = Employees.City OR Cities.Name = Customers.City OR Cities.CityId = Orders.ShipCityId)