--Assignment Day2 –SQL
--Yu Wang

--Short Answer questions
--1. View is a virtual table that contains data from one or multiple tables.
-- Extra Security (permission), Query Simplicity, Structural simplicity (personalized view, hide data complicity), Logical data independence.

--2. You can modify the data of an underlying base table through a view, as long as the following conditions are true:
--a) Any modifications, including UPDATE, INSERT, and DELETE statements, must reference columns from only one base table.
--b) The columns being modified in the view must directly reference the underlying data in the table columns, which cannot be derived from an aggregate function or computation
--c) The columns being modified are not affected by GROUP BY, HAVING, or DISTINCT clauses.
--d) TOP is not used anywhere in the select_statement of the view together with the WITH CHECK OPTION clause.

--3. A stored procedure is a precompiled set of one or more SQL statements which perform some specific task.
-- Better Performance (Compiled once and stored in executable form, faster), code reuseablity, better maintainability

--4.
--1) A Stored Procedure accepts parameters. A view does not.
--2) SP cannot be used as building block in a larger query. A view can.
--3) SP can contain several statements, loops, IF ELSE, etc. A view Can contain only one single SELECT query.
--4) SP can perform modifications to one or several tables.

--5. 
--1) usage: sp for DML, functions: for calculations
--2) how to call: sp called by its name, functions must be called in selection statements
--3) input: sp may or may not have input parameters. functions must have inputs
--4) output: sp may or may not have outout, functios must have outputs
--5) sp can call function, functions cannot call sp

--6. YES
--7. NO
--8. Trigger is a special type of sp, automatically runs when an event occurs. 
-- There are four types of triggers: DDL Trigger, DML Trigger, Logon Trigger, CLR Triggers.

--9. Trigger is a stored procedure that runs automatically when various events happen while a normal SP need to be called explicitly. Triggers cannot take inputs or return values.


--Queries
USE Northwind
GO
--1
CREATE VIEW view_product_order_wang
AS
SELECT p.ProductID, p.ProductName, SUM(od.Quantity) TotalOrderedQuantity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
GO

--2
DROP PROC IF EXISTS sp_product_order_quantity_wang
GO

CREATE PROC sp_product_order_quantity_wang
@ProductID int
AS
BEGIN
DECLARE @TotalOrderedQuantity AS INT
SELECT @TotalOrderedQuantity = v.TotalOrderedQuantity FROM view_product_order_wang v WHERE @ProductID=v.ProductID
RETURN @TotalOrderedQuantity
END
GO

BEGIN
DECLARE @res int
EXEC @res = sp_product_order_quantity_wang 1
print @res
END
GO

--3
CREATE PROC sp_product_order_city_wang
@ProductName VARCHAR(20)	
AS
BEGIN
SELECT TOP 5 c.City, SUM(od.Quantity) TotalOrderedQuantity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE p.ProductName = @ProductName
GROUP BY c.City
ORDER BY TotalOrderedQuantity DESC
END
GO

EXEC sp_product_order_city_wang 'Chai'
GO

--4
CREATE TABLE city_wang
(ID INT PRIMARY KEY IDENTITY(1,1),
City VARCHAR(20))

CREATE TABLE people_wang
(ID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
City INT FOREIGN KEY REFERENCES city_wang(ID))

INSERT INTO city_wang 
(City) 
VALUES
('Seattle'),
('Green Bay')

INSERT INTO people_wang
(Name, City)
VALUES
('Aaron Rodgers', 2),
('Russell Wilson', 1),
('Jody Nelson', 2)
GO

--err
DELETE FROM city_wang
WHERE City = 'Seattle'

ALTER TABLE people_wang
ADD CONSTRAINT FK_City_ID
FOREIGN KEY (City)
REFERENCES city_wang(ID)
ON DELETE SET NULL

DELETE FROM city_wang
WHERE City = 'Seattle'

INSERT INTO city_wang
(City)
VALUES
('Madison')

UPDATE people_wang
SET City = 3 WHERE City IS NULL
GO

CREATE VIEW Packers_Wang
AS
SELECT p.ID, p.Name, p.City
FROM people_wang p JOIN city_wang c ON p.City = c.ID
WHERE c.City = 'Green Bay'
GO

DROP TABLE people_wang
DROP TABLE city_wang
DROP VIEW Packers_Wang
GO

--5
DROP PROC IF EXISTS sp_birthday_employees_wang
GO
CREATE PROC sp_birthday_employees_wang
AS
BEGIN
DROP TABLE IF EXISTS #birthday_employees_wang
SELECT EmployeeID, BirthDate
INTO birthday_employees_wang
FROM Employees
WHERE MONTH(BirthDate) = 2
END
EXEC sp_birthday_employees_wang
SELECT * FROM birthday_employees_wang
DROP TABLE birthday_employees_wang

--6
--1) WE can use CHECKSUM TABLE and compare the results.
--2) We can SELECT all records in two tables and UNION them. If we get records greater than any of two tables, they don't have same data.

--7
CREATE TABLE #Names
(FirstName VARCHAR(10),
LastName VARCHAR(10),
MiddleName VARCHAR(5))

INSERT INTO #Names
(FirstName, LastName, MiddleName)
VALUES
('John', 'Green', NULL),
('Mike', 'White', 'M')

SELECT FirstName + ' ' + LastName + 
(CASE   
    WHEN MiddleName IS NULL THEN ''   
    WHEN MiddleName IS NOT NULL THEN ' ' + MiddleName + '.'   
END)
AS FullName
FROM #Names

DROP TABLE #Names

--8
CREATE TABLE #StudentMark
(Student VARCHAR(10) PRIMARY KEY,
Marks INT CHECK(Marks BETWEEN 0 AND 100),
Sex CHAR(1) CHECK(Sex IN ('F', 'M')))

INSERT INTO #StudentMark
(Student, Marks, Sex)
VALUES
('Ci', 70, 'F'),
('Bob', 80, 'M'),
('Li', 90, 'F'),
('Mi', 95, 'M')

SELECT MAX(Marks) MaxMarks
FROM #StudentMark
WHERE Sex = 'F'

--9
SELECT *
FROM #StudentMark
ORDER BY Sex, Marks DESC

DROP TABLE #StudentMark
