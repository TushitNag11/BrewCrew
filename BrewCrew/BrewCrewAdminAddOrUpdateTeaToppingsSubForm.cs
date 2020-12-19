using BrewCrewDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewCrew
{
    /// <summary>
    /// This class opens the BrewCrewAdminAddOrUpdateTeaToppingSubForm.
    /// Sub form to add or update data in Topping table in the database
    /// </summary>
    public partial class BrewCrewAdminAddOrUpdateTeaToppingsSubForm : Form
    {
        //Property for the identity ToppingID
        public int ToppingID { get; set; }

        private BrewCrewEntities context;
        public BrewCrewAdminAddOrUpdateTeaToppingsSubForm()
        {
            InitializeComponent();
            //Adding event listeners
            this.Load += AdminAddOrUpdateTeaToppingsSubForm_Load; ;
            buttonAddNewTeaTopping.Click += ButtonAddNewTeaTopping_Click; ;
            buttonUpdateTeaTopping.Click += ButtonUpdateTeaTopping_Click; ;
            listBoxTeaTopping.SelectedIndexChanged += (s, e) => GetTopping();
            this.FormClosed += (s, e) => context.Dispose();
        }

        /// <summary>
        /// This method is called when the selection in the listboxTeaTopping is changed
        /// It gets the particular selected topping from the database and populates the corresponding textboxes
        /// </summary>
        private void GetTopping()
        {
            //Checks if the selected item is of type Topping
            if (!(listBoxTeaTopping.SelectedItem is Topping topping))
                return;

            textBoxTeaToppingName.Text = topping.ToppingName;
            textBoxToppingDescription.Text = topping.ToppingDescription;
            textBoxToppingCalories.Text = topping.ToppingCalories.ToString();
            textBoxToppingPrice.Text = topping.ToppingPrice.ToString();
            ToppingID = topping.ToppingID;
        }

        /// <summary>
        /// This event handler is called when update button is clicked
        /// It gets the selected topping object from the listbox and tries to save the changes made in the textboxes
        /// to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdateTeaTopping_Click(object sender, EventArgs e)
        {
            //Checks if the selected item is of type Topping, else displays a message 
            if (!(listBoxTeaTopping.SelectedItem is Topping topping))
            {
                MessageBox.Show("Please select a topping to update.");
                return;
            }
            // Checks if any textbox is empty, else displays a message
            else if (textBoxTeaToppingName.Text.Trim().Length == 0 || textBoxToppingDescription.Text.Trim().Length == 0 ||
                textBoxToppingCalories.Text.Trim().Length == 0 || textBoxToppingPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill all the fields! Topping information is missing.");
                return;
            }
            else
            {
                //Search for the drink that is selected in the listbox 
                Topping newTopping = context.Toppings.FirstOrDefault(t => t.ToppingID == topping.ToppingID);

                //check if the new topping already exists and is different than the selected topping, 
                //if yes, then the topping cannot be updated 
                if (newTopping != null && newTopping != topping)
                {
                    MessageBox.Show("Topping cannot be updated, already exists!");
                }
                else
                {
                    // Parse the calorie and price textboxes
                    if (int.TryParse(textBoxToppingCalories.Text.Trim(), out int calories) && decimal.TryParse(textBoxToppingPrice.Text.Trim(), out decimal price))
                    {
                        // populate the topping object with values from the textboxes
                        topping.ToppingName = textBoxTeaToppingName.Text.Trim();
                        topping.ToppingDescription = textBoxToppingDescription.Text.Trim();
                        topping.ToppingCalories = calories;
                        topping.ToppingPrice = price;

                        try
                        {
                            // save changes to the database
                            context.SaveChanges();

                            //Set the ToppingId property 
                            ToppingID = topping.ToppingID;
                        }
                        catch (Exception ex)
                        {
                            //If exception occues, display a message
                            MessageBox.Show("Cannot update Topping to database" + ex.InnerException.InnerException.Message);
                            return;
                        }
                        //Set the DialogResult to OK, dispose the context and close the form.
                        this.DialogResult = DialogResult.OK;
                        context.Dispose();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Calorie or price format not correct. Please enter valid data!");
                    }
                }
            }

        }

        /// <summary>
        /// This method is called when the Add button is clicked, 
        /// It validates the data in the textboxes and add the new topping to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNewTeaTopping_Click(object sender, EventArgs e)
        {
            // Check if textboxes are not empty, else display a message
            if (textBoxTeaToppingName.Text.Trim().Length == 0 || textBoxToppingDescription.Text.Trim().Length == 0 ||
                textBoxToppingCalories.Text.Trim().Length == 0 || textBoxToppingPrice.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Topping information is missing!");
                return;
            }
            else
            {
                // Parse the data in the calorie and price textbox
                if (int.TryParse(textBoxToppingCalories.Text.Trim(), out int calories) && decimal.TryParse(textBoxToppingPrice.Text.Trim(), out decimal price))
                {
                    //Create a new topping object, with data populated into properties from the textboxes
                    Topping topping = new Topping()
                    {
                        ToppingName = textBoxTeaToppingName.Text.Trim(),
                        ToppingDescription = textBoxToppingDescription.Text.Trim(),
                        ToppingCalories = calories,
                        ToppingPrice = price
                    };

                    try
                    {
                        //try adding and saving changes to the database
                        context.Toppings.Add(topping);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //if errors occur then show message and exit
                        MessageBox.Show("Cannot add Topping to database" + ex.InnerException.InnerException.Message);
                        return;
                    }


                    // set the dialog result for the form to OK
                    this.DialogResult = DialogResult.OK;

                    //Close the form and dispose it
                    context.Dispose();
                    Close();
                }
                else
                {
                    MessageBox.Show("Calorie or price format not correct. Please enter valid data!");
                }
            }
        }

        /// <summary>
        /// This method is called when the form is first loaded, it initializes the context 
        /// and resets all the form controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminAddOrUpdateTeaToppingsSubForm_Load(object sender, EventArgs e)
        {
            context = new BrewCrewEntities(); // for saving the DB context
            context.Database.Log = s => Debug.Write(s);
            context.SaveChanges(); // Save any changes to the context

            //load the Toppings table from the context
            context.Toppings.Load();


            //query to select toppings from the toppings dbset in the context
            var toppingName = from topping in context.Toppings
                              select topping;

            //Set the datasource of the listbox to the result of the above query 
            listBoxTeaTopping.DataSource = toppingName.ToList();

            // no topping is selected to start
            listBoxTeaTopping.SelectedIndex = -1;

            // no key is found for update
            ToppingID = -1;

            // set all textboxes to blank
            textBoxTeaToppingName.ResetText();
            textBoxToppingDescription.ResetText();
            textBoxToppingCalories.ResetText();
            textBoxToppingPrice.ResetText();
        }
    }
}
