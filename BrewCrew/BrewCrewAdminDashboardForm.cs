using BrewCrewDAL;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace BrewCrew
{
    /// <summary>
    /// This class opens the BrewCrewAdminDashboardForm which displays all the data from the drink, topping and customer 
    /// table from the database in the form of datagridview's.
    /// The drink and topping tables can be edited using sub forms. 
    /// The form displays total number of customers.
    /// The Backup button, backs up the database into an XML file
    /// THe View All Orders button, displays all the orders and their varied reports
    /// </summary>
    public partial class BrewCrewAdminDashboardForm : Form
    {
        BrewCrewEntities context;
        BrewCrewSignInForm signInForm;
        BrewCrewAdminDashboardOrdersSubForm adminDashboardOrdersSubForm;
        private DataSet brewCrewDataSet;
        SqlDataTableAccessLayer brewCrewDB;


        public BrewCrewAdminDashboardForm()
        {
            InitializeComponent();
            context = new BrewCrewEntities(); //saving DB context here
            brewCrewDB = new SqlDataTableAccessLayer(); // object to access sqldatatable method for backup purposes

            // Dataset to hold the data of all the table from the database, for backup purposes
            brewCrewDataSet = new DataSet()
            {

                DataSetName = "BrewCrewDataSet",
            };

            //Adding event handlers
            buttonAdminSignOut.Click += (s, e) => ShowSignInForm();
            this.FormClosed += (s, e) => ShowSignInForm();
            this.Load += AdminDashboardForm_Load;
            buttonAddUpdateMilkTea.Click += (s, e) => AddOrUpdateMilkTeaSubForm();
            buttonAddUpdateTeaToppings.Click += (s, e) => AddOrUpdateTeaToppingSubForm();
            buttonAllOrders.Click += (s, e) => AllOrdersSubForm();
            buttonBackupToXML.Click += (s, e) => BackUpToXML();
        }


        /// <summary>
        /// This method is called when Backup Database button is clicked, 
        /// it create a connection with the database and
        /// loads the dataset with tables from the database and backs up the dataset to an xml file
        /// </summary>
        private void BackUpToXML()
        {
            // getting the connection string for the database               
            string connectionString = brewCrewDB.GetConnectionString("BrewCrewEntities");

            // Creating and Opening the connection
            brewCrewDB.OpenConnection(connectionString);

            //Loading all the data from the tables to the dataset
            LoadDataSet(brewCrewDataSet, "Customer");
            LoadDataSet(brewCrewDataSet, "Drink");
            LoadDataSet(brewCrewDataSet, "Topping");
            LoadDataSet(brewCrewDataSet, "Order");
            LoadDataSet(brewCrewDataSet, "OrderDetails");

            brewCrewDB.BackupDataSetToXML(brewCrewDataSet); //backing up the database to an xml file

            //closing the connection
            brewCrewDB.CloseConnection();
        }

        /// <summary>
        /// This method is used o load database table data to the dataset
        /// </summary>
        /// <param name="dataSet">Dataset to which data has to be loaded</param>
        /// <param name="tableName">Tablename, whose data needs to be loaded</param>
        private void LoadDataSet(DataSet dataSet, String tableName)
        {
            //Get the data table for the table from the database 
            DataTable table = brewCrewDB.GetDataTable(tableName);
            //load datatable to the dataset
            dataSet.Tables.Add(table);
        }


        /// <summary>
        /// This method is called when View All Orders button is called, it opens the Orders sub form and hides this form
        /// </summary>
        private void AllOrdersSubForm()
        {
            context.Dispose(); //dispose the context
            adminDashboardOrdersSubForm = new BrewCrewAdminDashboardOrdersSubForm();
            adminDashboardOrdersSubForm.ShowDialog();
        }

        /// <summary>
        /// This method is called when this form loads, it initializes the datagridviews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            UpdateDataGridView();
        }

        /// <summary>
        /// This method is called when the Sign Out button is clicked or this form is closed, it opens the Sign In form and hides this form
        /// </summary>
        private void ShowSignInForm()
        {
            context.Dispose();
            signInForm = new BrewCrewSignInForm();
            this.Hide();
            signInForm.ShowDialog();

        }


        /// <summary>
        /// This method initializes the datagridviews with data from the database
        /// </summary>
        private void InitializeDataGridView()
        {
            //Load the drinks table to the db context
            context.Drinks.Load();
            dataGridViewAllMilkTea.DataSource = context.Drinks.Local.ToBindingList(); // assign the dbset drinks to the datasource of the datagridview
            dataGridViewAllMilkTea.AllowUserToAddRows = false; // No rows can be added
            dataGridViewAllMilkTea.Columns["OrderDetails"].Visible = false;
            dataGridViewAllMilkTea.Columns["DrinkID"].ReadOnly = true;
            dataGridViewAllMilkTea.Columns["DrinkID"].Width = 60;
            dataGridViewAllMilkTea.Columns["DrinkName"].Width = 170;
            dataGridViewAllMilkTea.Columns["DrinkDescription"].Width = 269;
            dataGridViewAllMilkTea.Columns["DrinkCalories"].Width = 90;
            dataGridViewAllMilkTea.Columns["DrinkPrice"].Width = 90;
            dataGridViewAllMilkTea.Columns["DrinkPrice"].DefaultCellStyle.Format = "c"; // currency format for the DrinkPrice column
            dataGridViewAllMilkTea.UserDeletedRow += (s, e) => SaveChangesAndUpdateDataGridViews(); // If a row is deleted by the admin,
                                                                                                    //this method is called to save changes to the database

            //Load the toppings table to the db context
            context.Toppings.Load();
            dataGridViewAllToppings.DataSource = context.Toppings.Local.ToBindingList(); // assign the dbset toppings to the datasource of the datagridview
            dataGridViewAllToppings.AllowUserToAddRows = false; // No rows can be added
            dataGridViewAllToppings.Columns["OrderDetails"].Visible = false;
            dataGridViewAllToppings.Columns["ToppingID"].ReadOnly = true;
            dataGridViewAllToppings.Columns["ToppingID"].Width = 80;
            dataGridViewAllToppings.Columns["ToppingName"].Width = 110;
            dataGridViewAllToppings.Columns["ToppingDescription"].Width = 240;
            dataGridViewAllToppings.Columns["ToppingCalories"].Width = 100;
            dataGridViewAllToppings.Columns["ToppingPrice"].Width = 80;
            dataGridViewAllToppings.Columns["ToppingPrice"].DefaultCellStyle.Format = "c"; // currency format for the DrinkPrice column
            dataGridViewAllToppings.UserDeletedRow += (s, e) => SaveChangesAndUpdateDataGridViews(); // If a row is deleted by the admin,
                                                                                                     //this method is called to save changes to the database

            //Query to get all customers except the admin
            var customerQuery = from customer in context.Customers
                                where customer.CustomerEmail.ToLower() != "admin@brewcrew.com"
                                select customer;
            dataGridViewAllCustomers.DataSource = customerQuery.ToList();// assign the result of above query to the datasource of the datagridview
            dataGridViewAllCustomers.ReadOnly = true; // read only datagridview
            dataGridViewAllCustomers.AllowUserToAddRows = false; // no rows can be added
            dataGridViewAllCustomers.AllowUserToDeleteRows = false; // no rows can be deleted
            dataGridViewAllCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAllCustomers.Columns["CustomerID"].Width = 70;
            dataGridViewAllCustomers.Columns["CustomerPhone"].Width = 90;
            dataGridViewAllCustomers.Columns["Orders"].Visible = false;

            labelTotalCustomers.Text = dataGridViewAllCustomers.Rows.Count.ToString(); // displaying the total number of customers

        }

        /// <summary>
        /// This method saves the changes made in the context to the database and updates the datagridviews to reflect changes
        /// </summary>
        private void SaveChangesAndUpdateDataGridViews()
        {
            if (context.ChangeTracker.HasChanges()) //Checks if any changes to the database are made
                //Records the number if changes made
                Debug.WriteLine("Save Changes and Update Registration: Changes " + context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).Count());
            else
            {
                // if no changes are made, a debug message is displayed
                Debug.WriteLine("Save Changes and Update Registration: No Changes, exiting methods.");
                return;
            }

            try
            {
                // save changes made to the database
                context.SaveChanges();
            }
            catch (Exception e)
            {
                // if errors in updating database, show a message in messagebox and exit the form
                MessageBox.Show("Error: Cannot update the database - exiting: " + e.InnerException.Message);
                Environment.Exit(1);
            }

            //Update datagridviews to show changes
            UpdateDataGridView();
        }


        /// <summary>
        /// This method refreshes the drinks and topping datagridview to reflect any changes made to them
        /// </summary>
        private void UpdateDataGridView()
        {
            dataGridViewAllMilkTea.Refresh();
            dataGridViewAllToppings.Refresh();
        }


        /// <summary>
        /// This method opens the BrewCrewAdminAddOrUpdateMilkTeaSubForm, from which the admin can edit/ add the entries of the
        /// database table. 
        /// If an entry is updated then, the method would get the entry using the primary key and reload the context from
        /// the database
        /// </summary>
        private void AddOrUpdateMilkTeaSubForm()
        {
            // Open the sub form
            BrewCrewAdminAddOrUpdateMilkTeaSubForm addOrUpdateMilkTeaSubForm = new BrewCrewAdminAddOrUpdateMilkTeaSubForm();
            var result = addOrUpdateMilkTeaSubForm.ShowDialog();

            // if the sub form is closed
            if (result == DialogResult.OK)
            {
                // Load the drinks table again to the context, to update changes
                context.Drinks.Load();

                // if any entry was updated in the subform, then the primary key is set
                //use it to get the entry from the database
                if (addOrUpdateMilkTeaSubForm.DrinkID >= 0)
                {
                    var entity = context.Drinks.Find(addOrUpdateMilkTeaSubForm.DrinkID);
                    if (entity != null) // is the entity is not null
                        context.Entry(entity).Reload(); // reload the context to get the updated data
                }

                //refresh the dataGridView to display changes
                dataGridViewAllMilkTea.Refresh();

                //reload the registration table to show changes
                UpdateDataGridView();

            }

            //hide the subform
            addOrUpdateMilkTeaSubForm.Hide();
        }


        /// <summary>
        /// This method opens the BrewCrewAdminAddOrUpdateTeaToppingSubForm, from which the admin can edit/ add the entries of the
        /// database table. 
        /// If an entry is updated then, the method would get the entry using the primary key and reload the context from
        /// the database
        /// </summary>
        private void AddOrUpdateTeaToppingSubForm()
        {
            // Open the sub form
            BrewCrewAdminAddOrUpdateTeaToppingsSubForm addOrUpdateTeaToppingSubForm = new BrewCrewAdminAddOrUpdateTeaToppingsSubForm();
            var result = addOrUpdateTeaToppingSubForm.ShowDialog();

            // if the sub form is closed
            if (result == DialogResult.OK)
            {
                // Load the toppings table again to the context, to update changes
                context.Toppings.Load();

                // if any entry was updated in the subform, then the primary key is set
                //use it to get the entry from the database
                if (addOrUpdateTeaToppingSubForm.ToppingID >= 0)
                {
                    var entity = context.Toppings.Find(addOrUpdateTeaToppingSubForm.ToppingID);
                    if (entity != null) // is the entity is not null
                        context.Entry(entity).Reload(); // reload the context to get the updated data
                }

                //refresh the dataGridView to display changes
                dataGridViewAllToppings.Refresh();

                //reload the registration table to show changes
                UpdateDataGridView();

            }

            //Hide the subform
            addOrUpdateTeaToppingSubForm.Hide();
        }


    }
}
