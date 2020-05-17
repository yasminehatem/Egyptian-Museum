using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace MuseumProj
{
    class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        //-------------Signup & Login Checks--------------
        public bool CheckID(int ID) //false means doesn't exist, true means it does
        {
            string query = "SELECT EID from Employee where EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            string query1 = "SELECT EmployeeID from Accounts where EmployeeID = " + ID + ";";
            object p1 = dbMan.ExecuteScalar(query1);

            if (p != null && p1 == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckTransferTo(int oid, int TID,int catno,int pid) //false means doesn't exist, true means it does if its id done by this customer
        {
            string query = "SELECT ID from LoanTo where OriginalID = " + oid + " and ID=" + TID + " and CatNo= " + catno + " and PieceID =" + pid + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckMaintValid(int oid, int catno, int pid, int mid) //false means doesn't exist, true means it does if its id done by this customer
        {
            string query = "SELECT MID from Maintenance where OriginalID = " + oid + " and MID=" + mid + " and CatNo= " + catno + " and PieceID =" + pid + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckName(string name, int ID) //false means doesn't exist, true means it does
        {
            string query = "SELECT eName from Employee where eName = '" + name + "' and EID=" + ID +";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckUserName(string username) //false means doesn't exist, true means it does
        {
            string query = "SELECT Username from Accounts where Username = '" + username + "';";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CheckAccount(string username, string password) //false means doesn't exist, true means it does
        {
            string query = "SELECT EmployeeID from Accounts where Username = '" + username + "' and _Password='" + password + "';";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public string CheckPassword(int ID, string password) //false means doesn't exist, true means it does
        {
            string query = "SELECT _Password from Accounts where _Password ='" + password + "'" + "and EmployeeID =" + ID +";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return null;
            }
            else
            {
                return (string)p;
            }
        }

        //Check position, 1 for employee, 2 for Manager
        public int CheckPosition(int ID)
        {
            string query = "SELECT Position from Employee where EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        //check ID for employee removal
        public bool CheckID2(int ID) //false means doesn't exist, true means it does
        {
            string query = "SELECT EID from Employee where EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //check ID for tourguides 
        public bool CheckTourguideID(int ID) //false means doesn't exist, true means it does
        {
            string query = "SELECT ID from Tourguide where ID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckTourguideName(string name, int ID) //false means doesn't exist, true means it does
        {
            string query = "SELECT tName from Tourguide where tName = '" + name + "' and ID=" + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //---------------Insert Functions---------------

        public int InsertAccount(int ID, string username, string password, string email)
        {
            string query = "INSERT INTO Accounts (EmployeeID, Username, _Password, email)" +
                            "Values (" + ID + ",'" + username + "','" + password + "','" + email +"');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPastEmployee(int ID, string Name)
        {
            string query = "INSERT INTO PastEmployees SELECT * From Employee where EID = " + ID + "and eName = '" + Name + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPiece(int TableNo, int PID, string title, int dynasty, string material, string status, string image, string description)
        {
            string query1 = "Insert INTO Piece values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description +"');";

            int q1 =  dbMan.ExecuteNonQuery(query1);

            if (q1 != 0)
            {
                if (TableNo == 1)
                {
                    string query = "Insert INTO Piece1 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else if (TableNo == 2)
                {
                    string query = "Insert INTO Piece2 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else if (TableNo == 3)
                {
                    string query = "Insert INTO Piece3 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else if (TableNo == 4)
                {
                    string query = "Insert INTO Piece4 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else if (TableNo == 5)
                {
                    string query = "Insert INTO Piece5 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else if (TableNo == 6)
                {
                    string query = "Insert INTO Piece6 (OriginalID,Title,DynastyNo,Material,Status,image,Description)" +
                    "Values (" + PID + ",'" + title + "'," + dynasty + ",'" + material + "','" + status + "','" + image + "','" + description + "');";
                    return dbMan.ExecuteNonQuery(query);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public int InsertEmployee(string name, char sex, int phone, string job, int salary, int position)
        {
            string query = "INSERT INTO Employee (eName, Sex, PhoneNo, ShiftNo, Job, Salary, Position)" +
                            "Values ('" + name + "','" + sex + "'," + phone + "," + 0 + ",'" + job + "'," + salary + "," + position + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertTourguide(string name, char sex, int phone, string status, string university, int salary)
        {
            string query = "INSERT INTO Tourguide Values ('" + name + "','" + sex + "'," + phone + ",'" + status + "','" + university + "'," + salary + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPastTourguide(int ID, string Name)
        {
            string query = "INSERT INTO PastTourguides SELECT * From Tourguide where ID = " + ID + "and tName = '" + Name + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        //---------------Update Functions------------------
        public int UpdateUsername(int ID, string username) //new quantity
        {
            string query = "UPDATE Accounts SET Username= '" + username + "' WHERE EmployeeID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePassword(int ID, string password) //new quantity
        {
            string query = "UPDATE Accounts SET _Password= '" + password + "' WHERE EmployeeID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateName(int ID, string name) //new quantity
        {
            string query = "UPDATE Employee SET eName= '" + name + "' WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePhoneNo(int ID, string PhoneNo) //new quantity
        {
            string query = "UPDATE Employee SET PhoneNo= " + PhoneNo + " WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateJob(int ID, string Job) //new quantity
        {
            string query = "UPDATE Employee SET Job= '" + Job + "' WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePosition(int ID, int position) //new quantity
        {
            string query = "UPDATE Employee SET Position= " + position + " WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateSalary(int ID, int salary) //new quantity
        {
            string query = "UPDATE Employee SET Salary= " + salary + " WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateShift(int ID, int shift) //new quantity
        {
            string query = "UPDATE Employee SET ShiftNo= " + shift + " WHERE EID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTgName(int ID, string name) //new quantity
        {
            string query = "UPDATE Tourguide SET tName= '" + name + "' WHERE ID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTgPhoneNo(int ID, string PhoneNo) //new quantity
        {
            string query = "UPDATE Tourguide SET PhoneNo= " + PhoneNo + " WHERE ID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTgStatus(int ID, string status) //new quantity
        {
            string query = "UPDATE Tourguide SET _Status= '" + status + "' WHERE ID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTgSalary(int ID, int salary) //new quantity
        {
            string query = "UPDATE Tourguide SET Salary= " + salary + " WHERE ID = " + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        //----------------Delete Function------------------
        public int DeleteEmployee(int ID, string Name)
        {
            string query = "DELETE FROM Employee WHERE EID=" + ID + " and eName='" + Name + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAccount(int ID, string Name)
        {
            string query = "DELETE FROM Accounts WHERE EmployeeID=" + ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteTourguide(int ID, string Name)
        {
            string query = "DELETE FROM Tourguide WHERE ID=" + ID + " and tName='" + Name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        //---------------Get Functions--------------

        public int Count() //counting ID's for Pieces
        {
            string query = "SELECT COUNT(*) FROM Piece";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public string GetName(int ID)
        {
            string query = "SELECT eName FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public string GetGender(int ID)
        {
            string query = "SELECT Sex FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public int GetPhone(int ID)
        {
            string query = "SELECT PhoneNo FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return 0 + (int)p;
            }
        }

        public string GetJob(int ID)
        {
            string query = "SELECT Job FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public int GetSalary(int ID)
        {
            string query = "SELECT Salary FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetShift(int ID)
        {
            string query = "SELECT Shift FROM Employee WHERE EID = " + ID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }
        //function to return the count of pieces in a certain Era
        public int CountPieces(int era)
        {
            if (era == 1)
            {
                string query = "SELECT COUNT(*) FROM Piece1;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 2)
            {
                string query = "SELECT COUNT(*) FROM Piece2;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 3)
            {
                string query = "SELECT COUNT(*) FROM Piece3;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 4)
            {
                string query = "SELECT COUNT(*) FROM Piece4;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 5)
            {
                string query = "SELECT COUNT(*) FROM Piece5;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 6)
            {
                string query = "SELECT COUNT(*) FROM Piece6;";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else
            {
                return 0;
            }
        } //end function

        public string GetPieceTitle(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT Title FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT Title FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT Title FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT Title FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT Title FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT Title FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else
            {
                return null;
            }
        } //end function

        public string GetPieceImage(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT image FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT image FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT image FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT image FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT image FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT image FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else
            {
                return null;
            }
        } //end function

        public int GetPieceDynasty(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT DynastyNo FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT DynastyNo FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT DynastyNo FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT DynastyNo FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT DynastyNo FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT DynastyNo FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else
            {
                return 0;
            }
        } //end function

        public string GetPieceMaterial(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT Material FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT Material FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT Material FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT Material FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT Material FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT Material FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else
            {
                return null;
            }
        } //end function


        public string GetPieceStatus(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT Status FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT Status FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT Status FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT Status FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT Status FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT Status FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else
            {
                return null;
            }
        } //end function


        public string GetPieceDescription(int TableNo, int PieceID)
        {
            if (TableNo == 1)
            {
                string query = "SELECT Description FROM Piece1 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 2)
            {
                string query = "SELECT Description FROM Piece2 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 3)
            {
                string query = "SELECT Description FROM Piece3 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 4)
            {
                string query = "SELECT Description FROM Piece4 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 5)
            {
                string query = "SELECT Description FROM Piece5 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else if (TableNo == 6)
            {
                string query = "SELECT Description FROM Piece6 WHERE PID =" + PieceID + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return null;
                }
                else
                {
                    return (string)p;
                }
            }
            else
            {
                return null;
            }
        } //end function

        public DataTable SelectCurrentEmployees(int rank)
        {
            if (rank == 2)
            {
                string query = "SELECT * FROM Employee where Position = 1;";
                return dbMan.ExecuteReader(query);
            }
            else if (rank == 3)
            {
                string query = "SELECT * FROM Employee where Position = 1 or Position = 2;";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                return null;
            }
        }

        public DataTable SelectPastEmployees(int rank)
        {
            if (rank == 2)
            {
                string query = "SELECT * FROM PastEmployees where Position = 1;";
                return dbMan.ExecuteReader(query);
            }
            else if (rank == 3)
            {
                string query = "SELECT * FROM PastEmployees where Position = 1 or Position = 2;";
                return dbMan.ExecuteReader(query);
            }
            else
            {
                return null;
            }
        }

        public DataTable SelectCurrentTourguides()
        {
            string query = "SELECT * FROM Tourguide";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectPastTourguides()
        {
            string query = "SELECT * FROM PastTourguides";
            return dbMan.ExecuteReader(query);
        }

        //----------------Statistics Functions------------------

        public int GetTotalMonuments()
        {
            string query = "SELECT COUNT(*) FROM Piece";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalPrehistoricEra()
        {
            string query = "SELECT COUNT(*) FROM Piece1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEarlyAges()
        {
            string query = "SELECT COUNT(*) FROM Piece2";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalOldKingdom()
        {
            string query = "SELECT COUNT(*) FROM Piece3";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMiddleKingdom()
        {
            string query = "SELECT COUNT(*) FROM Piece4";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalNewKingdom()
        {
            string query = "SELECT COUNT(*) FROM Piece5";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalLatePeriod()
        {
            string query = "SELECT COUNT(*) FROM Piece6";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMonumentsDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalPrehistoricEraDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece1 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEarlyAgesDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece2 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalOldKingdomDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece3 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMiddleKingdomDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece4 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalNewKingdomDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece5 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalLatePeriodDisp()
        {
            string query = "SELECT COUNT(*) FROM Piece6 Where Status = 'On-Display'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMonumentsMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalPrehistoricEraMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece1 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEarlyAgesMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece2 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalOldKingdomMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece3 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMiddleKingdomMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece4 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalNewKingdomMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece5 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalLatePeriodMaint()
        {
            string query = "SELECT COUNT(*) FROM Piece6 where Status = 'Under-Maintenance'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMonumentsTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalPrehistoricEraTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece1 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEarlyAgesTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece2 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalOldKingdomTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece3 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMiddleKingdomTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece4 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalNewKingdomTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece5 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalLatePeriodTrans()
        {
            string query = "SELECT COUNT(*) FROM Piece6 where Status = 'In-Transfer'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }
        
        //employees statistics rank = 2

        public int GetTotalEmps()
        {
            string query = "SELECT COUNT(*) FROM Employee where Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMaleEmps()
        {
            string query = "SELECT COUNT(*) FROM Employee where Sex = 'M'and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFemaleEmps()
        {
            string query = "SELECT COUNT(*) FROM Employee where Sex = 'F' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaxSalary()
        {
            string query = "SELECT Max(Salary) FROM Employee where Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleMaxSalary()
        {
            string query = "SELECT Max(Salary) FROM Employee where Sex = 'M' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleMaxSalary()
        {
            string query = "SELECT Max(Salary) FROM Employee where Sex = 'F' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }


        public int GetEmpMinSalary()
        {
            string query = "SELECT Min(Salary) FROM Employee where Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleMinSalary()
        {
            string query = "SELECT Min(Salary) FROM Employee where Sex = 'M' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleMinSalary()
        {
            string query = "SELECT Min(Salary) FROM Employee where Sex = 'F' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }


        public int GetEmpAvgSalary()
        {
            string query = "SELECT Avg(Salary) FROM Employee where Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleAvgSalary()
        {
            string query = "SELECT Avg(Salary) FROM Employee where Sex = 'M' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleAvgSalary()
        {
            string query = "SELECT Avg(Salary) FROM Employee where Sex = 'F' and Position = 1";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public DataTable SelectEmpJobStatistics1()
        {
            string query = "Select Job, Count(Job) as 'Number' from Employee where position = 1 group by Job;";
            return dbMan.ExecuteReader(query);
        }

        //employees statistics rank = 3

        public int GetTotalEmps1()
        {
            string query = "SELECT COUNT(*) FROM Employee where position = 1 or position = 2";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMaleEmps1()
        {
            string query = "SELECT COUNT(*) FROM Employee where Sex = 'M'and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFemaleEmps1()
        {
            string query = "SELECT COUNT(*) FROM Employee where Sex = 'F' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaxSalary1()
        {
            string query = "SELECT Max(Salary) FROM Employee where position = 1 or position = 2";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleMaxSalary1()
        {
            string query = "SELECT Max(Salary) FROM Employee where Sex = 'M' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleMaxSalary1()
        {
            string query = "SELECT Max(Salary) FROM Employee where Sex = 'F' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }


        public int GetEmpMinSalary1()
        {
            string query = "SELECT Min(Salary) FROM Employee where position = 1 or position = 2";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleMinSalary1()
        {
            string query = "SELECT Min(Salary) FROM Employee where Sex = 'M' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleMinSalary1()
        {
            string query = "SELECT Min(Salary) FROM Employee where Sex = 'F' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }


        public int GetEmpAvgSalary1()
        {
            string query = "SELECT Avg(Salary) FROM Employee where position = 1 or position = 2";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpMaleAvgSalary1()
        {
            string query = "SELECT Avg(Salary) FROM Employee where Sex = 'M' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEmpFemaleAvgSalary1()
        {
            string query = "SELECT Avg(Salary) FROM Employee where Sex = 'F' and (position = 1 or position = 2)";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public DataTable SelectEmpJobStatistics2()
        {
            string query = "Select Job, Count(Job) as 'Number' from Employee where position = 1 or position = 2 group by Job;";
            return dbMan.ExecuteReader(query);
        }

        //Tour guides statistics 

        public DataTable SelectTgJobStatistics()
        {
            string query = "Select _Status, Count(_Status) as 'Number' from Tourguide group by _Status;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectTgUniStatistics()
        {
            string query = "Select University, Count(University) as 'Number' from Tourguide group by University;";
            return dbMan.ExecuteReader(query);
        }

        public int GetTotalTgs()
        {
            string query = "SELECT COUNT(*) FROM Tourguide";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalMaleTg()
        {
            string query = "SELECT COUNT(*) FROM Tourguide where Sex = 'M'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFemaleTg()
        {
            string query = "SELECT COUNT(*) FROM Tourguide where Sex = 'F'";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }
        //------------------------------------Yasmine's (Maintenance & Transfer) Functions--------------------------------
        public DataTable ShowMuseumInfo(string name)
        {
            string query = "  select * from Museum  WHERE MuseumName='" + name + "' ;";

            return dbMan.ExecuteReader(query);
        }

        public DataTable ShowPT()
        {
            string query = "  select * from Ptransfer   ;";

            return dbMan.ExecuteReader(query);
        }

        public int GetMuseumID(string name)
        {
            string query = "SELECT MuseumID FROM Museum WHERE MuseumName='" + name + "';";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int InsertMuseum(string name, string city, string country)
        {
            string query = "INSERT INTO Museum (MuseumName, MuseumCity, MuseumCountry)" +
                            "Values ('" + name + "','" + city + "','" + country + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable MuseumsNameList()
        {
            string query = "SELECT MuseumName FROM Museum ;";
            return dbMan.ExecuteReader(query);
        }

        public string MuseumsName(int mID)
        {
            string query = "SELECT MuseumName FROM Museum where MuseumID = " + mID + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return null;
            }
            else
            {
                return (string)p;
            }
        }

        public bool CheckPieceStatusT(int oid) //false means doesn't exist, true means it does
        {
            string query = "SELECT Status from Piece where PID = '" + oid + "' AND Status='In-Transfer' ;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckPieceStatusD(int oid) //false means doesn't exist, true means it does
        {
            string query = "SELECT Status from Piece where PID = '" + oid + "' AND Status='On-Display' ;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool CheckPieceStatusM(int oid) //false means doesn't exist, true means it does
        {
            string query = "SELECT Status from Piece where PID = '" + oid + "' AND Status='Under-Maintenance' ;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public int InsertMaintenance(int mid, int catno, string title, int oid, int pid, string type, string sdate, string edate)
        {
            string query = "INSERT INTO Maintenance(MID,CatNo,Title,OriginalID,PieceID,Type,StartDate,EndDate)" +
                 "Values(" + mid + "," + catno + ",'" + title + "'," + oid + "," + pid + ",'" + type + "','" + sdate + "','" + edate + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertPtransfer(string title, string loanplace, int cn, int period)
        {
            string query = "INSERT INTO Ptransfer(PieceTitle,LoanPlace,CatNo,Period)" +
                 "Values('" + title + "','" + loanplace + "' ," + cn + "," + period + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertLoanFrom(int mid, string title, string loanplace, string sdate, string edate, int period)
        {
            string query = "INSERT INTO LoanFrom(MuseumID,PieceTitle,LoanPlace,StartDate,EndDate,Period)" +
                 "Values(" + mid + ",'" + title + "','" + loanplace + "' ,'" + sdate + "','" + edate + "'," + period + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteLoanTo(int id)
        {
            string query = "DELETE FROM LoanTo WHERE ID=" + id + " ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int GetOPID(int era, int pid)
        {
            if (era == 1)
            {
                string query = "SELECT OriginalID FROM Piece1 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 2)
            {
                string query = "SELECT OriginalID FROM Piece2 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 3)
            {
                string query = "SELECT OriginalID FROM Piece3 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 4)
            {
                string query = "SELECT OriginalID FROM Piece4 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 5)
            {
                string query = "SELECT OriginalID FROM Piece5 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else if (era == 6)
            {
                string query = "SELECT OriginalID FROM Piece6 WHERE PID=" + pid + ";";
                object p = dbMan.ExecuteScalar(query);
                if (p == null)
                {
                    return 0;
                }
                else
                {
                    return (int)p;
                }
            }
            else
            {
                return 0;
            }
        } //end function

        public int InsertLoanTo(int museumID, string ptitle, string loanplace, int catno, int opid, int pid, int per, string sdate, string edate)
        {
            string query = "INSERT INTO LoanTo(MuseumID,PieceTitle,LoanPlace,CatNo,OriginalID,PieceID,Period,StartDate,EndDate)" +
                 "Values(" + museumID + ",'" + ptitle + "','" + loanplace + "'," + catno + "," + opid + "," + pid + "," + per + ",'" + sdate + "','" + edate + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectPieceUM()
        {
            string query = "SELECT * FROM Maintenance where EndDate ='';";

            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectPiecePM()
        {
            string query = "  select * from Maintenance where not exists ( select * from Maintenance where EndDate='');";

            return dbMan.ExecuteReader(query);
        }

        public int UpdateEndDate(string date, int mid)
        {
            string query1 = "UPDATE Maintenance SET EndDate='" + date + "' where MID= " + mid + " ;";
            return dbMan.ExecuteNonQuery(query1);

        }

        public int UpdateMaint1(int OID)
        {
            string query1 = "UPDATE Piece SET Status='Under-Maintenance' where PID= " + OID + " ;";
            return dbMan.ExecuteNonQuery(query1);
        }

        public int UpdateMaint2(int catno, int id)
        {
            if (catno == 1)
            {
                string query1 = "UPDATE Piece1 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 2)
            {
                string query1 = "UPDATE Piece2 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 3)
            {
                string query1 = "UPDATE Piece3 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 4)
            {
                string query1 = "UPDATE Piece4 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 5)
            {
                string query1 = "UPDATE Piece5 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 6)
            {
                string query1 = "UPDATE Piece6 SET Status='Under-Maintenance' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else return -1000;

        }

        public int UpdateTransfer1(int OID)
        {
            string query1 = "UPDATE Piece SET Status='In-Transfer' where PID= " + OID + " ;";
            return dbMan.ExecuteNonQuery(query1);
        }

        public int UpdateTransfer2(int catno, int id)
        {
            if (catno == 1)
            {
                string query1 = "UPDATE Piece1 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 2)
            {
                string query1 = "UPDATE Piece2 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 3)
            {
                string query1 = "UPDATE Piece3 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 4)
            {
                string query1 = "UPDATE Piece4 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 5)
            {
                string query1 = "UPDATE Piece5 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 6)
            {
                string query1 = "UPDATE Piece6 SET Status='In-Transfer' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else return -1000;

        }

        public DataTable SelectMyPieceT(string date)
        {
            string query = "  select * from LoanTo  WHERE EndDate >'" + date + "' ;";

            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectPieceL(string date)
        {
            string query = "  select * from LoanFrom  WHERE EndDate >'" + date + "' ;";

            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectMyPiecePT(string date)
        {
            string query = "  select * from LoanTo  WHERE EndDate < '" + date + "' ;";

            return dbMan.ExecuteReader(query);
        }

        public DataTable EndMyTransfer(string date)
        {
            string query = "  select * from LoanTo  WHERE EndDate = '" + date + "' ;";

            return dbMan.ExecuteReader(query);
        }

        public int UpdateEndMaint1(int OID)
        {
            string query1 = "UPDATE Piece SET Status='On-Display' where PID= " + OID + " ;";
            return dbMan.ExecuteNonQuery(query1);
        }

        public int UpdateEndMaint2(int catno, int id)
        {
            if (catno == 1)
            {
                string query1 = "UPDATE Piece1 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 2)
            {
                string query1 = "UPDATE Piece2 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 3)
            {
                string query1 = "UPDATE Piece3 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 4)
            {
                string query1 = "UPDATE Piece4 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 5)
            {
                string query1 = "UPDATE Piece5 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else if (catno == 6)
            {
                string query1 = "UPDATE Piece6 SET Status='On-Display' where PID= " + id + " ;";
                return dbMan.ExecuteNonQuery(query1);
            }
            else return -1000;

        }

        public int LoanToCount() //counting maintenace to get last id
        {
            string query = "SELECT COUNT(*) FROM LoanTo";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int MuseumCount() //counting maintenace to get last id
        {
            string query = "SELECT COUNT(*) FROM Museum";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int MaintCount() //counting maintenace to get last id
        {
            string query = "SELECT COUNT(*) FROM Maintenance";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public string GetLoanPlace(int id)
        {
            string query = "SELECT LoanPlace FROM LoanTo WHERE ID = " + id + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public string GetTStartDate(int id)
        {
            string query = "SELECT StartDate FROM LoanTo WHERE ID = " + id + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public string GetTEndDate(int id)
        {
            string query = "SELECT EndDate FROM LoanTo WHERE ID = " + id + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return " ";
            }
            else
            {
                return (string)p;
            }
        }

        public int GetPeriod(int id)
        {
            string query = "SELECT Period FROM LoanTo WHERE ID = " + id + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        //-------------------------------End of Maintenance & Transfer functions-------------------------

        //------------------------------Nermine's Functions(Trips & Tickets)-----------------------------

        public int AddTrip(int month, int day, int year, int ForeignNormal, int ForeignStudents, int EgyptianNormal, int EgyptianStudents, int TotalPrice, string org, int TourGuideID, int HR_ID)
        {
            string query = "INSERT INTO Trips Values (" + month + "," + day + "," + year + "," + ForeignStudents + "," + ForeignNormal + "," + EgyptianStudents + "," + EgyptianNormal + "," + TotalPrice + ",'" + org + "'," + HR_ID + "," + TourGuideID + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        //Get previous trips
        public DataTable UpcomingTrips()
        {
            int month = (int)DateTime.Now.Month;
            int day = (int)DateTime.Now.Day;
            string query = "SELECT * FROM Trips WHERE (Dayss>" + day + "AND  Months=" + month + ") OR (Months>" + month + ");";
            return dbMan.ExecuteReader(query);
        }

        public DataTable PreviousTrips()
        {
            int month = (int)DateTime.Now.Month;
            int day = (int)DateTime.Now.Day;
            string query = "SELECT * FROM Trips WHERE (Dayss=<" + day + " AND Months=" + month + ") OR (Months<" + month + ");";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetTourGuides() //Get all tour guides Name
        {

            string query = "SELECT tName FROM Tourguide;";
            return dbMan.ExecuteReader(query);

        }

        public DataTable GetHR()
        {
            string query = "SELECT eName FROM Employee WHERE Job='HR';";
            return dbMan.ExecuteReader(query);

        }

        public int GetTourGuideID(string TGName)
        {
            string query = "SELECT ID FROM Tourguide WHERE tName='" + TGName + "';";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetHR_ID(string HRName)
        {
            string query = "SELECT EID FROM Employee WHERE eName='" + HRName + "'; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMonthTicket(int month)
        {
            string query = "SELECT Tmonth FROM Ticket WHERE Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetDayTicket(int day)
        {
            string query = "SELECT Tday FROM Ticket WHERE Tday=" + day + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetYearTicket(int year)
        {
            string query = "SELECT Tyear FROM Ticket WHERE Tyear=" + year + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int AddTickets(int month, int day, int ForeignNormal, int ForeignStudents, int EgyptianNormal, int EgyptianStudents, int sum, int PES, int PEN, int PFS, int PFN, int total)
        {

            string query = "INSERT INTO Ticket Values (" + month + "," + day + "," + 2018 + "," + EgyptianStudents + "," + EgyptianNormal + "," + ForeignStudents + "," + ForeignNormal + "," + sum + "," + PES + "," + PEN + "," + PFS + "," + PFN + "," + total + ");";
            return dbMan.ExecuteNonQuery(query);

        }

        public int UpdateTickets(int SumEgyNormal, int SumEgyStudents, int SumForeignNormal, int SumForeignStudents, int SumAll, int month, int day, int PEN, int PES, int PFN, int PFS, int price)
        {
            string query = "UPDATE Ticket SET EgyptianNormal= " + SumEgyNormal + ",EgyptianStudents=" + SumEgyStudents + ",ForeignNormal=" + SumForeignNormal + ",ForeignStudents=" + SumForeignStudents + ",TotalNumOfPeople=" + SumAll + ",PriceEgypStudent=" + PES + ",PriceEgypNormal=" + PEN + ",PriceForeignStudent=" + PFS + ",PriceForeignNormal=" + PFN + ",TotalPrice= " + price + " WHERE Tmonth = " + month + " AND Tday=" + day + ";";
            return dbMan.ExecuteNonQuery(query);

        }

        public int GetEgyNormal(int month, int day)
        {
            string query = "SELECT EgyptianNormal FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetEgyStudent(int month, int day)
        {
            string query = "SELECT EgyptianStudents FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetForeignNormal(int month, int day)
        {
            string query = "SELECT ForeignNormal FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetForeignStudents(int month, int day)
        {
            string query = "SELECT ForeignStudents FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int UpdateTicketsPrice(int PriceEgyStu, int PriceEgyNorm, int PriceForeignStu, int PriceForeignNorm)
        {
            string query = "UPDATE Ticket SET PriceEgypStudent= " + PriceEgyStu + ",PriceEgypNormal=" + PriceEgyNorm + ",PriceForeignStudent=" + PriceForeignStu + ",PriceForeignNormal=" + PriceForeignNorm + ";";
            return dbMan.ExecuteNonQuery(query);

        }

        public int GetTotalSum(int month, int day)
        {
            string query = "SELECT TotalNumOfPeople FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPriceEgyNomal(int month, int day)
        {
            string query = "SELECT PriceEgypNormal FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPriceEgyStudent(int month, int day)
        {
            string query = "SELECT PriceEgypStudent FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPriceForeignNormal(int month, int day)
        {
            string query = "SELECT PriceForeignNormal FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPriceForeignStudent(int month, int day)
        {
            string query = "SELECT PriceForeignStudent FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPriceSum(int month, int day)
        {
            string query = "SELECT TotalPrice FROM Ticket WHERE Tday=" + day + " AND Tmonth=" + month + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int AddOrganization(string Name, string location)
        {
            string query = "INSERT INTO Organization Values ('" + Name + "','" + location + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int OrganizationCount()
        {
            string query = "SELECT Count(*) FROM Organization;" ; 
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public string OrganizationName(int ID)
        {
            string query = "SELECT Name FROM Organization WHERE ID = " + ID + "; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return null;
            }
            else
            {
                return (string)p;
            }
        }

        public int GetPEN()
        {
            string query = "SELECT PEN FROM TicketPrices WHERE ID = 1; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPES()
        {
            string query = "SELECT PES FROM TicketPrices WHERE ID = 1; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPFN()
        {
            string query = "SELECT PFN FROM TicketPrices WHERE ID = 1; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetPFS()
        {
            string query = "SELECT PFS FROM TicketPrices WHERE ID = 1; ";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int UpdatePEN(int price)
        {
            string query = "UPDATE TicketPrices SET PEN= " + price + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePES(int price)
        {
            string query = "UPDATE TicketPrices SET PES= " + price + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePFN(int price)
        {
            string query = "UPDATE TicketPrices SET PFN= " + price + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePFS(int price)
        {
            string query = "UPDATE TicketPrices SET PFS= " + price + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        //-------------------Tickets & Trips Statistics-------------------------------------------
        public int GetTotalEnNo()
        {
            string query = "SELECT SUM(EgyptianNormal) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEsNo()
        {
            string query = "SELECT SUM(EgyptianStudents) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFnNo()
        {
            string query = "SELECT SUM(ForeignNormal) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFsNo()
        {
            string query = "SELECT SUM(ForeignStudents) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalTicketsNo()
        {
            string query = "SELECT SUM(TotalNumOfPeople) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }
        public int GetTotalEnPrice()
        {
            string query = "SELECT SUM(PriceEgypNormal) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEsPrice()
        {
            string query = "SELECT SUM(PriceEgypStudents) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFnPrice()
        {
            string query = "SELECT SUM(PriceForeignNormal) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFsPrice()
        {
            string query = "SELECT SUM(PriceForeignStudent) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalTicketPrice()
        {
            string query = "SELECT SUM(TotalPrice) FROM Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateMonth()
        {
            string query = "select Tmonth from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateDay()
        {
            string query = "select Tday from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateYear()
        {
            string query = "select Tyear from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateDay()
        {
            string query = "select Tday from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateYear()
        {
            string query = "select Tyear from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateMonth()
        {
            string query = "select Tmonth from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket);";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetAvgTicketSales()
        {
            string query = "select Avg(TotalPrice) from Ticket;";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public DataTable SelectTicketSalesDate(int month, int day, int year)
        {
            string query = "SELECT * FROM Ticket where Tmonth =" + month + "and Tday=" + day + "and Tyear=" + year + ";";
            return dbMan.ExecuteReader(query);
        }

        //-----------Ticket statistics with 2 dates-------------------
        public int GetTotalEnNo2(int month1, int year1, int month2, int year2)
        {
            string query = "Select SUM(EgyptianStudents) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }
       
        public int GetTotalEsNo2(int month1, int year1, int month2, int year2)
        {
            string query = "Select sum(EgyptianNormal) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";"; 
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFnNo2(int month1, int year1, int month2, int year2)
        {
            string query = "Select sum(ForeignNormal) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFsNo2(int month1, int year1, int month2, int year2)
        {
            string query = "Select sum(ForeignStudents) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalTicketsNo2(int month1, int year1, int month2, int year2)
        {
            string query = "Select sum(TotalNumOfPeople) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEnPrice2(int month1, int year1, int month2, int year2)
        {
            string query = "SELECT SUM(PriceEgypNormal) FROM Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalEsPrice2(int month1, int year1, int month2, int year2)
        {
            string query = "SELECT SUM(PriceEgypStudent) FROM Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFnPrice2(int month1, int year1, int month2, int year2)
        {
            string query = "SELECT SUM(PriceForeignNormal) FROM Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalFsPrice2(int month1, int year1, int month2, int year2)
        {
            string query = "SELECT SUM(PriceForeignStudent) FROM Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 +  "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetTotalTicketPrice2(int month1, int year1, int month2, int year2)
        {
            string query = "SELECT SUM(TotalPrice) FROM Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateMonth2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tmonth from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateDay2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tday from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMaxTicketSalesDateYear2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tyear from Ticket where TotalPrice = (select Max(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 +"and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateMonth2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tmonth from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateDay2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tday from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetMinTicketSalesDateYear2(int month1, int year1, int month2, int year2)
        {
            string query = "select Tyear from Ticket where TotalPrice = (select Min(TotalPrice) from Ticket) and Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

        public int GetAvgTicketSales2(int month1, int year1, int month2, int year2)
        {
            string query = "select Avg(TotalPrice) from Ticket where Tmonth >=" + month1 + "and Tmonth <=" + month2 + "and Tyear >=" + year1 + "and Tyear <=" + year2 + ";";
            object p = dbMan.ExecuteScalar(query);
            if (p == null)
            {
                return 0;
            }
            else
            {
                return (int)p;
            }
        }

    }
}
