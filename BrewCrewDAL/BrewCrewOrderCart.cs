using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BrewCrewDAL
{
    /// <summary>
    /// This class is used to populate a temporary cart list, to hold customer selection when placing an order
    /// in the BrewCrewMenuForm
    /// This class's objects in the list are displayed in the dataGridViewCustomerCart.
    /// This class is also used to display the contents of the above-mentioned list in the BrewCrewCustomerOrderReceiptForm
    /// in the dataGridViewOrderDetails, when an order is placed.
    /// </summary>
    public class BrewCrewOrderCart
    {
        //When Place order button is clicked in BrewCrewMenuForm

        [DisplayName("Drink ID")] 
        public int DrinkID { get; set; } //this property value is saved in the OrderDetail table

        [DisplayName("Drink Name")]
        public string DrinkName { get; set; }

        [DisplayName("Topping ID")]
        public int ToppingID { get; set; } //this property value is saved in the OrderDetail table

        [DisplayName("Topping Name")]
        public string ToppingName { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; } //this property value is saved in the OrderDetail table

        [DisplayName("Total Calories")]
        public int TotalCalories { get; set; }

        [DisplayName("Selection Price")]
        public decimal SelectionPrice { get; set; }

        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; } //this property value is saved in the Order table
    }
}
