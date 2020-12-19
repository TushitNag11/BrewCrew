using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewCrewDAL
{
  
    /// <summary>
    /// For debugging purposes
    /// </summary>
    public partial class Drink
    {
        /// <summary>
        /// This method is called in the BrewCrewAdminAddOrUpdateMilkTeaSubForm to populate the Milk Tea listbox
        /// </summary>
        /// <returns></returns>
         public override string ToString()
         {
            return DrinkID + " : " + DrinkName;
         }
           
    }

    /// <summary>
    /// For debugging purposes
    /// </summary>
    public partial class Topping
    {
        /// <summary>
        /// This method is called in the BrewCrewAdminAddOrUpdateTeaToppingSubForm to populate the Tea Topping listbox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToppingID + " : " + ToppingName;
        }
    }
    
}
