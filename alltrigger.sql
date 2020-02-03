CREATE OR REPLACE TRIGGER scheduletrigger AFTER INSERT OR UPDATE ON CustomerServiceSchedule FOR EACH ROW
BEGIN
    IF INSERTING THEN
        INSERT INTO CustomerServiceScheduleFact (
            servicescheduleid,
            customerid,
            servicetypeid,
            employeeid,
            year,
            month,
            actualduration,
            status)
        VALUES (
            :new.servicescheduleid,
            :new.customerid, 
            :new.servicetypeid,
            :new.employeeid,
            extract(year from to_date(:new.startdatetime, 'yy-mm-dd')),
            extract(month from to_date(:new.startdatetime, 'yy-mm-dd')),
            :new.actualduration, 
            :new.status);
    ELSIF UPDATING THEN
        UPDATE CustomerServiceScheduleFact SET
            servicescheduleid = :new.servicescheduleid,
            customerid = :new.customerid,
            servicetypeid = :new.servicetypeid,
            employeeid = :new.employeeid,
            year = extract(year from to_date(:new.startdatetime, 'yy-mm-dd')),
            month = extract(month from to_date(:new.startdatetime, 'yy-mm-dd')),
            actualduration = :new.actualduration,
            status = :new.status;
    END IF;            
END;
/

CREATE OR REPLACE TRIGGER employeeTrigger AFTER INSERT OR UPDATE ON Employee FOR EACH ROW
BEGIN
    IF INSERTING THEN
        INSERT INTO EmployeeDim (
            ID,
            Name,
            Address,
            JobTitle,
            CertifiedFor,
            StartDate,
            Salary)
        VALUES (
            :new.ID,
            :new.Name,
            :new.Address,
            :new.JobTitle,
            :new.CertifiedFor,
            :new.StartDate,
            :new.Salary
        );
    ELSIF UPDATING THEN
        UPDATE EmployeeDim SET
            ID = :new.ID,
            Name = :new.Name,
            Address = :new.Address,
            JobTitle = :new.JobTitle,
            CertifiedFor = :new.CertifiedFor,
            StartDate = :new.StartDate,
            Salary = :new.Salary;
    END IF;
END;
/

create or replace trigger customer_update_trigger
before 
insert or update
on Customer
for each row
begin
    if inserting then
    insert into CustomerDim  (
        ID,
        Name,
        Address,
        Gender
        )
    values (
        :new.ID,
        :new.Name,
        :new.Address,
        :new.Gender
    );
    elsif updating then
        update CustomerDim set 
        ID = :new.ID,
        Name = :new.Name,
        Address = :new.Address,
        Gender = :new.Gender;
    end if;
end;
/

create or replace trigger servicetrigger
before 
insert or update
on ServiceType
for each row
begin
    if inserting then
    insert into ServiceTypeDim  (
        ID,
        Name,
        CertificationRqts,
        Rate
        )
    values (
        :new.ID,
        :new.Name,
        :new.CertificationRqts,
        :new.Rate
    );
    elsif updating then
        update ServiceTypeDim set 
        ID = :new.ID,
        Name = :new.Name,
        CertificationRqts = :new.CertificationRqts,
        Rate = :new.Rate;
    end if;
end;
/

create or replace trigger addresstrigger
before
insert or update
on customer
for each row
begin
    if inserting then
        delete from addressdim;
        insert into addressdim
            select address, count(address) from customer group by address;
    elsif updating then
        delete from addressdim;
        insert into addressdim
            select address, count(address) from customer group by address;
    end if;
end;
/


SHOW ERRORS;
