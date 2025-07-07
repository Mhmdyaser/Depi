CREATE DATABASE COMPANY
USE  COMPANY 

-----------------------------------------------------------

--Create the EMPLOYEE table 
CREATE  TABLE EMPLOYEE (
    Ssn INT PRIMARY KEY,
    Birth_Date DATE NOT NULL,
    Gender CHAR(1) CHECK (Gender IN ('M', 'F')) NOT NULL,
    Lname VARCHAR(50),
    Fname VARCHAR(50),
    DNUM INT,
    supervisor_Ssn INT
    FOREIGN KEY (supervisor_Ssn) REFERENCES EMPLOYEE(Ssn)
	)


	--Create the DEPARTMENT Table 
	CREATE  TABLE DEPARTMENT (
    DNUM INT PRIMARY KEY,
    DName VARCHAR(50) NOT NULL UNIQUE,
    hiringDate DATE,
    Ssn INT
    
)

--Add foreign key constraints between table EMPLOYEE , DEPARTMENT
ALTER TABLE EMPLOYEE
ADD CONSTRAINT FK_DNUM
FOREIGN KEY (DNUM) REFERENCES DEPARTMENT(DNUM)

--Add foreign key constraints between table DEPARTMENT , EMPLOYEE
ALTER TABLE DEPARTMENT
ADD CONSTRAINT FK_Ssn
FOREIGN KEY (Ssn) REFERENCES EMPLOYEE(Ssn)

--Create the PROJECT table
  CREATE TABLE PROJECT(
   PNumber INT PRIMARY KEY,
    Pname VARCHAR(50),
    Location_City VARCHAR(50) DEFAULT 'Cairo',
    DNUM INT
	FOREIGN KEY (DNUM) REFERENCES DEPARTMENT(DNUM)
)


--Create the DEPENDENTS Table
    CREATE TABLE DEPENDENTS (
    Name VARCHAR(50),
    Gender VARCHAR(15),
    Birth_date DATE,
    Ssn INT
	 FOREIGN KEY (Ssn) REFERENCES EMPLOYEE(Ssn)
	)

--Create the WORK Table
    CREATE TABLE Work (
    Ssn INT,
    PNumber INT,
    working_hours INT,
    PRIMARY KEY (Ssn, PNumber),
    FOREIGN KEY (Ssn) REFERENCES EMPLOYEE(Ssn),
    FOREIGN KEY (PNumber) REFERENCES PROJECT(PNumber)
)

--Create the Departments_Locations Table
    CREATE TABLE Departments_Locations (
    location VARCHAR(100),
    DNUM INT,
    FOREIGN KEY (DNUM) REFERENCES DEPARTMENT(DNUM)
)

-- Insert sample departments
INSERT INTO DEPARTMENT (DNUM, DName, hiringDate, Ssn)
VALUES 
(101, 'HR', '2020-01-10', 1),         
(102, 'IT', '2019-06-01', 2),
(103, 'Finance', '2021-03-15', 3)

-- Insert sample employees
INSERT INTO EMPLOYEE (Ssn, Birth_Date, Gender,Fname,Lname, DNUM, supervisor_Ssn)
VALUES 
(1, '2004-02-27', 'Male', 'Mohamed', 'Yaser', 101, 2),       
(2, '1985-05-12', 'Female', 'Sara', 'Hassan', 101, 1),
(3, '1992-08-20', 'Male', 'Kareem', 'Mostafa', 102, 1),     
(4, '1988-11-11', 'Female', 'Laila', 'Youssef', 103, 3),    
(5, '1995-09-09', 'Male', 'Omar', 'Nabil', 102, 3)

-- Insert sample project
INSERT INTO PROJECT VALUES (201, 'Payroll System', 'Cairo', 103)
INSERT INTO PROJECT VALUES (202, 'Website Redesign', 'Alexandria', 102)
INSERT INTO PROJECT VALUES (203, 'Employee Training', 'Cairo', 101)

-- Insert sample work
INSERT INTO Work VALUES (1, 203, 10)
INSERT INTO Work VALUES (2, 203, 15)
INSERT INTO Work VALUES (3, 202, 20)

-- Insert sample Departments_Locations
INSERT INTO Departments_Locations VALUES ('Cairo', 101)
INSERT INTO Departments_Locations VALUES ('Alexandria', 102)
INSERT INTO Departments_Locations VALUES ('Giza', 103)

--Insert sample DEPENDENTS
INSERT INTO DEPENDENTS (Name, Gender, Birth_date, Ssn)
VALUES 
('Omar', 'Male', '2015-06-01', 2),        
('Nada', 'Female', '2010-09-10', 3),       
('Hana', 'Female', '2012-04-20', 4),       
('Youssef', 'Male', '2018-12-15', 5)    

---------------------------------------------------------------------------------------

--Update an employee's department
UPDATE EMPLOYEE
SET DNUM = 102
WHERE Ssn = 1

--Delete a dependent record
DELETE FROM DEPENDENTS
WHERE Name = 'Hana'

--Adding a new column
ALTER TABLE EMPLOYEE
ADD Email VARCHAR(50) unique

--Dropping an existing constrain
ALTER TABLE EMPLOYEE
DROP CONSTRAINT FK_DNUM







