using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewCrewDAL
{
	/// <summary>
	/// This class is used from database backup purposes in the BrewCrewAdminDashBoardForm
	/// A connection is made with the database, and each table from the database is loaded into a datatable which are then 
	/// filled into a dataset, which at last is backed up in an XML file.
	/// </summary>
    public class SqlDataTableAccessLayer
    {
		// Used to create a connection with the SQL Databse
		protected SqlConnection sqlConnection = null;

		
		/// <summary>
		/// This method is used to open a connection to the SQL Database
		/// </summary>
		/// <param name="connectionString">Database connection string</param>
		public void OpenConnection(string connectionString)
		{
			sqlConnection = new SqlConnection { ConnectionString = connectionString };
			sqlConnection.Open();
		}

		/// <summary>
		/// This method is used to close the SQL database connection
		/// </summary>
		public void CloseConnection()
		{
			sqlConnection.Close();
		}

		/// <summary>
		/// This method gets the connection string from the App.config file
		/// </summary>
		/// <param name="key">Name of the connection string in the App.config file</param>
		/// <returns></returns>
		public string GetConnectionString(string key)
		{
			if (key == null)
			{
				return null;
			}

			return ConfigurationManager.ConnectionStrings[key].ConnectionString;
		}

		

		/// <summary>
		/// This methods creates a datatable and calls the LoadDataTable method to fill it.
		/// This method also calls the SetPrimaryKey method to get the primary key for the particular table and 
		/// load it to the table object
		/// </summary>
		/// <param name="tableName">Name of the SQL table</param>
		/// <returns>DataTable containing the SQL data from the Database or null if table does not exist</returns>
		public DataTable GetDataTable(string tableName)
		{
			if (tableName == null)
				return null;

			DataTable dataTable = new DataTable
			{
				TableName = tableName,
			};

			LoadDataTable(dataTable); // Calling this method to Load the database table from the Database

			SetPrimaryKey(dataTable); //Calling this method to get the primary key for the table object and set it
			dataTable.AcceptChanges(); //Commits all the changes made to the datatable

			return dataTable;
		}

		/// <summary>
		/// This method get the primary keys from the database schema for the datatable passed
		/// and then sets those keys to the datatable object.
		/// This method is only called when the datatable needs to be filled from the database
		/// </summary>
		/// <param name="table">DataTable passed for which the primary keys are set</param>
		private void SetPrimaryKey(DataTable table)
		{
			if (table == null)
				return;

			// select command to get all the records from the database
			var sqlCommand = new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("SetPrimaryKey: " + sqlCommand.CommandText);

			// Using SqlDataReader to get the key columns after executing the above sqlCommand
			using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.KeyInfo))
			{
				//Getting the schema from the dataReader
				DataTable schema = dataReader.GetSchemaTable();

				//List to store all the primary key columns
				List<DataColumn> keyColumnList = new List<DataColumn>();

				//Iterating each row in the datatable schema to get the metadata about the primary keys
				foreach (DataRow row in schema.Rows)
				{
					//If the row is a primary key
					if ((bool)row["IsKey"] == true)
					{
						// Get the column index
						int columnOrdinal = (int)row["ColumnOrdinal"];

						// Checking if the column exists in the table
						if (columnOrdinal < table.Columns.Count)
						{
							//Adding the column to the List
							keyColumnList.Add(table.Columns[columnOrdinal]);
							Debug.WriteLine("  Primary Key found: " + table.TableName + " " +
								row["ColumnName"] + " Column " + columnOrdinal);
						}
					}
				}

				//Converting the Lis to an array and assigning it as the primary key column(s) of the Datatable passed
				table.PrimaryKey = keyColumnList.ToArray();
			}
		}

		/// <summary>
		/// This method gets all the records from the database table and fills he datatable passed to it.
		/// </summary>
		/// <param name="table">DataTable to be loaded</param>
		public void LoadDataTable(DataTable table)
		{
			//Clearing the contents of the datatable
			table.Clear();

			//Select query to select all the records from the database
			var sqlCommand =
				new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("LoadDataTable: " + sqlCommand.CommandText);

			//Creating a SqlDataReader to hold all the records from the select query
			using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
			{
				//Loading the datatable with the data in the dataReader
				table.Load(dataReader);
			}

			//Applying the changes to the datatable
			table.AcceptChanges();
		}


		/// <summary>
		/// This method is used to backup the dataset passed into an xml file
		/// The file is named the same name as that of the dataset
		/// </summary>
		/// <param name="dataSet">DataSet to be backed up</param>
		public void BackupDataSetToXML(DataSet dataSet)
		{
			if (dataSet == null)
			{
				Debug.WriteLine("BackupDataSetToXML: Error - null dataset");
				return;
			}

			Debug.WriteLine("BackupDataSetToXML: backing up to " + dataSet.DataSetName);

			// writes the DataSet to an xml file including the schema
			dataSet.WriteXml(dataSet.DataSetName + ".xml", XmlWriteMode.WriteSchema);
		}


	}
}
