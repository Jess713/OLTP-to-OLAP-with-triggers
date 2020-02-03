CREATE OR REPLACE PROCEDURE etl AS

BEGIN

    MERGE INTO EmployeeDim olap
    USING Employee oltp
    ON (olap.id = oltp.id)
    WHEN MATCHED THEN
        UPDATE SET        
            name = oltp.name,
            address = oltp.address,
            jobtitle = oltp.jobtitle,
            certifiedfor = oltp.certifiedfor,
            startdate = oltp.startdate,
            salary = oltp.salary            
    WHEN NOT MATCHED THEN
        INSERT (id, name, address, jobtitle, certifiedfor, startdate, salary) 
        VALUES (oltp.id, oltp.name, oltp.address, oltp.jobtitle, oltp.certifiedfor, oltp.startdate, oltp.salary);
            
    MERGE INTO CustomerDim olap
    USING Customer oltp
    ON (olap.id = oltp.id)
    WHEN MATCHED THEN
        UPDATE SET        
            name = oltp.name,
            address = oltp.address,
            gender = oltp.gender            
    WHEN NOT MATCHED THEN
        INSERT (id, name, address, gender) 
        VALUES (oltp.id, oltp.name, oltp.address, oltp.gender);
    
    MERGE INTO ServiceTypeDim olap
    USING ServiceType oltp
    ON (olap.id = oltp.id)
    WHEN MATCHED THEN
        UPDATE SET        
            name = oltp.name,
            certificationrqts = oltp.certificationrqts,
            rate = oltp.rate
    WHEN NOT MATCHED THEN
        INSERT (id, name, certificationrqts, rate) 
        VALUES (oltp.id, oltp.name, oltp.certificationrqts, oltp.rate);
    
    MERGE INTO CustomerServiceScheduleFact olap
    USING CustomerServiceSchedule oltp
    ON (olap.servicescheduleid = oltp.servicescheduleid)
    WHEN MATCHED THEN
        UPDATE SET        
            customerid = oltp.customerid,
            servicetypeid = oltp.servicetypeid,
            employeeid = oltp.employeeid,
            month = extract(month from to_date(oltp.startdatetime, 'yy-mm-dd')),
            actualduration = oltp.actualduration,
            status = oltp.status
    WHEN NOT MATCHED THEN
        INSERT (servicescheduleid, customerid, servicetypeid, employeeid, month, actualduration, status) 
        VALUES (oltp.servicescheduleid, oltp.customerid, oltp.servicetypeid, oltp.employeeid, extract(month from to_date(oltp.startdatetime, 'yy-mm-dd')), oltp.actualduration, oltp.status);    

END;
/