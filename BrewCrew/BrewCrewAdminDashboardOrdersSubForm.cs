using BrewCrewDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewCrew
{
    /// <summary>
    /// This class opens tje BrewCrewAdminDashboardOrdersSubForm which displays all the orders in the database
    /// Filters are provided in the form to generate reports based on the data in the orders datagridview
    /// </summary>
    public partial class BrewCrewAdminDashboardOrdersSubForm : Form
    {
        BrewCrewEntities context;
        List<CustomerOrders> customerOrders;
        public BrewCrewAdminDashboardOrdersSubForm()
        {
            InitializeComponent();

            context = new BrewCrewEntities(); // saving the db context
            // Adding event listeners
            this.Load += AdminDashboardOrdersSubForm_Load;
            this.FormClosed += (s, e) => OpenAdminForm();
            buttonReset.Click += (s, e) => ResetControlsToDefault();
            dateTimePickerFilterByDate.ValueChanged += DateTimePickerFilterByDate_ValueChanged;
            radioButtonFilterByDate.CheckedChanged += RadioButtonFilterByDate_CheckedChanged;
            radioButtonFilterDataByDateToday.CheckedChanged += RadioButtonFilterDataByDateToday_CheckedChanged;
            checkBoxFilterByOrderID.CheckedChanged += CheckBoxFilterByOrderID_CheckedChanged;
            textBoxCustomerEmail.TextChanged += TextBoxCustomerEmail_TextChanged;
            textBoxOrderID.TextChanged += TextBoxOrderID_TextChanged;
        }

        /// <summary>
        /// This method is called when Filter by OrderID checkbox is checked/unchecked
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxFilterByOrderID_CheckedChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when radioButtonFilterDataByDateToday is checked/unchecked
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonFilterDataByDateToday_CheckedChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when radioButtonFilterByDate is checked/unchecked
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when the dateTimePickerFilterByDate value is changed
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePickerFilterByDate_ValueChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when the value of textboxOrderID is changed
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxOrderID_TextChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when the value of textboxCustomerEmail is changed
        /// Displays filtered data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCustomerEmail_TextChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when this form is closed, it opens adminDashboardForm and hides this form
        /// </summary>
        private void OpenAdminForm()
        {
            context.Dispose();
            this.Hide();
           
        }

        /// <summary>
        /// This method is called when this form load, it initializes all the form controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminDashboardOrdersSubForm_Load(object sender, EventArgs e)
        {
            InitializeData();
            InitializeDataGridView();
            InitializeFormComponents();
            ResetControlsToDefault();
        }

        /// <summary>
        /// This method gets all the required data to be displayed in the datagridview from the dbset in orders
        /// and orderDetails and saves into a list of objects of type CustomerOrders, which is a class that
        /// holds the properties
        /// to display data in the datagridview
        /// </summary>
        private void InitializeData()
        {
            //Query to get all the data from Orders and OrderDetail tables and create CustomerOrder object
            var allOrders = (from order in context.Orders
                             from orderDetail in order.OrderDetails
                             orderby order.OrderID
                             select new CustomerOrders
                             {
                                 OrderID = order.OrderID,
                                 CustomerEmail = order.Customer.CustomerEmail,
                                 DrinkName = orderDetail.Drink.DrinkName,
                                 ToppingName = orderDetail.Topping.ToppingName,
                                 TotalCalories = orderDetail.Drink.DrinkCalories + orderDetail.Topping.ToppingCalories,
                                 Quantity = orderDetail.DrinkQuantity,
                                 SelectionPrice = (orderDetail.Drink.DrinkPrice + orderDetail.Topping.ToppingPrice) * orderDetail.DrinkQuantity,
                                 OrderPrice = order.TotalPrice,
                                 OrderDate = order.Date.ToString(),
                                 OrderDetails = orderDetail

                             });

            //Convert the result into a list of type CustomerOrders
            customerOrders = allOrders.ToList();
        }

        /// <summary>
        /// This method initializes all the form components, except the datagridviews in the form
        /// </summary>
        private void InitializeFormComponents()
        {
            // Clear all the items in the listboxes
            listBoxAllDrinks.Items.Clear();
            listBoxAllToppings.Items.Clear();

            //Makes the selection mode for the listboxes as MultiExtended
            listBoxAllDrinks.SelectionMode = SelectionMode.MultiExtended;
            listBoxAllToppings.SelectionMode = SelectionMode.MultiExtended;

            //Select the DrinkName and ToppingName from all the items in the customerOrders list 
            var drinks = customerOrders.Select(n => n.DrinkName).Distinct().OrderBy(n => n);
            var toppings = customerOrders.Select(n => n.ToppingName).Distinct().OrderBy(n => n);

            //Add the result from the selected query to the listboxes
            listBoxAllDrinks.Items.AddRange(drinks.ToArray());
            listBoxAllToppings.Items.AddRange(toppings.ToArray());
        }

        /// <summary>
        /// This method resets all the form controls to their intial form 
        /// </summary>
        private void ResetControlsToDefault()
        {
            // Remove the selected index changed event listener from the listboxes
            listBoxAllDrinks.SelectedIndexChanged -= ListBoxAllDrinks_SelectedIndexChanged;
            listBoxAllToppings.SelectedIndexChanged -= ListBoxAllToppings_SelectedIndexChanged;

            //Set all the items in the listbox as selected
            for (int i = 0; i < listBoxAllDrinks.Items.Count; i++)
                listBoxAllDrinks.SetSelected(i, true);

            for (int i = 0; i < listBoxAllToppings.Items.Count; i++)
                listBoxAllToppings.SetSelected(i, true);

            // Clear the textboxes, set the checkbox and radioboxes as false, and reset the text of datetimepicker
            dateTimePickerFilterByDate.ResetText();
            radioButtonFilterByDate.Checked = false;
            radioButtonFilterDataByDateToday.Checked = false;
            checkBoxFilterByOrderID.Checked = false;

            textBoxCustomerEmail.Clear();
            textBoxOrderID.Clear();

            //Display data in the datagridview based on the control values
            DisplayData();

            //Add the selected index changed event listner back to the listboxes
            listBoxAllDrinks.SelectedIndexChanged += ListBoxAllDrinks_SelectedIndexChanged;
            listBoxAllToppings.SelectedIndexChanged += ListBoxAllToppings_SelectedIndexChanged;
        }

        /// <summary>
        /// This method is called when any selection in the listboxAllToppings is changed
        /// Displays the data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxAllToppings_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method is called when any selection in the listboxAllDrinks is changed
        /// Displays the data in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxAllDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// This method initializes the orders datagridview in the form 
        /// </summary>
        private void InitializeDataGridView()
        {

            dataGridViewAllOrders.ReadOnly = true;
            dataGridViewAllOrders.AllowUserToAddRows = false;
            dataGridViewAllOrders.AllowUserToDeleteRows = false;
            dataGridViewAllOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewAllOrders.RowHeadersVisible = false;
            dataGridViewAllOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAllOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAllOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAllOrders.Columns.Clear();

            //Creating an array of textbox columns for the datagridview column
            // Each textbox object contains the name/header of the column and an optional MinimumWidth property to set the width of the column
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn() { Name = "OrderID", MinimumWidth = 50},
                new DataGridViewTextBoxColumn() { Name = "CustomerEmail", MinimumWidth = 110},
                new DataGridViewTextBoxColumn() { Name = "DrinkName", MinimumWidth = 150},
                new DataGridViewTextBoxColumn() { Name = "ToppingName", MinimumWidth = 100},
                new DataGridViewTextBoxColumn() { Name = "TotalCalories", MinimumWidth = 70},
                new DataGridViewTextBoxColumn() { Name = "Quantity", MinimumWidth = 50},
                new DataGridViewTextBoxColumn() { Name = "SelectionPrice", MinimumWidth = 80 , DefaultCellStyle =  new DataGridViewCellStyle
                {
                    Format = "c" //sets the format as currecy
                } },
                new DataGridViewTextBoxColumn() { Name = "OrderPrice", MinimumWidth = 40, DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "c" //sets the format as currecy
                } },
                new DataGridViewTextBoxColumn() { Name = "OrderDate", MinimumWidth = 60 }
            };


            //Adding the array as a column headers of the dataGridView
            dataGridViewAllOrders.Columns.AddRange(columns);

            //Display the data 
            DisplayData();

        }

        /// <summary>
        /// This method displays the data in the orders datagridview based on the selections made in the 
        /// various filters of the form
        /// </summary>
        private void DisplayData()
        {
            //List to get all the selected drinks and topping in the listboxes
            List<String> selectedDrinks = new List<String>();
            List<String> selectedToppings = new List<String>();

            //Get all the selected drinks and topping from the listboxes
            for (int i = 0; i < listBoxAllDrinks.SelectedItems.Count; i++)
                selectedDrinks.Add(listBoxAllDrinks.SelectedItems[i].ToString());

            for (int i = 0; i < listBoxAllToppings.SelectedItems.Count; i++)
                selectedToppings.Add(listBoxAllToppings.SelectedItems[i].ToString());

            String customerEmail = "";
            //Get the customer email from textbox
            if (textBoxCustomerEmail.Text.Trim() != "")
                customerEmail = textBoxCustomerEmail.Text.Trim().ToUpper();

            //Get the date from the datetimepicker
            DateTime date = DateTime.Parse(dateTimePickerFilterByDate.Value.ToString("MM/dd/yyyy"));

            //get the orderId from the textbox
            int orderID = 0;
            if (checkBoxFilterByOrderID.Checked == true)
            {
                //Check if the orderId is int, else display a message
                if (!int.TryParse(textBoxOrderID.Text.Trim(), out orderID))
                {
                    textBoxOrderID.Clear();
                    MessageBox.Show("Please enter a valid Order ID");
                }
            }

            //query to get all the orders based on the filters selected by the user
            var selectedOrders = from orders in customerOrders
                                 join drink in selectedDrinks on orders.DrinkName equals drink
                                 join topping in selectedToppings on orders.ToppingName equals topping
                                 where orders.CustomerEmail.ToUpper().Contains(customerEmail)
                                 && ((checkBoxFilterByOrderID.Checked == true && orders.OrderID == orderID) || (checkBoxFilterByOrderID.Checked == false))
                                 && ((radioButtonFilterDataByDateToday.Checked == true && DateTime.Parse(orders.OrderDate) >= date) || (radioButtonFilterDataByDateToday.Checked == false))
                                 && ((radioButtonFilterByDate.Checked == true && DateTime.Parse(orders.OrderDate) == date) || (radioButtonFilterByDate.Checked == false))
                                 select orders;

            //Clear the datagridview rows
            dataGridViewAllOrders.Rows.Clear();

            // Iterating items in the query to add rows to the dataGridView
            foreach (CustomerOrders order in selectedOrders)
                dataGridViewAllOrders.Rows.Add(order.OrderID, order.CustomerEmail, order.DrinkName, order.ToppingName, order.TotalCalories,
                    order.Quantity, order.SelectionPrice, order.OrderPrice, order.OrderDate);

            //Setting the labels with total orders count and profit
            labelTotalOrders.Text = selectedOrders.Count().ToString();
            labelTotalProfit.Text = selectedOrders.Sum(x => x.SelectionPrice).ToString("c2");
        }

        /// <summary>
        /// This class is used to store data from the order, orderdetails, drink, topping and customer table to
        /// display the orders datagridview
        /// </summary>
        private class CustomerOrders
        {
            [DisplayName("Order ID")] //used to set column headers in dataGridView
            public int OrderID { get; set; }

            [DisplayName("Customer Email")]
            public string CustomerEmail { get; set; }

            [DisplayName("Drink Name")]
            public string DrinkName { get; set; }

            [DisplayName("Topping Name")]
            public string ToppingName { get; set; }

            [DisplayName("Total Calories")]
            public int TotalCalories { get; set; }

            [DisplayName("Quantity")]
            public decimal Quantity { get; set; }

            [DisplayName("Selection Price")]
            public decimal SelectionPrice { get; set; }

            [DisplayName("Order Price")]
            public decimal OrderPrice { get; set; }

            [DisplayName("Order Date")]
            public String OrderDate { get; set; }

            public OrderDetail OrderDetails { get; set; }




        }
    }
}
