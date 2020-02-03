insert into Customer(ID, Name, Address, Birthdate, Gender) values ('C001', 'Garth Dancer', 'Burnaby',TO_DATE('1980/05/07', 'yyyy/mm/dd'), 'M');

insert into Customer(ID, Name, Address, Birthdate, Gender) values ('C002', 'Jason Jordan', 'Burnaby',TO_DATE('1985/05/03', 'yyyy/mm/dd'), 'M');

insert into Customer(ID, Name, Address, Birthdate, Gender) values ('C005', 'Jay world', 'New Westminster',TO_DATE('1981/02/01', 'yyyy/mm/dd'), 'M');

insert into Customer(ID, Name, Address, Birthdate, Gender) values ('C003', 'Marlys Smith', 'Vancouver',TO_DATE('1989/05/31', 'yyyy/mm/dd'), 'M');

insert into Customer(ID, Name, Address, Birthdate, Gender) values ('C004', 'Jim Halpert', 'Vancouver',TO_DATE('1981/08/09', 'yyyy/mm/dd'), 'M');



insert into Employee(ID, Name, Address, ManagerID, JobTitle, CertifiedFor, StartDate, Salary) values ('A987', 'Wayne R Spencer', 'Richmond', 'A001', 'Masseur', 'Back master',TO_DATE('2009/01/04', 'yyyy/mm/dd'), 4100.00);

insert into Employee(ID, Name, Address, JobTitle, CertifiedFor, StartDate, Salary) values ('A002', 'Brendon Ken', 'Richmond', 'Manager', 'Face master',TO_DATE('2002/01/31', 'yyyy/mm/dd'), 8000.20);

insert into Employee(ID, Name, Address, JobTitle, CertifiedFor, StartDate, Salary) values ('A001', 'Pamela Fine', 'North Vancouver', 'Manager', 'Shoulder master',TO_DATE('2001/02/04', 'yyyy/mm/dd'), 8000.20);

insert into Employee(ID, Name, Address, ManagerID, JobTitle, CertifiedFor, StartDate, Salary) values ('A999', 'Robert Carpenter', 'New Westminster', 'A002', 'Masseur', 'Shoulder master',TO_DATE('2009/01/04', 'yyyy/mm/dd'), 4000.20);

insert into Employee(ID, Name, Address, ManagerID, JobTitle, CertifiedFor, StartDate, Salary) values ('A900', 'Kevin Kim', 'Delta', 'A001', 'Masseur', 'Foot master',TO_DATE('2009/01/04', 'yyyy/mm/dd'), 5200.20);


insert into ServiceType(Id, Name, CertificationRqts, Rate) values ('S001', 'Foot massage', 'Foot master', 100.00);

insert into ServiceType(Id, Name, CertificationRqts, Rate) values ('S002', 'Shoulder massage', 'Shoulder master', 150.00);

insert into ServiceType(Id, Name, CertificationRqts, Rate) values ('S003', 'Face massage', 'Face master', 125.25);

insert into ServiceType(Id, Name, CertificationRqts, Rate) values ('S004', 'Back massage', 'Back master', 99.00);

insert into ServiceType(Id, Name, CertificationRqts, Rate) values ('S005', 'Body massage', 'Body master', 120.00);


insert into CustomerService (CustomerID, ServiceTypeID, ExpectedDuration) values('C001', 'S001', 60);

insert into CustomerService (CustomerID, ServiceTypeID, ExpectedDuration) values('C002', 'S002', 90);


insert into CustomerService (CustomerID, ServiceTypeID, ExpectedDuration) values('C003', 'S003', 60);


insert into CustomerService (CustomerID, ServiceTypeID, ExpectedDuration) values('C004', 'S004', 120);


insert into CustomerService (CustomerID, ServiceTypeID, ExpectedDuration) values('C005', 'S005', 120);

insert into CustomerServiceSchedule(ServiceScheduleID, CustomerId, ServiceTypeID, EmployeeID, StartDateTime, ActualDuration, Status) values('SC001','C001','S001', 'A987', TO_DATE('2019/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'), 75, 'Y'); 

insert into CustomerServiceSchedule(ServiceScheduleID, CustomerId, ServiceTypeID, EmployeeID, StartDateTime, ActualDuration, Status) values('SC002','C002','S002', 'A900', TO_DATE('2019/11/02 19:00:01', 'yyyy/mm/dd hh24:mi:ss'), 100, 'Y'); 

insert into CustomerServiceSchedule(ServiceScheduleID, CustomerId, ServiceTypeID, EmployeeID, StartDateTime, ActualDuration, Status) values('SC003','C003','S003', 'A900', TO_DATE('2019/12/02 18:00:01', 'yyyy/mm/dd hh24:mi:ss'), 130, 'Y'); 

insert into CustomerServiceSchedule(ServiceScheduleID, CustomerId, ServiceTypeID, EmployeeID, StartDateTime, Status) values('SC004','C004','S003', 'A999', TO_DATE('2020/04/01 19:00:01', 'yyyy/mm/dd hh24:mi:ss'), 'N'); 

insert into CustomerServiceSchedule(ServiceScheduleID, CustomerId, ServiceTypeID, EmployeeID, StartDateTime, Status) values('SC005','C005','S001', 'A001', TO_DATE('2020/04/18 19:00:01', 'yyyy/mm/dd hh24:mi:ss'), 'N'); 

commit work;




