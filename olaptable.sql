drop table CustomerDim;
drop table EmployeeDim;
drop table ServiceTypeDim;
drop table CustomerServiceScheduleFact;
drop table AddressDim;

create table CustomerDim(ID varchar(60), Name varchar(60), Address varchar(60), Gender varchar(10));
create table EmployeeDim(ID varchar(60), Name varchar(60), Address varchar(60), JobTitle varchar(60), CertifiedFor varchar(60), StartDate DATE, Salary DECIMAL(30, 2));
create table ServiceTypeDim(ID varchar(60), Name varchar(60), CertificationRqts varchar(60), Rate DECIMAL(30, 2));
create table CustomerServiceScheduleFact(ServiceScheduleID varchar(60), AddressID varchar(60), CustomerID varchar(60), ServiceTypeID varchar(60), EmployeeID varchar(60), Year varchar(60), Month varchar(60), ActualDuration DECIMAL(30, 0), Status CHAR(1));
create table AddressDim(AddressID varchar(60), Address varchar(60));
set linesize 200;
commit work;