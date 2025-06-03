use BikeStores


-- TRIGGER
/* 1) Create an AFTER INSERT trigger that updates the inventory count in the products table whenever a new sale is recorded in the sales table.
Create an AFTER INSERT trigger named update_inventory_after_sale.
The trigger should decrease the stock_quantity in the products table based on the quantity sold in the sales table.*/

CREATE TRIGGER update_inventory_after_sale
ON sales.order_items
AFTER INSERT
AS
BEGIN
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM production.stocks s
    JOIN inserted i ON s.product_id = i.product_id
    JOIN sales.orders o ON i.order_id = o.order_id AND s.store_id = o.store_id;
END;

-- Testing trigger
SELECT * FROM production.stocks
WHERE store_id = 1 AND product_id = 1;

-- Insert a test order
INSERT INTO sales.orders (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (1, 1, '2025-06-03', '2025-06-10', NULL, 1, 1);
-- Get the new order ID (to insert in sales.order_items table [ORDER_ID])
SELECT SCOPE_IDENTITY() AS new_order_id;

-- Insert order item (this will activate the trigger) Recheck the table's quantity
INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1617, 2, 1, 2, 2000, 0);


/*2) Create an INSTEAD OF INSERT trigger that prevents the insertion of sales records with a quantity greater than the available stock.
Create an INSTEAD OF INSERT trigger named prevent_invalid_sales_insert.
The trigger should check the stock_quantity in the products table before allowing an insert into the sales table.*/

CREATE TRIGGER prevent_invalid_sales_insert
ON sales.order_items
INSTEAD OF INSERT
AS
BEGIN
       -- Check if any inserted quantity exceeds available stock
    IF EXISTS (SELECT 1 FROM inserted i
        JOIN sales.orders o ON i.order_id = o.order_id
        JOIN production.stocks s ON s.store_id = o.store_id AND s.product_id = i.product_id
        WHERE i.quantity > s.quantity)
    BEGIN
        PRINT 'Cannot insert order item: quantity exceeds available stock'
        RETURN; -- Stops the trigger from inserting anything
    END

    INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
    SELECT order_id, item_id, product_id, quantity, list_price, discount FROM inserted
END

-- Testing trigger

INSERT INTO sales.orders (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (1, 1, '2025-06-03', '2025-06-10', NULL, 1, 1);
-- Get the newly created order ID
SELECT SCOPE_IDENTITY() AS new_order_id;

INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1618, 5, 1, 2, 5000, 0);

SELECT * FROM sales.order_items WHERE order_id = 1618;



/*3) Create an INSTEAD OF DELETE trigger that prevents deletion of a product if it has associated sales records.
Create an INSTEAD OF DELETE trigger named prevent_product_deletion_with_sales.*/

CREATE TRIGGER prevent_product_deletion_with_sales
ON production.products
INSTEAD OF DELETE
AS
BEGIN
    -- Check if any product to be deleted has associated sales records
    IF EXISTS (SELECT 1 FROM deleted d JOIN sales.order_items oi ON d.product_id = oi.product_id)
    BEGIN
        PRINT 'Cannot delete product: it has associated sales records'
        RETURN -- Prevent deletion
    END

    -- If no associated sales then proceeds with deletion
    DELETE FROM production.products
    WHERE product_id IN (SELECT product_id FROM deleted)
END

/*4) Assignment 1 :Write a transaction to:
Reduce the quantity of a product (product_id = 101) by 2 in the stocks table (for store_id = 1).
Commit the transaction only if the quantity does not go negative. 
Simulate a customer purchasing a bike. Insert an order and a corresponding order_item.
Rollback if the product is out of stock.*/

SELECT * FROM production.stocks
WHERE product_id = 81 AND store_id = 3 --Checking availability

BEGIN TRANSACTION
DECLARE @productId INT = 81
DECLARE @storeId INT = 3
DECLARE @quantityToReduce INT = 2
DECLARE @currentStock INT

SELECT @currentStock = quantity
FROM production.stocks
WHERE product_id = @productId AND store_id = @storeId;

IF @currentStock IS NULL
BEGIN
    PRINT 'No stock, Transaction rolled back'
    ROLLBACK TRANSACTION
    RETURN
END

IF @currentStock < @quantityToReduce
BEGIN
    PRINT 'Insufficient stock, Transaction rolled back'
    ROLLBACK TRANSACTION
    RETURN
END

UPDATE production.stocks SET quantity = quantity - @quantityToReduce WHERE product_id = @productId AND store_id = @storeId;

INSERT INTO sales.orders (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (1, 1, GETDATE(), DATEADD(day, 7, GETDATE()), NULL, @storeId, 1);

INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES ((SELECT MAX(order_id) FROM sales.orders), 1, @productId, @quantityToReduce, 500, 0)

COMMIT TRANSACTION
PRINT 'Purchase completed successfully'

