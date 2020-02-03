using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using static  System.Guid;

using static System.Data.Odbc.OdbcType;
public class OdbcConnectionAttempt
{
	public static string insertEmployeeQuery = "Insert into Employee (ID, name, address, managerId, jobTitle, certifiedFor, startDate, salary) values (?,?,?,?,?,?,?,?)";

	public static string insertCustomerQuery = "Insert into Customer (ID, Name, address, birthDate, picture, gender) values (?,?,?,?,?,?)"; //number 1. 

	public static string insertServiceType = "Insert into ServiceType  (ID, name, certificationRqts, rate) values (?,?,?,?)";

	public static string insertCustomerServiceType = "Insert into CustomerService  (CustomerID, ServiceTypeID, ExpectedDuration) values (?,?,?)";

	public static string insertCustomerServiceSchedule = "Insert into CustomerServiceSchedule  (ServiceScheduleID , CustomerID, ServiceTypeID, EmployeeID, StartDateTime, ActualDuration, Status) values (?,?,?,?,?,?,?)";
	//public static string insertCustomerServiceSchedule = "Insert into CustomerServiceSchedule  ( CustomerID, ServiceTypeID, EmployeeID, StartDateTime, ActualDuration, Status) values (?,?,?,?,?,?)";


	public static string changeServiceRate = "Update serviceType SET rate = ? WHERE ID = ?"; // number 2. 

	//number 3. 'status' type is CHAR where it's either 'Y'/'N' 'n' means active? 
	public static string fetchActiveService = "Select * from customerServiceSchedule WHERE status = 'N'";
	public static string insertCustomerService = "Insert into customerServiceSchedule (customerId, serviceTypeID, employeeID, startDateTime, actualDuration, status) values (?,?,?,?,?,?)";

	public static void Main(string[] args)
	{
		/**s
		insertCustomerParameter();
		insertEmployeeParameter();
		insertServiceTypeParameter();
		insertServiceTypeParameter();
		insertCustomerServiceScheduleParameter();
		*/
		readData();
		readimage();
	}

	/**
		bool enterdata = nsertrue;

		//byte[] rawData = File.ReadAllBytes(@"C:\cat1.jpg");
		//FileInfo info = new FileInfo(@"C:\cat1.jpg");
		//int fileSize = Convert.ToInt32(info.Length);


		//----CONNECTING TO ORACLE
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;
	
		
		mycommand.CommandText = insertCustomerQuery;
		insertCustomerParameter(mycommand);
		//OLTP commands
		//
		**/
	/**
	string[] gothrough = { "1", "5" };
	
	int counter = 0;
	while ((counter < gothrough.Length) && enterdata)
	{
		
		switch (gothrough[counter])
		{
			case "1":
				mycommand.CommandText = insertCustomerQuery;
				insertCustomerParameter(mycommand);
				break;
			case "2":
				mycommand.CommandText = changeServiceRate;
				break;
			case "3":
				mycommand.CommandText = fetchActiveService;
				break;
			case "4":
				mycommand.CommandText = insertCustomerService;
				break;
			case "5":
				mycommand.CommandText = insertEmployeeQuery;
				insertEmployeeParameter(mycommand);
				break;
			case "6":
				mycommand.CommandText = insertServiceType;
				insertServiceTypeParameter(mycommand);
				break;
			case "7":
				mycommand.CommandText = insertCustomerServiceSchedule;
				insertCustomerServiceScheduleParameter(mycommand);
				break;
			case "8":
				mycommand.CommandText = insertCustomerServiceType;
				insertCustomerServiceTypeParameter(mycommand);
				break;
			default:
				Console.WriteLine("usage: MyOdbcConnection.exe insert number 1~4");
				break;

		}
		counter++;

		mycommand.ExecuteNonQuery(); // Commit the transaction. 
	}
**/
	/**
		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();

		/////////-------------------------
		///
		OdbcConnection myConn1 = new OdbcConnection(myConnection);
		OdbcCommand mycommand1 = new OdbcCommand();
		OdbcTransaction transaction1 = null;
		myConn1.Open();
		transaction1 = myConn1.BeginTransaction();

		mycommand1.Connection = myConn1;
		mycommand1.Transaction = transaction1;
		mycommand1.CommandText = insertEmployeeQuery;
		insertEmployeeParameter(mycommand1);
		transaction1.Commit();
		mycommand1.Connection.Close();
		/////////-------------------------
		///
		OdbcConnection myConn2 = new OdbcConnection(myConnection);
		OdbcCommand mycommand2 = new OdbcCommand();
		OdbcTransaction transaction2 = null;
		myConn2.Open();
		transaction2 = myConn2.BeginTransaction();

		mycommand2.Connection = myConn2;
		mycommand2.Transaction = transaction2;
		mycommand2.CommandText = insertServiceType;
		insertServiceTypeParameter(mycommand2);
		transaction2.Commit();
		mycommand2.Connection.Close();

		/////////-------------------------
		///
		OdbcConnection myConn3 = new OdbcConnection(myConnection);
		OdbcCommand mycommand3 = new OdbcCommand();
		OdbcTransaction transaction3 = null;
		myConn3.Open();
		transaction3 = myConn3.BeginTransaction();

		mycommand3.Connection = myConn3;
		mycommand3.Transaction = transaction3;
		mycommand3.CommandText = insertServiceType;
		insertServiceTypeParameter(mycommand3);
		transaction3.Commit();
		mycommand3.Connection.Close();
		/////////-------------------------
		///
		OdbcConnection myConn4 = new OdbcConnection(myConnection);
		OdbcCommand mycommand4 = new OdbcCommand();
		OdbcTransaction transaction4 = null;
		myConn4.Open();
		transaction4 = myConn4.BeginTransaction();

		mycommand4.Connection = myConn4;
		mycommand4.Transaction = transaction4;
		mycommand4.CommandText = insertCustomerServiceSchedule;
		insertCustomerServiceScheduleParameter(mycommand4);
		transaction4.Commit();
		mycommand4.Connection.Close();
		/////////-------------------------
		///
		OdbcConnection myConn5 = new OdbcConnection(myConnection);
		OdbcCommand mycommand5 = new OdbcCommand();
		OdbcTransaction transaction5 = null;
		myConn5.Open();
		transaction5 = myConn5.BeginTransaction();

		mycommand5.Connection = myConn5;
		mycommand5.Transaction = transaction5;
		mycommand5.CommandText = insertCustomerServiceType;
		insertCustomerServiceTypeParameter(mycommand5);
		transaction5.Commit();
		mycommand5.Connection.Close();
		**/




