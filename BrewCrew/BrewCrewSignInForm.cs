using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BrewCrewDAL;
using System.Windows.Forms;
using System.Data.Entity;


namespace BrewCrew
{
    /// <summary>
    /// This class Sign In's a user/admin to the BrewCrew application based on the email address entered
    /// The email address is first validated and the is matched against the Customer email address in the database.
    /// If a match is found, then the appropriate screen is displayed
    /// </summary>
    public partial class BrewCrewSignInForm : Form
    {
        private BrewCrewEntities context;
        private BrewCrewSignUpForm signUpForm;
        private BrewCrewMenuForm brewCrewMenuForm;
        private BrewCrewAdminDashboardForm adminDashboardForm;
        readonly string adminEmail = "admin@brewcrew.com"; // read only string to hold the admin email address
        private Customer customer;
        public BrewCrewSignInForm()
        {
            InitializeComponent();
            context = new BrewCrewEntities(); //DB context to save the data

            //Registering Event handlers
            buttonRegister.Click += (s, e) => OpenSignUpForm();
            buttonSignIn.Click += (s, e) => SignInToBrewCrew();
            this.FormClosed += (s, e) => ExitApplication();
        }

        /// <summary>
        /// This method is called when the form is closed, it disposes the context and exists the application
        /// </summary>
        private void ExitApplication()
        {
            context.Dispose();
            Environment.Exit(1);
        }

        /// <summary>
        ///  This method is called when the Register button is clicked, it hides this form and opens the SignInForm
        /// </summary>
        private void OpenSignUpForm()
        {
            this.Hide();
            signUpForm = new BrewCrewSignUpForm();
            signUpForm.ShowDialog();
        }

        /// <summary>
        /// This method is called when the Sign In button is clicked, the email address enetered by the user is validated
        /// and matched with the entries in the database and the corresponding screen opens up.
        /// </summary>
        private void SignInToBrewCrew()
        {
            // Checks if the textbox is empty, else displays a message
            if (textBoxUserEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an email to sign in!");
            }
            // Loads the Customer Dbset into the context and searches for the email address entered by the user.
            else
            {
                context.Customers.Load();
                //Search query to find and return the customer object matching the email address
                customer = context.Customers.Local.Where(x => x.CustomerEmail.ToLower() == textBoxUserEmail.Text.Trim().ToLower()).FirstOrDefault();
                //If the customer object is null, i.e. no record is found, then display a message
                if (customer == null)
                {
                    MessageBox.Show("Please enter a valid email. If you are a new customer please click on Register");
                }
                else
                {
                    // Checks if the customer address matches the email address of admin
                    if (customer.CustomerEmail.ToLower() == adminEmail.ToLower())
                    {
                        // If is matches, then open the Admin Dashboard Form, and hide this form
                        this.Hide();
                        adminDashboardForm = new BrewCrewAdminDashboardForm();
                        adminDashboardForm.ShowDialog();
                    }
                    else
                    {
                        //else, open the Menu form, and hide this form
                        this.Hide();
                        brewCrewMenuForm = new BrewCrewMenuForm(customer); //Customer data is passed to the menu form
                        brewCrewMenuForm.ShowDialog();
                    }
                }
            }
        }
    }
}