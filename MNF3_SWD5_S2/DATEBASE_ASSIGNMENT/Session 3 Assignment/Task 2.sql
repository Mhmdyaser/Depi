use StoreDB

--List all products with list price greater than 1000
SELECT*FROM production.products P
WHERE P.list_price>1000

--Get customers from "CA" or "NY" states
SELECT * FROM sales.customers C
WHERE C.state = 'CA' OR C.state = 'NY';

SELECT * FROM sales.customers C
WHERE C.state IN ('CA', 'NY')

--Retrieve all orders placed in 2023
SELECT * FROM sales.orders O
WHERE O.order_date ='2023'

--Show customers whose emails end with @gmail.com
SELECT * FROM sales.customers C
WHERE C.email LIKE '%@gmail.com'

--Show all inactive staff
SELECT * FROM sales.staffs S
WHERE S.active IS NULL

--List top 5 most expensive products
SELECT TOP 5 * FROM production.products P
ORDER BY P.list_price DESC

--Show latest 10 orders sorted by date
SELECT * FROM sales.orders O
ORDER BY O.order_date DESC
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY

--Retrieve the first 3 customers alphabetically by last name
SELECT * FROM sales.customers C
ORDER BY C.last_name ASC
OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY

--Find customers who did not provide a phone number
SELECT * FROM sales.customers C
WHERE C.phone IS NULL 

--Show all staff who have a manager assigned
SELECT * FROM sales.staffs S
WHERE S.manager_id IS NOT NULL

--Count number of products in each category
SELECT P.product_name,P.category_id  , COUNT(*) Number_Of_Products 
FROM production.products P
GROUP BY P.product_name,P.category_id

--Count number of customers in each state
SELECT C.state , COUNT(*) Number_Of_Customers
FROM sales.customers C
GROUP BY C.state 

--Get average list price of products per brand
SELECT P.brand_id , AVG(P.LIST_PRICE) AVG_PRICE
FROM production.products P
GROUP BY P.brand_id

--Show number of orders per staff
SELECT O.staff_id,COUNT(O.order_id) Number_Of_Orders
FROM sales.orders O
GROUP BY O.staff_id

--Find customers who made more than 2 orders
SELECT O.customer_id,COUNT(O.order_id) Number_Of_Orders
FROM sales.orders O
GROUP BY O.customer_id
HAVING COUNT(O.order_id)>2

--Products priced between 500 and 1500
SELECT P.product_name , P.list_price
FROM production.products P
WHERE P.list_price BETWEEN 500 AND 1500 

--Customers in cities starting with "S"
SELECT C.first_name,C.last_name,C.city 
FROM sales.customers C
WHERE C.city LIKE 'S%'

--Orders with order_status either 2 or 4
SELECT * FROM sales.orders O 
WHERE O.order_status IN (2, 4)

--Products from category_id IN (1, 2, 3)
SELECT * FROM production.products P
WHERE P.category_id IN (1,2,3)

--Staff working in store_id = 1 OR without phone number
SELECT * FROM sales.staffs S
WHERE S.store_id='1' OR S.phone IS NULL