	public static byte[] imageToBlob(string path)
	{
		string hardcodepath = @"C:\clientserver4\asn02\pika.jpg";

		path = hardcodepath;
		System.IO.FileStream myStream = new System.IO.FileStream(@path, FileMode.Open);

		BinaryReader binaryReader = new BinaryReader(myStream);
		byte[] data = binaryReader.ReadBytes((int)myStream.Length); //read the stream into byte

		return data;
	}
	public  static void insertCustomerParameter()
	{
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;

		mycommand.CommandText = insertCustomerQuery;

		OdbcParameterCollection parameters = mycommand.Parameters;
		parameters.Add("ID", OdbcType.VarChar); //needs to be uuid later
		parameters["ID"].Value = Guid.NewGuid().ToString();
		parameters.Add("name", OdbcType.VarChar); //needs tolater
		parameters["name"].Value = "Sammy";

		parameters.Add("address", OdbcType.VarChar); // late
		parameters["address"].Value = "Somewhere far away";

		parameters.Add("birthdate", OdbcType.Date); //r
		parameters["birthdate"].Value = "2006-01-15";

		parameters.Add("picture", OdbcType.Image); //needs id la
		parameters["picture"].Value = imageToBlob("it is hardcoded matter so this parameter doesn't really matter rn");

		parameters.Add("gender", OdbcType.VarChar); //needs to beter
		parameters["gender"].Value = "female";



		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();
	}
	public static void insertEmployeeParameter()
	{
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;

		mycommand.CommandText = insertEmployeeQuery;
		OdbcParameterCollection parameters = mycommand.Parameters;
		parameters.Add("ID", OdbcType.VarChar); //needs to be uuid later
		parameters["ID"].Value = Guid.NewGuid().ToString();

		parameters.Add("name", OdbcType.VarChar); //needs tolater
		parameters["name"].Value = "John";

		parameters.Add("managerId", OdbcType.VarChar); //needs tolater
		parameters["managerId"].Value = "no manager";

		parameters.Add("address", OdbcType.VarChar); // late
		parameters["address"].Value = "21 Forestry avenue";

		parameters.Add("jobTitle", OdbcType.VarChar); // late
		parameters["jobTitle"].Value = "manager";

		parameters.Add("certifiedFor", OdbcType.VarChar); // late
		parameters["certifiedFor"].Value = "Everything";



		parameters.Add("startDate", OdbcType.Date); //r
		parameters["startDate"].Value = "2010-01-15";

		parameters.Add("salary", OdbcType.Decimal); //needs id la
		parameters["salary"].Value = 123123;



		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();
	}
	public static void insertServiceTypeParameter()
	{
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;
		mycommand.CommandText = insertServiceType;

		OdbcParameterCollection parameters = mycommand.Parameters;
		parameters.Add("ID", OdbcType.VarChar); //needs to be uuid later
		parameters["ID"].Value = Guid.NewGuid().ToString();
		parameters.Add("name", OdbcType.VarChar); //needs tolater
		parameters["name"].Value = "Sally";

		parameters.Add("certificationRqts", OdbcType.VarChar); //needs tolater
		parameters["certificationRqts"].Value = "Bachelor Degree";
	

		parameters.Add("rate", OdbcType.Decimal); //needs id la
		parameters["rate"].Value = 50.5;



		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();
	}

