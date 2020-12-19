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
    /// This class opens the BrewCrewAdminAddOrUpdateMilkTeaSubForm.
    /// Sub form to add or update data in Drink table in the database
    /// </summary>
    public partial class BrewCrewAdminAddOrUpdateMilkTeaSubForm : Form
    {
        //Property for the identity DrinkID
        public int DrinkID { get; set; }

        //Db context
        private BrewCrewEntities context;

        public BrewCrewAdminAddOrUpdateMilkTeaSubForm()
        {
            InitializeComponent();

            //Adding event listeners
            this.Load += AdminAddOrUpdateMilkTeaSubForm_Load;
            buttonAddNewMilkTea.Click += ButtonAddNewMilkTea_Click;
            buttonUpdateMilkTea.Click += ButtonUpdateMilkTea_Click;
            listBoxSelectMilkTea.SelectedIndexChanged += (s, e) => GetDrink();
            this.FormClosed += (s, e) => context.Dispose();
        }

        /// <summary>
        /// This method is called when the selection in the listboxMilkTea is changed
        /// It gets the particular selected drink from the database and populates the corresponding textboxes
        /// </summary>
        private void GetDrink()
        {
            //Checks if the selected item is of type Drink
            if (!(listBoxSelectMilkTea.SelectedItem is Drink drink))
                return;

            textBoxMilkTeaName.Text = drink.DrinkName;
            textBoxMilkTeaDescription.Text = drink.DrinkDescription;
            textBoxMilkTeaCalories.Text = drink.DrinkCalories.ToString();
            textBoxMilkTeaPrice.Text = drink.DrinkPrice.ToString();
            DrinkID = drink.DrinkID;
        }


        /// <summary>
        /// This event handler is called when update button is clicked
        /// It gets the selected drink object from the listbox and tries to save the changes made in the textboxes
        /// to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdateMilkTea_Click(object sender, EventArgs e)
        {

            //Checks if the selected item is of type Drink, else displays a message 
            if (!(listBoxSelectMilkTea.SelectedItem is Drink drink))
            {
                MessageBox.Show("Please select a drink to update.");
                return;
            }
            // Checks if any textbox is empty, else displays a message
            else if (textBoxMilkTeaName.Text.Trim().Length == 0 || textBoxMilkTeaDescription.Text.Trim().Length == 0 ||
                textBoxMilkTeaCalories.Text.Trim().Length == 0 || textBoxMilkTeaPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill all the fields! Drink information is missing.");
                return;
            }
            else
            {
                //Search for the drink that is selected in the listbox 
                Drink newDrink = context.Drinks.FirstOrDefault(d => d.DrinkID == drink.DrinkID);

                //check if the new drink already exists and is different than the selected drink, 
                //if yes, then the drink cannot be updated 
                if ( newDrink != null && newDrink != drink)
                {
                    MessageBox.Show("Drink cannot be updated, already exists!");
                }
                else
                {
                    // Parse the calorie and price textboxes
                    if(int.TryParse(textBoxMilkTeaCalories.Text.Trim(), out int calories)  && decimal.TryParse(textBoxMilkTeaPrice.Text.Trim(), out decimal price))
                    {
                        // populate the drink object with values from the textboxes
                        drink.DrinkName = textBoxMilkTeaName.Text.Trim();
                        drink.DrinkDescription = textBoxMilkTeaDescription.Text.Trim();
                        drink.DrinkCalories = calories;
                        drink.DrinkPrice = price;

                        try
                        {
                            // save changes to the database
                            context.SaveChanges();

                            //Set the DrinkId property 
                            DrinkID = drink.DrinkID;
                        }
                        catch (Exception ex)
                        {
                            //If exception occues, display a message
                            MessageBox.Show("Cannot update Drink to database" + ex.InnerException.InnerException.Message);
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
        /// It validates the data in the textboxes and add the new drink to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNewMilkTea_Click(object sender, EventArgs e)
        {
            // Check if textboxes are not empty, else display a message
            if (textBoxMilkTeaName.Text.Trim().Length == 0 || textBoxMilkTeaDescription.Text.Trim().Length == 0 ||
                textBoxMilkTeaCalories.Text.Trim().Length == 0 || textBoxMilkTeaPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Drink information is missing!");
                return;
            }
            else
            {
                // Parse the data in the calorie and price textbox
                if (int.TryParse(textBoxMilkTeaCalories.Text.Trim(), out int calories) && decimal.TryParse(textBoxMilkTeaPrice.Text.Trim(), out decimal price))
                {
                    //Create a new drink object, with data populated into properties from the textboxes
                    Drink drink = new Drink()
                    {
                        DrinkName = textBoxMilkTeaName.Text.Trim(),
                        DrinkDescription = textBoxMilkTeaDescription.Text.Trim(),
                        DrinkCalories = calories,
                        DrinkPrice = price
                    };

                    try
                    {
                        //try adding and saving changes to the database
                        context.Drinks.Add(drink);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //if errors occur then show message and exit
                        MessageBox.Show("Cannot add Drink to database" + ex.InnerException.InnerException.Message);
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
        private void AdminAddOrUpdateMilkTeaSubForm_Load(object sender, EventArgs e)
        {
            context = new BrewCrewEntities(); // for saving the DB context
            context.Database.Log = s => Debug.Write(s);
            context.SaveChanges(); // Save any changes to the context

            //load the Drinks table
            context.Drinks.Load();


            //query to select drinks from the drinks dbset in the context
            var drinkName = from drink in context.Drinks
                            select drink;

            //Set the datasource of the listbox to the result of the above query            
            listBoxSelectMilkTea.DataSource = drinkName.ToList();

            // no drink is selected in the listbox
            listBoxSelectMilkTea.SelectedIndex = -1;

            // no key is found for update
            DrinkID = -1;

            // set all textboxes to blank
            textBoxMilkTeaName.ResetText();
            textBoxMilkTeaDescription.ResetText();
            textBoxMilkTeaCalories.ResetText();
            textBoxMilkTeaPrice.ResetText();

        }
    }
}
