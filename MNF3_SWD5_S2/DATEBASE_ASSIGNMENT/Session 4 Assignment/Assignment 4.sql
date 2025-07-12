use StoreDB
go

---------------------------------------

--1. Count the total number of products in the database
SELECT COUNT(*) Total_Products
FROM production.products P


--2. Find the average, minimum, and maximum price of all products
SELECT AVG(P.list_price) AVG_PRICE, MIN(P.list_price) MIN_PRICE,MAX(P.list_price) MAX_PRICE
FROM production.products P


--3. Count how many products are in each category.
SELECT P.category_id,COUNT(*) ProductCount
FROM production.products P
GROUP BY P.category_id

SELECT C.category_name,COUNT(P.product_id) ProductCount
FROM production.products P
JOIN production.categories C ON P.category_id = C.category_id
GROUP BY C.category_name


--4. Find the total number of orders for each store.
SELECT O.store_id, COUNT(O.order_id) TotalOrders
FROM sales.orders O
GROUP BY O.store_id

SELECT S.store_name , COUNT(O.order_id) TotalOrders
FROM sales.orders O JOIN sales.stores S 
ON O.store_id=S.store_id
GROUP BY S.store_name

--5. Show customer first names in UPPERCASE and last names in lowercase for the first 10 customers
SELECT TOP 10 UPPER(C.first_name) FirstName, LOWER(C.last_name) LastName
FROM sales.customers C


--6. Get the length of each product name. Show product name and its length for the first 10 products.
SELECT P.product_name, LEN(P.product_name) Name_Length
FROM production.products P
ORDER BY P.product_id
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY


--7. Format customer phone numbers to show only the area code (first 3 digits) for customers 1-15.
SELECT TOP 15  CONCAT(C.first_name,' ',C.last_name) FULL_NAME,
LEFT(C.phone, 3) Area_Code
FROM sales.customers C

--8. Show the current date and extract the year and month from order dates for orders 1-10.
SELECT TOP 10 O.order_id,O.order_date,GETDATE() CURRENT_DATA ,
YEAR(O.order_date) YEAR_ORDER , MONTH(O.order_date) MONTH_ORDER
FROM sales.orders O

--9. Join products with their categories. Show product name and category name for first 10 products.
SELECT TOP 10 P.product_name,C.category_name 
FROM production.products P
JOIN production.categories C ON P.category_id = C.category_id

--10. Join customers with their orders. Show customer name and order date for first 10 orders
SELECT TOP 10 CONCAT(C.first_name,' ',C.last_name) customer_name ,O.order_date
FROM sales.customers C JOIN sales.orders O
ON C.customer_id=O.customer_id


--11. Show all products with their brand names, even if some products don't have brands. Include product name, brand name (show 'No Brand' if null).
SELECT P.product_name, ISNULL(B.brand_name, 'No Brand') Brand_Name
FROM production.products P LEFT JOIN production.brands B 
ON P.brand_id = B.brand_id

--12. Find products that cost more than the average product price. Show product name and price.
SELECT P.product_name,P.list_price
FROM production.products P
WHERE P.list_price > (SELECT AVG(P.list_price)
FROM production.products P )

--13. Find customers who have placed at least one order. Use a subquery with IN. Show customer_id and customer_name.
SELECT customer_id, CONCAT(C.first_name,' ',C.last_name) customer_name
FROM sales.customers C
WHERE customer_id IN (
    SELECT  O.customer_id
    FROM sales.orders O )

--14. For each customer, show their name and total number of orders using a subquery in the SELECT clause.
SELECT CONCAT(c.first_name, ' ', c.last_name) customer_name,
(SELECT COUNT(*) 
FROM sales.orders o WHERE O.customer_id = C.customer_id) total_orders
FROM sales.customers C 

--15. Create a simple view called easy_product_list that shows product name, category name, and price. 
CREATE OR ALTER VIEW easy_product_list AS
SELECT  P.product_name, C.category_name, P.list_price
FROM production.products P JOIN production.categories C
ON P.category_id = C.category_id
--Then write a query to select all products from this view where price > 100.
SELECT * FROM easy_product_list
WHERE list_price>100

--16. Create a view called customer_info that shows customer ID, full name (first + last), email, and city and state combined.
CREATE OR ALTER VIEW customer_info AS
SELECT CONCAT(C.first_name, ' ', C.last_name) full_name,C.email,
CONCAT(C.city, ' ', C.state) LOCATION
FROM sales.customers C 
--Then use this view to find all customers from California (CA).
SELECT * FROM customer_info 
 WHERE location LIKE '%CA'

 --17. Find all products that cost between $50 and $200. Show product name and price, ordered by price from lowest to highest.
SELECT P.product_name,P.list_price
FROM production.products P
WHERE P.list_price BETWEEN 50 AND 200
ORDER BY list_price ASC

--18. Count how many customers live in each state. Show state and customer count, ordered by count from highest to lowest.
SELECT C.state,COUNT(*) customer_count
FROM sales.customers C
GROUP BY C.state
ORDER BY customer_count DESC

--19. Find the most expensive product in each category. Show category name, product name, and price.
SELECT C.category_name,P.product_name,P.list_price
FROM production.products P
JOIN production.categories C 
ON P.category_id = C.category_id
WHERE P.list_price = (
    SELECT MAX(P1.list_price)
    FROM production.products P1
    WHERE P1.category_id = P.category_id
)

--20. Show all stores and their cities, including the total number of orders from each store. Show store name, city, and order count.
SELECT S.store_name,S.city,COUNT(O.order_id) order_count
FROM sales.stores S  LEFT JOIN sales.orders O
ON S.store_id = O.store_id
GROUP BY S.store_name, S.city












