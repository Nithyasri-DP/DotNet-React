use HexaFSD

-- Creating Tables
CREATE TABLE AccountsA (ID INT PRIMARY KEY, Balance DECIMAL(10, 2));
CREATE TABLE AccountsB (ID INT PRIMARY KEY, Balance DECIMAL(10, 2));

-- Inserting Data
INSERT INTO AccountsA VALUES (1, 1000);
INSERT INTO AccountsB VALUES (1, 2000);

-- Displaying Data
SELECT * FROM AccountsA;
SELECT * FROM AccountsB;

-- Simulating DeadLocks
BEGIN TRANSACTION
UPDATE AccountsA SET Balance = Balance - 100 WHERE ID = 1; -- Deduct from AccountsA (A:900)
WAITFOR DELAY '00:00:05'; --simulates processing delay
UPDATE AccountsB SET Balance = Balance + 100 WHERE ID = 1; -- Add to AccountsB (B:2100)
COMMIT

-- New Session
BEGIN TRAN
UPDATE AccountsB SET Balance = Balance - 200 WHERE ID = 1 -- (B:1900)
WAITFOR DELAY '00:00:05';
UPDATE AccountsA SET Balance = Balance + 200 WHERE ID = 1 -- (A:1100)
COMMIT