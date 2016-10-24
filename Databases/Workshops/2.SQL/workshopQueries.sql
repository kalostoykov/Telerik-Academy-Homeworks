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
SET Orders.ShipCity = (SELECT CityId FROM Cities
WHERE Cities.Name = Orders.ShipCity)