	public static void insertCustomerServiceScheduleParameter()
	{
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;

		mycommand.CommandText = insertCustomerServiceSchedule;

		OdbcParameterCollection parameters = mycommand.Parameters;


		parameters.Add("CustomerServiceScheduleID", OdbcType.VarChar); //needs to be uuid later
		parameters["CustomerServiceScheduleID"].Value = "sc011";

		parameters.Add("ServiceTypeID", OdbcType.VarChar); //needs tolater
		parameters["ServiceTypeID"].Value = "s001";

		parameters.Add("CustomerID", OdbcType.VarChar); // late
		parameters["CustomerID"].Value = "c001";

		parameters.Add("EmployeeID", OdbcType.VarChar); // late
		parameters["EmployeeID"].Value = "e001";

		parameters.Add("StartDateTime", OdbcType.Date); //r
														//	parameters["StartDateTime"].Value = "2019:05-03 21:02:44";
		parameters["StartDateTime"].Value = "1212-12-12";


		parameters.Add("ActualDuration", OdbcType.Decimal); //needs id la
		parameters["ActualDuration"].Value = 123;


		parameters.Add("Status", OdbcType.Char); //needs to beter
		parameters["Status"].Value ='y' ;



		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();
	}

	public static void insertCustomerServiceTypeParameter()
	{
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		OdbcCommand mycommand = new OdbcCommand();
		OdbcTransaction transaction = null;
		myConn.Open();
		transaction = myConn.BeginTransaction();

		mycommand.Connection = myConn;
		mycommand.Transaction = transaction;


		mycommand.CommandText = insertCustomerServiceType;

		OdbcParameterCollection parameters = mycommand.Parameters;


		parameters.Add("CustomerID", OdbcType.VarChar); //needs to be uuid later
		parameters["CustomerID"].Value = "c002";

		parameters.Add("ServiceTypeID", OdbcType.VarChar); //needs tolater
		parameters["ServiceTypeID"].Value = "s002";



		parameters.Add("ExpectedDuration", OdbcType.Decimal); //needs id la
		parameters["ExpectedDuration"].Value = 555;



		mycommand.ExecuteNonQuery(); // Commit the transaction. 

		transaction.Commit();

		mycommand.Connection.Close();
	}

	public static void readData()
    {
		Console.WriteLine("\n\n\n\n\n");
		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection myConn = new OdbcConnection(myConnection);
		myConn.Open();

		// mySelectQuery = "SELECT * from Customer";
		string mySelectQuery = "SELECT * from Employee";
		OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

		OdbcDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
			Console.WriteLine("{0}={1}, {2}={3}", reader.GetName(1), reader.GetString(1), reader.GetName(2), reader.GetString(2));
		}


	}
	public static void readimage()
    {

		string myConnection = "dsn=myOracle;uid=system;pwd=1234";

		OdbcConnection conn = new OdbcConnection(myConnection);
		conn.Open();
		string query = "SELECT Picture , name FROM Customer";
		OdbcCommand exe = new OdbcCommand(query, conn);
		OdbcDataReader read = exe.ExecuteReader();
		byte[] contentDataBuffer = new byte[2097125];
        while (read.Read())
        {
			long lCntRead = read.GetBytes(0, 0, contentDataBuffer, 0, 2097125);
			Console.WriteLine(contentDataBuffer.ToString());
			break;
        }
		MemoryStream mStream = new MemoryStream(contentDataBuffer);
		System.Drawing.Image i = System.Drawing.Image.FromStream(mStream, true);
		i.Save("C:\\clientserver4\\asn02\\newimage.jpg");


	}


}
