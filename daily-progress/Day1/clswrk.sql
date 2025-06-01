CREATE DATABASE HexaFSD

USE HexaFSD

CREATE TABLE Employee (
    id INT IDENTITY(101,1),
    name VARCHAR(25),
    gender VARCHAR(10),
    location VARCHAR(25),
    doj DATE,
    salary MONEY
);

INSERT INTO Employee (name, gender, location, doj, salary)
VALUES 
('Akkshara', 'female', 'chennai', '2022-01-10', 50000),
('Hariharan', 'male', 'bangalore', '2021-11-20', 55000),
('Alhan', 'male', 'hyderabad', '2023-03-15', 48000),
('Arun', 'male', 'mumbai', '2020-09-05', 60000),
('Geethica', 'female', 'delhi', '2021-12-12', 53000),
('Nithyasri', 'female', 'coimbatore', '2022-07-01', 51000);

-- STORED PROCEDURE
-- Create Stored Procedure to Get All Employees
CREATE PROCEDURE usp_GetAllEmployee
AS
BEGIN
SELECT * FROM Employee;
END

-- Execute Procedure
EXEC usp_GetAllEmployee;

-- Alter Procedure to Filter by Gender = 'female'
ALTER PROCEDURE usp_GetAllEmployee
AS
BEGIN
SELECT * FROM Employee WHERE gender = 'female';
END

-- Execute Altered Procedure
EXEC usp_GetAllEmployee;

-- Create Stored Procedure with Input Parameters
CREATE PROCEDURE usp_GetAllEmployeeGenderLocation @gender VARCHAR(10), @location VARCHAR(25)
AS
BEGIN
SELECT * FROM Employee WHERE gender = @gender AND location = @location;
END

-- Execute Procedure with Positional Parameters
EXEC usp_GetAllEmployeeGenderLocation 'female', 'chennai';

-- Execute Procedure with Named Parameters
EXEC usp_GetAllEmployeeGenderLocation @gender = 'female', @location = 'coimbatore';

-- Alter Procedure to Use Default Parameter for Gender
ALTER PROCEDURE usp_GetAllEmployeeGenderLocation @gender VARCHAR(10) = 'MALE', @location VARCHAR(25) = 'bangalore'
AS
BEGIN
SELECT * FROM Employee WHERE gender = @gender AND location = @location;
END;

-- Execute Procedure with Both Parameters
EXEC usp_GetAllEmployeeGenderLocation 'female', 'chennai';

-- Execute Procedure Using Default Gender
EXEC usp_GetAllEmployeeGenderLocation @location = 'mumbai';

-- Create Procedure to Add a New User
CREATE PROCEDURE usp_AddNewUser @name VARCHAR(20), @gender VARCHAR(10), @location VARCHAR(20)
AS
BEGIN
INSERT INTO Employee(name, gender, location)
VALUES (@name, @gender, @location);
END

-- Execute Procedure to Add New User
EXEC usp_AddNewUser @name = 'Harsha', @gender = 'female', @location = 'mumbai';

-- View Final Data
SELECT * FROM Employee;

-- Create stored procedure to print total number of employees based on location
CREATE PROCEDURE usp_GetEmpCount @location VARCHAR(20), @EmpCount INT OUT
AS
BEGIN
SELECT @EmpCount = COUNT(*) FROM Employee WHERE location = @location;
END;

-- Declare variable and execute the procedure
DECLARE @count INT
EXEC usp_GetEmpCount 'coimbatore', @count OUT 
SELECT @count AS Emp_count;


-- FUNCTION
-- Create a scalar function to calculate 10% bonus
CREATE FUNCTION DBO.CALCULATEBONUS (@SALARY DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
RETURN @SALARY * 0.10;
END

-- Select employee data with bonus calculation
SELECT ID, NAME, GENDER, LOCATION, SALARY, DBO.CALCULATEBONUS(SALARY) AS BONUS
FROM EMPLOYEE;

-- Inline table-valued function
CREATE FUNCTION dbo.GetEmployeeDetailsByLocation (@location VARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT id, name, gender, location FROM Employee WHERE location = @location);

-- Calling the function in a select statement
SELECT * FROM dbo.GetEmployeeDetailsByLocation('Bangalore');


-- Create multi-statement table-valued function
CREATE FUNCTION dbo.HighSalaryEmployee (@avgsalary DECIMAL(10,2))
RETURNS @HighEarners TABLE (id INT, name VARCHAR(20), salary DECIMAL(10,2))
AS
BEGIN
INSERT INTO @HighEarners
SELECT id, name, salary FROM Employee
WHERE salary > @avgsalary;
RETURN
END
GO
-- Calling the function in a select statement
SELECT * FROM dbo.HighSalaryEmployee(50000);

