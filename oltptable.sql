drop table Customer;
drop table Employee;
drop table ServiceType;
drop table CustomerService;
drop table CustomerServiceSchedule;


create table Customer(ID varchar(60), Name varchar(60), Address varchar(60), Birthdate DATE, Picture blob, Gender varchar(10));
create table Employee(ID varchar(60), Name varchar(60), Address varchar(60), ManagerID varchar(60) , JobTitle varchar(60), CertifiedFor varchar(60), StartDate DATE, Salary DECIMAL(30, 2));
create table ServiceType(ID varchar(60), Name varchar(60), CertificationRqts varchar(60), Rate DECIMAL(30, 2));
create table CustomerService(CustomerID varchar(60), ServiceTypeID varchar(60), ExpectedDuration DECIMAL(30)); 
create table CustomerServiceSchedule(ServiceScheduleID varchar(60), CustomerID varchar(60), ServiceTypeID varchar(60), EmployeeID varchar(60), StartDateTime DATE, ActualDuration DECIMAL(30, 0), Status CHAR(1));
set linesize 200;
commit work;