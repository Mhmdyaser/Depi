
# 📄 README – SQL Assignment 4

## 📁 Database Used:
- **Database Name:** `StoreDB`

## 🧠 Assignment Summary:
This SQL assignment includes 20 tasks designed to test and demonstrate your ability to:
- Query and manipulate data using aggregate functions
- Perform joins between related tables
- Create and use views
- Use subqueries and filtering conditions
- Format output and extract specific data

## ✅ Tasks Overview:

1. **Count total number of products**  
2. **Calculate average, minimum, and maximum product prices**  
3. **Count products per category (with and without join)**  
4. **Count total orders per store (with and without join)**  
5. **Display first names in UPPERCASE and last names in lowercase (Top 10 customers)**  
6. **Get product name lengths (Top 10 products)**  
7. **Extract area code (first 3 digits) from customer phone numbers (Top 15 customers)**  
8. **Display current date and extract year/month from order dates (Top 10 orders)**  
9. **Join products with categories (Top 10 products)**  
10. **Join customers with their orders (Top 10 orders)**  
11. **Show products with brand names; display 'No Brand' if missing**  
12. **Find products priced above average**  
13. **Find customers who placed at least one order (using subquery with IN)**  
14. **Show total number of orders per customer (using subquery in SELECT)**  
15. **Create a view `easy_product_list` and query products with price > 100**  
16. **Create a view `customer_info` and list customers from California (CA)**  
17. **Find products priced between $50 and $200 ordered by price**  
18. **Count customers per state, ordered from highest to lowest**  
19. **Find most expensive product in each category**  
20. **List all stores with their cities and order count (including stores with no orders)**

## 🛠️ Notes:
- Views were created using `CREATE OR ALTER` to avoid errors if they already exist.
- `LEFT JOIN` was used where appropriate to include all records (e.g., all stores even if no orders).
- Subqueries were used both in `WHERE` and `SELECT` clauses to practice multiple styles.
- String functions (`CONCAT`, `UPPER`, `LOWER`, `LEFT`) were used for formatting.

## 👨‍💻 Author:
- **Prepared by:** Mohamed Yaser Salah Elnagar 
- **Assignment Title:** Assignment 4 – SQL Practice on StoreDB  
- **Tools:** SQL Server
