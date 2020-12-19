using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BrewCrewDAL; // need to add a reference to use this


namespace BrewCrew
{
    /// <summary>
    /// This class opens the form BrewCrewCustomerOrderReceiptForm which displays the customer order details and the 
    /// a QR code based on the order number 
    /// </summary>
    public partial class BrewCrewCustomerOrderReceiptForm : Form
    {
        private Order order;
        private Customer customer;
        private BindingList<BrewCrewOrderCart> cart;
        private BrewCrewSignInForm signInForm;
        private BrewCrewMenuForm brewCrewMenuForm;

        public BrewCrewCustomerOrderReceiptForm(Order order, BindingList<BrewCrewOrderCart> cart, Customer customer)
        {
            InitializeComponent();
            // Intialize the order, cart and customer object from the data sent from BrewCrewMenuForm
            this.order = order;
            this.cart = cart;
            this.customer = customer;

            //Adding event listeners
            this.Load += (s, e) => InitializeForm();
            this.FormClosed += (s, e) => ShowMenuForm();
            buttonSignOut.Click += (s, e) => ShowSignInForm();
        }


        /// <summary>
        /// This method is called when Sign Out button is clicked, it opens the Sign In form and hides this form
        /// </summary>
        private void ShowSignInForm()
        {
            signInForm = new BrewCrewSignInForm();
            this.Close();
            this.Hide();
            signInForm.ShowDialog();
        }

        /// <summary>
        /// This method is called when this form is closed, it opens the Menu form and hides this form
        /// </summary>
        private void ShowMenuForm()
        {
            brewCrewMenuForm = new BrewCrewMenuForm(customer); //sending the customer object back
            this.Close();
            this.Hide();
            brewCrewMenuForm.ShowDialog();
        }

        /// <summary>
        /// This method is called when this form load, it displays the order details in the datagridview,
        /// order number, order date and a Qr Code for the order.
        /// </summary>
        private void InitializeForm()
        {
            //set the order id and date from the order object 
            labelOrderNumber.Text = order.OrderID.ToString();
            labelOrderDate.Text = order.Date.ToString("MM/dd/yyyy");

            //Create headers for the datagridview
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn() { Name = "Drink Name" },
                new DataGridViewTextBoxColumn() { Name = "Topping Name"},
                new DataGridViewTextBoxColumn() { Name = "Quantity"},
                new DataGridViewTextBoxColumn() { Name = "Selection Price"},
                new DataGridViewTextBoxColumn() { Name = "Total Price"},
            };

            //Adding the columns to the data grid view
            dataGridViewOrderDetails.Columns.AddRange(columns);

            //datagridview is readonly, with no rows added or deleted
            dataGridViewOrderDetails.ReadOnly = true;
            dataGridViewOrderDetails.AllowUserToAddRows = false;
            dataGridViewOrderDetails.AllowUserToDeleteRows = false;
            dataGridViewOrderDetails.Columns["Drink Name"].Width = 200;
            dataGridViewOrderDetails.Columns["Topping Name"].Width = 150;
            dataGridViewOrderDetails.Columns["Quantity"].Width = 100;
            dataGridViewOrderDetails.Columns["Selection Price"].Width = 110;
            dataGridViewOrderDetails.Columns["Selection Price"].DefaultCellStyle.Format = "c"; // currency format for the selection price column
            dataGridViewOrderDetails.Columns["Total Price"].Width = 110;
            dataGridViewOrderDetails.Columns["Total Price"].DefaultCellStyle.Format = "c"; // currency format for the total price column

            // adding data to the datagridview from the cart list
            for (int i = 0; i < cart.Count; i++)
            {
                dataGridViewOrderDetails.Rows.Add(cart[i].DrinkName, cart[i].ToppingName, cart[i].Quantity, cart[i].SelectionPrice, cart[i].TotalPrice);
            }

            // displaying the order total
            labelOrderTotal.Text = order.TotalPrice.ToString("c2");

            // method to generate OR code
            GenerateQRCode();
        }

        /// <summary>
        /// This method create a QR code using the Zen package installed for the application
        /// from the order id
        /// </summary>
        private void GenerateQRCode()
        {
            Zen.Barcode.CodeQrBarcodeDraw qrBarcodeDraw = Zen.Barcode.BarcodeDrawFactory.CodeQr;

            //Displays the QR code in the picturebox
            pictureBoxQRCode.Image = qrBarcodeDraw.Draw(labelOrderNumber.Text, 5);
        }


    }
}
