using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5PrattCastaneda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateConnection();
        }
        void Main(string[] args)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            InsertData(sqlite_conn);
        }
        SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=Employee.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
        void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Employees(EmpID INT(20), EmpName VARCHAR(20), EmpGender VARCHAR(20),EmpHiringDate VARCHAR(20)";

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }

        void InsertData(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Employees(EmpID, EmpName, EmpGender, EmpHiringDate) VALUES(1, 'Employee 1', 'F', '1/1/2020'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Employees(EmpID, EmpName, EmpGender, EmpHiringDate) VALUES(2, 'Employee 2', 'F', '1/2/2020'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Employees(EmpID, EmpName, EmpGender, EmpHiringDate) VALUES(3, 'Employee 3', 'M', '1/3/2020'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Employees(EmpID, EmpName, EmpGender, EmpHiringDate) VALUES(4, 'Employee 4', 'F', '1/4/2020'); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        DataTable ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Employees";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
            DataTable dt = new DataTable();
            return dt;

        }
    }
}

//Query to update EmpHiringDate of Employee 2 to 1/7/2022: UPDATE Employees SET EmpHiringDate = '1/7/2022' WHERE EmpID = 2;
//Query to delete Employee 3: DELETE FROM Employees WHERE EmpID = 3;