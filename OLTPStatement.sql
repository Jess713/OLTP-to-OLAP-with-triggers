-- what is the average salary for a masseur?
SELECT AVG(Salary) FROM Employee WHERE JobTitle = 'Masseur';


-- how many different guests have made a booking?
SELECT COUNT(DISTINCT CustomerID) AS "# of DIFF Guests" FROM CustomerServiceSchedule;

--What is the average expected duration of each customer service
SELECT AVG(ExpectedDuration) AS "average expected duration" FROM CustomerService;

--list the  different services there are.
SELECT  COUNT(DISTINCT(ID)) AS "# of different services" FROM ServiceType;