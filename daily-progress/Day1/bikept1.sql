/*
--------------------------------------------------------------------
© 2017 sqlservertutorial.net All Rights Reserved
--------------------------------------------------------------------
Name   : BikeStores
Link   : http://www.sqlservertutorial.net/load-sample-database/
Version: 1.0
--------------------------------------------------------------------
*/
-- create schemas

use BikeStores

CREATE SCHEMA production;
go

CREATE SCHEMA sales;
go

-- create tables
CREATE TABLE production.categories (
	category_id INT IDENTITY (1, 1) PRIMARY KEY,
	category_name VARCHAR (255) NOT NULL
);

CREATE TABLE production.brands (
	brand_id INT IDENTITY (1, 1) PRIMARY KEY,
	brand_name VARCHAR (255) NOT NULL
);

CREATE TABLE production.products (
	product_id INT IDENTITY (1, 1) PRIMARY KEY,
	product_name VARCHAR (255) NOT NULL,
	brand_id INT NOT NULL,
	category_id INT NOT NULL,
	model_year SMALLINT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (category_id) REFERENCES production.categories (category_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (brand_id) REFERENCES production.brands (brand_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE sales.customers (
	customer_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR (255) NOT NULL,
	last_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255) NOT NULL,
	street VARCHAR (255),
	city VARCHAR (50),
	state VARCHAR (25),
	zip_code VARCHAR (5)
);

CREATE TABLE sales.stores (
	store_id INT IDENTITY (1, 1) PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255),
	street VARCHAR (255),
	city VARCHAR (255),
	state VARCHAR (10),
	zip_code VARCHAR (5)
);

CREATE TABLE sales.staffs (
	staff_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR (50) NOT NULL,
	last_name VARCHAR (50) NOT NULL,
	email VARCHAR (255) NOT NULL UNIQUE,
	phone VARCHAR (25),
	active tinyint NOT NULL,
	store_id INT NOT NULL,
	manager_id INT,
	FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (manager_id) REFERENCES sales.staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE sales.orders (
	order_id INT IDENTITY (1, 1) PRIMARY KEY,
	customer_id INT,
	order_status tinyint NOT NULL,
	-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
	order_date DATE NOT NULL,
	required_date DATE NOT NULL,
	shipped_date DATE,
	store_id INT NOT NULL,
	staff_id INT NOT NULL,
	FOREIGN KEY (customer_id) REFERENCES sales.customers (customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (staff_id) REFERENCES sales.staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE sales.order_items (
	order_id INT,
	item_id INT,
	product_id INT NOT NULL,
	quantity INT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	discount DECIMAL (4, 2) NOT NULL DEFAULT 0,
	PRIMARY KEY (order_id, item_id),
	FOREIGN KEY (order_id) REFERENCES sales.orders (order_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) REFERENCES production.products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE production.stocks (
	store_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY (store_id, product_id),
	FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) REFERENCES production.products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- STORED PROCEDURE
--1) Create a stored procedure that takes a customer ID and returns the total amount they have ordered 

CREATE PROC usp_GetCustomerTotalAmount @CustomerID INT
AS
BEGIN
SELECT SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_order_amount
FROM sales.orders o
JOIN sales.order_items oi ON o.order_id = oi.order_id
WHERE o.customer_id = @CustomerID;
END

DECLARE @CustID INT = 5
EXEC usp_GetCustomerTotalAmount @CustID


--2) Create a procedure that returns all orders placed for a specific store between two dates

CREATE PROC usp_GetAllOrdersByDate @StoreID INT, @StartDate DATE, @EndDate DATE
AS
BEGIN
SELECT order_id, customer_id, order_status, order_date, required_date, shipped_date, staff_id
FROM sales.orders
WHERE store_id = @StoreID AND order_date BETWEEN @StartDate AND @EndDate
ORDER BY order_date;
END

DECLARE @StoreID INT = 2, @StartDate DATE = '2016-02-01', @EndDate DATE = '2016-02-03'
EXEC usp_GetAllOrdersByDate @StoreID, @StartDate, @EndDate

--3) Create a stored procedure to insert a new product into production.products

CREATE PROC usp_InsertProduct @ProductName VARCHAR(255), @BrandID INT, @CategoryID INT, @ModelYear SMALLINT, @ListPrice DECIMAL(10, 2)
AS
BEGIN
INSERT INTO production.products (product_name, brand_id, category_id, model_year, list_price)
VALUES (@ProductName, @BrandID, @CategoryID, @ModelYear, @ListPrice);
END

EXEC usp_InsertProduct 
    @ProductName = 'New Mountain Bike',
    @BrandID = 1,
    @CategoryID = 2,
    @ModelYear = 2025,
    @ListPrice = 1299.99;

SELECT * FROM production.products

--4) Create a procedure that lists products with stock quantity less than a threshold in a specific store

CREATE PROC usp_GetLowStock @StoreID INT, @Threshold INT
AS
BEGIN
SELECT product_id, quantity
FROM production.stocks
WHERE store_id = @StoreID AND quantity < @Threshold;
END

EXEC usp_GetLowStock @StoreID = 2, @Threshold = 5

--FUNCTION
--1) Create a scalar function that takes price and discount % and returns the discount amount.

CREATE FUNCTION fn_GetDiscountAmount (@Price DECIMAL(10, 2), @DiscountPercent DECIMAL(5, 2))
RETURNS DECIMAL(10, 2)
AS
BEGIN
RETURN @Price * (@DiscountPercent / 100)
END

SELECT dbo.fn_GetDiscountAmount(1000, 10) AS DiscountAmount

--2) Create a function to return the Full_name name of the staff

CREATE FUNCTION fn_GetStaffFullName (@StaffID INT)
RETURNS TABLE
AS
RETURN 
(
    SELECT staff_id, first_name + ' ' + last_name AS full_name
    FROM sales.staffs
    WHERE staff_id = @StaffID
);

SELECT * FROM fn_GetStaffFullName(3)

--3) Create function to listout all orders placed by customer(id)

CREATE FUNCTION dbo.GetOrdersByCustomer (@CustomerID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM sales.orders
    WHERE customer_id = @CustomerID
);

SELECT * FROM dbo.GetOrdersByCustomer(5)

--4) Create a function to display all product_name and quantity available from the given storeid

CREATE FUNCTION dbo.fn_GetProductsByStore(@StoreID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT p.product_name, s.quantity
    FROM production.products p
    JOIN production.stocks s ON p.product_id = s.product_id
    WHERE s.store_id = @StoreID
);

SELECT * FROM dbo.fn_GetProductsByStore(2)


