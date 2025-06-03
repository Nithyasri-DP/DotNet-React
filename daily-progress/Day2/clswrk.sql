use HexaFSD

-- Create the tblEmployee table
CREATE TABLE tblEmployee
(
    Id int PRIMARY KEY,
    Name nvarchar(30),
    Salary int,
    Gender nvarchar(10),
    DepartmentId int
);

-- Insert data into tblEmployee table
INSERT INTO tblEmployee
VALUES 
(1, 'Parivalavan', 5000, 'Male', 3),
(2, 'Alhan', 3400, 'Male', 2),
(3, 'Vedhitha', 6000, 'Female', 1);

-- Select data from tblEmployee table
SELECT * FROM tblEmployee;

-- Create the tblEmployeeAudit table
CREATE TABLE tblEmployeeAudit
(
    Id int PRIMARY KEY IDENTITY(1,1),
    AuditData varchar(MAX)
);

-- Select data from tblEmployeeAudit table
SELECT * FROM tblEmployeeAudit;

--TRIGGER
-- Create Trigger(INSERT)
CREATE TRIGGER tr_tblEmployee_insert
ON tblEmployee
FOR INSERT
AS
BEGIN
DECLARE @Id INT
SELECT @Id = Id FROM inserted
INSERT INTO tblEmployeeAudit 
VALUES ('New Employee with Id=' + CAST(@Id AS VARCHAR(5)) + ' is added at ' + CAST(GETDATE() AS NVARCHAR(20)))
END;

SELECT * FROM tblEmployee;
SELECT * FROM tblEmployeeAudit;

INSERT INTO tblEmployee VALUES (4, 'Santo', 4554, 'Male', 2);

-- Create Trigger(DELETE)
CREATE TRIGGER tr_tblEmployee_delete
ON tblEmployee
FOR DELETE
AS
BEGIN
DECLARE @Id INT
SELECT @Id = Id FROM deleted
INSERT INTO tblEmployeeAudit 
VALUES ('Employee with the Id=' + CAST(@Id AS VARCHAR(5)) + ' deleted at ' + CAST(GETDATE() AS VARCHAR(20)))
END

DELETE FROM tblEmployee WHERE ID = 4

-- Create Trigger(UPDATE)
CREATE TRIGGER tr_tblEmployee_update
ON tblEmployee
FOR UPDATE
AS
BEGIN
    -- Declare variables to hold old and updated data
    DECLARE @Id INT;
    DECLARE @OldName NVARCHAR(20), @NewName NVARCHAR(20);
    DECLARE @OldSalary INT, @NewSalary INT;
    DECLARE @OldGender NVARCHAR(20), @NewGender NVARCHAR(20);
    DECLARE @OldDeptId INT, @NewDeptId INT;

    -- Variable to build the audit string
    DECLARE @AuditString NVARCHAR(1000);

    -- Load the updated records into temporary table
    SELECT * INTO #TempTable FROM inserted;

    -- Loop thru the records in temp table 
    WHILE (EXISTS (SELECT Id FROM #TempTable))
    BEGIN
        --Initialize the audit string to empty string
        Set @AuditString = ' '

        -- Select first row data from temp table
        SELECT TOP 1
            @Id = Id,
            @NewName = Name,
            @NewGender = Gender,
            @NewSalary = Salary,
            @NewDeptId = DepartmentId
        FROM #TempTable;

        -- Select the corresponding row from deleted table
        SELECT 
            @OldName = Name, 
            @OldGender = Gender, 
            @OldSalary = Salary, 
            @OldDeptId = DepartmentId
        FROM deleted 
        WHERE Id = @Id;

        -- Initialize the audit string
        SET @AuditString = 'Employee with Id=' + CAST(@Id AS NVARCHAR(4)) + ' changed '

        -- Build the audit string dynamically
        IF (@OldName <> @NewName)
            SET @AuditString = @AuditString + ' NAME from ' +  @OldName + ' to ' + @NewName
        IF (@OldGender <> @NewGender)
            SET @AuditString = @AuditString + ' GENDER from ' + @OldGender + ' to ' + @NewGender 
        IF (@OldSalary <> @NewSalary)
            SET @AuditString = @AuditString + ' SALARY from ' + CAST(@OldSalary AS NVARCHAR(10)) + ' to ' + CAST(@NewSalary AS NVARCHAR(10))
        IF (@OldDeptId <> @NewDeptId)
            SET @AuditString = @AuditString + ' DEPARTMENTID from ' + CAST(@OldDeptId AS NVARCHAR(10)) + ' to ' + CAST(@NewDeptId AS NVARCHAR(10))

        -- Insert audit string into audit table
        INSERT INTO tblEmployeeAudit VALUES (@AuditString)

        -- Delete the row from temp table, so we can move to the next row
        DELETE FROM #TempTable WHERE Id = @Id
    END
END

SELECT * FROM tblEmployee;
SELECT * FROM tblEmployeeAudit;

UPDATE tblEmployee SET NAME = 'Peter', GENDER = 'Male', SALARY = 4500 WHERE Id=1

-- Create Trigger(Instead of dropping)
CREATE TRIGGER trg_PreventDropEmployee
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
DECLARE @eventData XML = EVENTDATA();
IF @eventData.value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(128)') = 'Employee'
    BEGIN
    PRINT 'Dropping the Employee table is not allowed'
    ROLLBACK
    END
END

-- Checking the trigger
SELECT * FROM Employee
DROP TABLE Employee

-- TRANSACTION
-- Creating new tables 
CREATE TABLE Customers 
(
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Balance DECIMAL(10, 2)
);

CREATE TABLE Products 
(
    ProductID INT PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10, 2),
    StockQuantity INT
);

CREATE TABLE Orders 
(
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10, 2),
    Status VARCHAR(20)
);

INSERT INTO Customers VALUES 
(1, 'Anu', 'anu@gmail.com', 5000),
(2, 'Shreya', 'shreya@gmail.com', 4000);

INSERT INTO Products VALUES 
(1, 'Pendrive', 500, 10),
(2, 'Laptop', 15000, 5);


BEGIN TRANSACTION

-- Check if product is in stock and customer has enough balance
IF EXISTS 
(
    SELECT 1 FROM Products p, Customers c
    WHERE p.ProductID = 1 AND p.StockQuantity >= 1
    AND c.CustomerID = 1 AND c.Balance >= 299
)
BEGIN
    -- Update product stock
    UPDATE Products SET StockQuantity = StockQuantity - 1
    WHERE ProductID = 1;

    -- Update customer balance
    UPDATE Customers SET Balance = Balance - 299
    WHERE CustomerID = 1;

    -- Insert order
    INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount, Status)
    VALUES (101, 1, GETDATE(), 299, 'Completed');

    COMMIT TRANSACTION
    PRINT 'Order processed successfully'
END
ELSE
BEGIN
    ROLLBACK TRANSACTION
    PRINT 'Order failed: Not enough stock or insufficient balance'
END


