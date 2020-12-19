using BrewCrewDAL; // need to add a reference to use this
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity; // need this for ToBindingList()
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace BrewCrew
{
    /// <summary>
    /// This form opens the BrewCrewMenuForm, which displays drink and topping data in datagridview's 
    /// for the customer to select and add to the cart. Once the customer's are satisfied with cart items,
    /// they can place order by clicking on the place order button
    /// </summary>
    public partial class BrewCrewMenuForm : Form
    {

        private BrewCrewEntities context;
        private BrewCrewCustomerOrderReceiptForm orderReceipt;
        private BrewCrewSignInForm signInForm;
        private Customer customer;
        private BindingList<BrewCrewOrderCart> cart = new BindingList<BrewCrewOrderCart>(); // cart to hold items in the customer cart 
                                                                                            // datagridview.
        private Order order;
        private OrderDetail orderDetail;
        decimal orderTotal = 0;

        public BrewCrewMenuForm(Customer customer)
        {

            context = new BrewCrewEntities(); //saving DB context here
            this.customer = customer; // Customer data passed from the Sign In form
            InitializeComponent();
            //Adding Event handlers
            this.Load += BrewCrewMenuForm_Load;
            this.FormClosed += (s, e) => ShowSignInForm();
            buttonAddToCart.Click += (s, e) => AddSelectionToCart();
            buttonPlaceOrder.Click += (s, e) => PlaceOrder();
            buttonRemoveFromCart.Click += (s, e) => RemoveFromCart();
            buttonSignOut.Click += (s, e) => ShowSignInForm();

        }

        /// <summary>
        /// This method is called when the form is closed, or the Sign Out button is click, 
        /// it hides this form and displays the BrewCrewSignInForm for another user to Sign In to the application
        /// </summary>
        private void ShowSignInForm()
        {
            context.Dispose(); // disposes the context
            signInForm = new BrewCrewSignInForm();
            this.Hide();
            signInForm.ShowDialog();
        }

        /// <summary>
        /// This method is an event handler which gets called when this form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrewCrewMenuForm_Load(object sender, EventArgs e)
        {
            IntitializeDataGridview(); //Initializing the datagridviews with data from the database
        }

        /// <summary>
        /// This method initializes he datagridview in the form, by loading data from the database into the context
        /// The cart datagridview is initialized by data in the cart list.
        /// All the datagridviews are readonly
        /// </summary>
        private void IntitializeDataGridview()
        {
            //Adding Drink table to the drink datagridview
            context.Drinks.Load(); //Loading data from the database to the context
            dataGridViewCustomerAllMilkTea.DataSource = context.Drinks.Local.ToBindingList(); // setting the datasource as a binding list
            dataGridViewCustomerAllMilkTea.ReadOnly = true; //Read only datagridview
            dataGridViewCustomerAllMilkTea.AllowUserToAddRows = false; //No row is allowed to be added
            dataGridViewCustomerAllMilkTea.AllowUserToDeleteRows = false; //no row is allowed to be deleted
            dataGridViewCustomerAllMilkTea.Columns["OrderDetails"].Visible = false;
            dataGridViewCustomerAllMilkTea.Columns["DrinkID"].Width = 60;
            dataGridViewCustomerAllMilkTea.Columns["DrinkName"].Width = 170;
            dataGridViewCustomerAllMilkTea.Columns["DrinkDescription"].Width = 530;
            dataGridViewCustomerAllMilkTea.Columns["DrinkCalories"].Width = 90;
            dataGridViewCustomerAllMilkTea.Columns["DrinkPrice"].Width = 90;
            dataGridViewCustomerAllMilkTea.Columns["DrinkPrice"].DefaultCellStyle.Format = "c"; // Currency format for DrinkPrice column




            //Adding Topping table to the topping DataGridView
            context.Toppings.Load(); //Loading data from the database to the context
            dataGridViewCustomerAllToppings.DataSource = context.Toppings.Local.ToBindingList(); // setting the datasource as a binding list
            dataGridViewCustomerAllToppings.ReadOnly = true; //Read only datagridview
            dataGridViewCustomerAllToppings.AllowUserToAddRows = false; //No row is allowed to be added
            dataGridViewCustomerAllToppings.AllowUserToDeleteRows = false; //no row is allowed to be deleted
            dataGridViewCustomerAllToppings.Columns["OrderDetails"].Visible = false;
            dataGridViewCustomerAllToppings.Columns["ToppingID"].Width = 80;
            dataGridViewCustomerAllToppings.Columns["ToppingName"].Width = 110;
            dataGridViewCustomerAllToppings.Columns["ToppingDescription"].Width = 320;
            dataGridViewCustomerAllToppings.Columns["ToppingCalories"].Width = 100;
            dataGridViewCustomerAllToppings.Columns["ToppingPrice"].Width = 90;
            dataGridViewCustomerAllToppings.Columns["ToppingPrice"].DefaultCellStyle.Format = "c"; // Currency format for ToppingPrice column

            dataGridViewCustomerCart.DataSource = cart; // Loading data from the cart list 
            dataGridViewCustomerCart.ReadOnly = true; //Read only datagridview
            dataGridViewCustomerCart.AllowUserToAddRows = false; //No row is allowed to be added
            dataGridViewCustomerCart.AllowUserToDeleteRows = false; //no row is allowed to be deleted
            dataGridViewCustomerCart.Columns["DrinkID"].Visible = false;
            dataGridViewCustomerCart.Columns["ToppingID"].Visible = false;
            dataGridViewCustomerCart.Columns["DrinkName"].Width = 210;
            dataGridViewCustomerCart.Columns["ToppingName"].Width = 150;
            dataGridViewCustomerCart.Columns["Quantity"].Width = 100;
            dataGridViewCustomerCart.Columns["TotalCalories"].Width = 110;
            dataGridViewCustomerCart.Columns["SelectionPrice"].Width = 120;
            dataGridViewCustomerCart.Columns["SelectionPrice"].DefaultCellStyle.Format = "c"; // Currency format for TotalPrice column
            dataGridViewCustomerCart.Columns["TotalPrice"].Width = 100;
            dataGridViewCustomerCart.Columns["TotalPrice"].DefaultCellStyle.Format = "c"; // Currency format for TotalPrice column
        }

        /// <summary>
        /// This method is called when a the Add to Cart button is clicked.
        /// This method gets all the data from the drink and topping datagridview and creates a brewCrewOrderCart object with that data
        /// and puts the object into the cart list.
        /// This cart list is used to create the order, when place order button is clicked
        /// </summary>
        private void AddSelectionToCart()
        {
            // Validate the value entered in the quantity textbox, else display a message
            if (textBoxDrinkQuantity.Text.Trim() == "" || Regex.IsMatch(textBoxDrinkQuantity.Text.Trim(), "[^1-9]"))
            {
                ClearOrder();
                MessageBox.Show("Please enter a valid Bubble Tea quantity!");
            }
            else
            {
                // Get all the data from the datagridview selected rows
                int drinkId = int.Parse(dataGridViewCustomerAllMilkTea.CurrentRow.Cells[0].Value.ToString());
                string drinkName = dataGridViewCustomerAllMilkTea.CurrentRow.Cells[1].Value.ToString();
                int drinkCalories = int.Parse(dataGridViewCustomerAllMilkTea.CurrentRow.Cells[3].Value.ToString());
                decimal drinkPrice = decimal.Parse(dataGridViewCustomerAllMilkTea.CurrentRow.Cells[4].Value.ToString());

                int toppingId = int.Parse(dataGridViewCustomerAllToppings.CurrentRow.Cells[0].Value.ToString());
                string toppingName = dataGridViewCustomerAllToppings.CurrentRow.Cells[1].Value.ToString();
                int toppingCalories = int.Parse(dataGridViewCustomerAllToppings.CurrentRow.Cells[3].Value.ToString());
                decimal toppingPrice = decimal.Parse(dataGridViewCustomerAllToppings.CurrentRow.Cells[4].Value.ToString());

                //Calculate total calories and price for the selection
                int totalCalories = drinkCalories + toppingCalories;
                decimal selectionTotalPrice = drinkPrice + toppingPrice;

                //get the quantity from the textbox
                int quantity = int.Parse(textBoxDrinkQuantity.Text.Trim());

                //Calculate the total price for the combination with quantity 
                decimal comboTotalPrice = quantity * selectionTotalPrice;

                //Add the cartTotal to the order total
                orderTotal += comboTotalPrice;

                //display the order total
                labelOrderTotal.Text = orderTotal.ToString("c2");

                // create an object of BrewCrewOrderCart class with the appropriate data and add it to the cart
                cart.Add(new BrewCrewOrderCart
                {
                    DrinkID = drinkId,
                    DrinkName = drinkName,
                    ToppingID = toppingId,
                    ToppingName = toppingName,
                    Quantity = quantity,
                    TotalCalories = totalCalories,
                    SelectionPrice = selectionTotalPrice,
                    TotalPrice = comboTotalPrice
                });

                //Reflect changes in the cart datagridview
                dataGridViewCustomerCart.Refresh();

                //Enable the Place order button
                buttonPlaceOrder.Enabled = true;

                //Clear the quantity textbox
                ClearOrder();
            }
        }


        /// <summary>
        /// This method is called when the Place Order button is clicked.
        /// This method inserts data from the cart list to the Order and OrderDetail table and open the
        /// BrewCrewCustomerOrderReceiptForm
        /// </summary>
        private void PlaceOrder()
        {
            //Create a order object
            order = new Order();

            //Populate the order object with data
            order.TotalPrice = orderTotal;
            order.CustomerID = customer.CustomerID; //from ths customer object passed from the SignInForm
            order.Date = DateTime.Now; //Today's date

            //Add the order object to the dbset order
            context.Orders.Add(order);

            //for each item in the cart list
            for (int i = 0; i < cart.Count; i++)
            {
                //create a ordeDetail object
                orderDetail = new OrderDetail();

                //Populate the order detail object
                orderDetail.OrderID = order.OrderID;
                orderDetail.DrinkID = cart[i].DrinkID;
                orderDetail.ToppingID = cart[i].ToppingID;
                orderDetail.DrinkQuantity = cart[i].Quantity;

                //Add the orderDetail object to the dbset orderDetail
                context.OrderDetails.Add(orderDetail);

            }


            // Apply the changes to the database
            context.SaveChanges();

            // Hide is form and open BrewCrewCustomerOrderReceiptForm, with order, cart and customer objects
            this.Hide();
            orderReceipt = new BrewCrewCustomerOrderReceiptForm(order, cart, customer);
            orderReceipt.ShowDialog();



        }

        /// <summary>
        /// This method is called when Add To Order button is clicked, the quantity textbox data gets erased
        /// </summary>
        private void ClearOrder()
        {
            textBoxDrinkQuantity.Text = "";
        }

        /// <summary>
        /// This method is called when Remove from Cart button is clicked, it removes the selected datagridview row
        /// and adjusts the orderTotal
        /// </summary>
        private void RemoveFromCart()
        {
            // Subtract from the orderTotal 
            orderTotal -= (cart[dataGridViewCustomerCart.CurrentRow.Index].TotalPrice);
            labelOrderTotal.Text = orderTotal.ToString("c2");
            cart.RemoveAt(dataGridViewCustomerCart.CurrentRow.Index);

            //Disabling Place Order button if no data is in the datagridview
            if (dataGridViewCustomerCart.Rows.Count == 0 && orderTotal == 0)
                buttonPlaceOrder.Enabled = false;


        }


    }
}
