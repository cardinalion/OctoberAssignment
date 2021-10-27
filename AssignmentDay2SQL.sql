--Assignment Day2 –SQL
--Yu Wang

--Short Answer questions
--1. A result set is an output set of rows of data retrieved basing on queries.

--2.
--1) UNION removes duplicate records, UNION ALL does not
--2) UNOIN: the records from the first column will be sorted ascendingly
--3) UNION cannot be used in recursive common table expression (CTE), but UNION ALL can

--3. UNION, UNION ALL, INTERSECT, EXCEPT

--4. 
--1) JOIN combines data from multiple tables based on a matched condition between them. UNION combines the result-set of two or more SELECT statements.
--2) The data combined using JOIN statement results into new columns. The data combined using UNION statement is into results into new distinct rows.

--5. INNER JOIN returns only the matching rows between both the tables, non-matching rows are eliminated, while FULL JOIN includes non-matching rows from both the tables.
--6. LEFT JOIN is one type of OUTER JOIN. OUTER JOIN also includes RIGHT JOIN and FULL JOIN.
--7. CROSS JOIN creates the Cartesian product of two tables, irrespective of any filter criterion or condition

--8.
--1) Both WHERE and HAVING are used as filters. HAVING applies only to groups as a whole, as only filter aggretated fileds, but WHERE appleis to individual rows
--2) WHERE goes before aggregations, but HAVING filters after the aggregtions
--3) WHERE can be used with SELECT, UPDATE and DELETE statement, but HAVING can only be used in SELECT statement

--9.YES

--Queries
USE AdventureWorks2019
GO
--1
SELECT COUNT(*)
FROM Production.Product

--2
SELECT COUNT(ProductSubcategoryID)
FROM Production.Product

--3
SELECT ProductSubcategoryID, COUNT(*) CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID

--4
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5
SELECT ProductID ,SUM(Quantity) [Total Quantity]
FROM Production.ProductInventory
GROUP BY ProductID

--6
SELECT ProductID ,Quantity AS TheSum
FROM Production.ProductInventory
WHERE LocationID=40 AND Quantity<100

--7
SELECT Shelf, ProductID, Quantity AS TheSum
FROM Production.ProductInventory
WHERE LocationID=40 AND Quantity<100

--8?
SELECT ProductID, Quantity 
FROM Production.ProductInventory
WHERE LocationID=10

--9
SELECT ProductID, Shelf, AVG(Quantity) TheAvg
FROM Production.ProductInventory
GROUP BY Shelf, ProductID

--10
SELECT ProductID, Shelf, AVG(Quantity) TheAvg
FROM Production.ProductInventory
WHERE Shelf!='N/A'
GROUP BY Shelf, ProductID

--11
SELECT Color, Class, COUNT(*) TheCount, AVG(ListPrice) AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

--12
SELECT cr.Name, sp.Name
FROM Person.CountryRegion cr JOIN Person.StateProvince sp ON CR.CountryRegionCode=sp.CountryRegionCode

--13
SELECT cr.Name, sp.Name
FROM Person.CountryRegion cr JOIN Person.StateProvince sp ON CR.CountryRegionCode=sp.CountryRegionCode
WHERE cr.Name IN ('Canada', 'Germany')


-------------
USE Northwind
GO

--14
DECLARE @currentYear INT
SELECT @currentYear=YEAR(GETDATE())

--This one seems to be more efficient
SELECT p.ProductID, MAX(YEAR(o.OrderDate)) MostRecentOrderYear
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
GROUP BY p.ProductID
HAVING @currentYear-MAX(YEAR(o.OrderDate))<25

--This one may be less efficient
SELECT DISTINCT p.ProductID
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
WHERE @currentYear-YEAR(o.OrderDate)<25

--15
SELECT TOP 5 c.PostalCode, SUM(od.Quantity) TotalProductsSold
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE c.PostalCode IS NOT NULL
GROUP BY c.PostalCode
ORDER BY TotalProductsSold DESC

--16
SELECT TOP 5 c.PostalCode, SUM(od.Quantity) TotalProductsSoldInLast25Years
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE c.PostalCode IS NOT NULL 
GROUP BY c.PostalCode
HAVING YEAR(GETDATE())-MAX(YEAR(o.OrderDate))<25
ORDER BY TotalProductsSoldInLast25Years DESC

--17
SELECT City, COUNT(*) NumberOfCustomers
FROM Customers
GROUP BY City

--18
SELECT City, COUNT(*) NumberOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(*) >=2

--19
SELECT DISTINCT c.ContactName
FROM Orders o JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE YEAR(o.OrderDate) > 1997

--20
SELECT c.ContactName, MAX(o.OrderDate) MostRecentOrderDate
FROM Orders o JOIN Customers c ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
ORDER BY MostRecentOrderDate DESC

--21
SELECT c.ContactName, SUM(od.Quantity) TotalProductsOrdered
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

--22
SELECT c.CustomerID, SUM(od.Quantity) TotalProductsOrdered
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity)>100

--23
SELECT su.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Suppliers su CROSS JOIN Shippers sh

--24
SELECT o.OrderDate, p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderDate

--25
SELECT e1.EmployeeID AS FirstEmployeeID, e2.EmployeeID AS SecondEmployeeID
FROM Employees e1, Employees e2
WHERE e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID

--26
SELECT e1.EmployeeID, COUNT(e2.EmployeeID) NumberOfManagedEmployees
FROM Employees e1, Employees e2
WHERE e2.ReportsTo = e1.EmployeeID
GROUP BY e1.EmployeeID
HAVING COUNT(*)>=2

--27
SELECT City, CompanyName AS ContactName, Type='Supplier'
FROM Suppliers
UNION
SELECT City, ContactName, Type='Customer'
FROM Customers