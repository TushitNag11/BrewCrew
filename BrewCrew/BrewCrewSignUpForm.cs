using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrewCrewDAL;// need to add a reference to use this
using System.Text.RegularExpressions;


namespace BrewCrew
{
    /// <summary>
    /// This class Sign's Up a new user to the BrewCrew application 
    /// The data entered by he user in the designated textboxes is checked againt validations
    /// If all of the data is correct then a Customer class object is  populated with the data and it is stored in the Customer table
    /// </summary>
    public partial class BrewCrewSignUpForm : Form
    {
        private BrewCrewEntities context;
        private Customer newCustomer;
        private BrewCrewSignInForm signInForm;


        public BrewCrewSignUpForm()
        {
            InitializeComponent();
            context = new BrewCrewEntities(); //DB context to save the data

            //Registering Event handlers
            buttonSignUp.Click += (s, e) => RegisterNewUser();
            this.FormClosed += (s, e) => ShowSignInForm();

        }

        /// <summary>
        /// This method is called when the form is closed, or after the user is registered
        /// The Sign In form appears as it is the main form for the application
        /// This form gets hidden.
        /// </summary>
        private void ShowSignInForm()
        {
            signInForm = new BrewCrewSignInForm();
            this.Hide();
            signInForm.ShowDialog();
        }


        /// <summary>
        /// This method gets called when the user clicks the Register button
        /// This method validates the texts in each of the textboxes of the form
        /// If the data is correct, then the customer object is populated and stored in the database table
        /// </summary>
        private void RegisterNewUser()
        {
            // Checks if any of textbox is not empty, else displays a message
            if (textboxNewUserFirstName.Text.Trim() == "" || textboxNewUserLastName.Text.Trim() == "" || textboxNewUserPhone.Text.Trim() == "" || textboxNewUserEmail.Text.Trim() == "")
            {
                MessageBox.Show("Fields Empty! Please fill in all the data.");
            }
            // Checks is the First Name and Last Name are all alphabets, else displays a message
            else if (!Regex.IsMatch(textboxNewUserFirstName.Text.Trim(), "^[a-zA-Z]+$") || !Regex.IsMatch(textboxNewUserLastName.Text.Trim(), "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter a valid firstname and lastname!");
            }
            // Checks is the Phone number is all numbers and not less than 10 digits, else displays a message
            else if (Regex.IsMatch(textboxNewUserPhone.Text.Trim(), "[^0-9]") || textboxNewUserPhone.Text.Length < 10)
            {
                MessageBox.Show("Please enter a valid 10 digit phone number!");
            }
            // Checks if the email entered is of the correct syntax, else displays a message 
            else if (Regex.IsMatch(textboxNewUserEmail.Text.Trim(), @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) == false)
            {
                MessageBox.Show("Please enter a valid email address!");
            }
            else
            {
                // If everything is correct,

                newCustomer = new Customer(); //Customer object for a new user
                // Populating all the fields of the Customer object with data
                newCustomer.CustomerFirstName = textboxNewUserFirstName.Text.Trim();
                newCustomer.CustomerLastName = textboxNewUserLastName.Text.Trim();
                newCustomer.CustomerEmail = textboxNewUserEmail.Text.Trim();
                newCustomer.CustomerPhone = textboxNewUserPhone.Text.Trim();
                // Adding the Customer object to the database context
                context.Customers.Add(newCustomer);
                // Inserting the new data to the database and Saving changes
                context.SaveChanges();

                ResetSignUpForm(); // Method to reset all the textboxes to blank

                //Dispose the database context
                context.Dispose();

                // Display SignInForm for the user to Sign In
                ShowSignInForm();
            }
        }

        /// <summary>
        /// This method resets this form by clearing the data in all the textboxes
        /// </summary>
        private void ResetSignUpForm()
        {
            textboxNewUserFirstName.Text = "";
            textboxNewUserLastName.Text = "";
            textboxNewUserPhone.Text = "";
            textboxNewUserEmail.Text = "";
        }
    }
}
