namespace BrewCrewDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Corresponds to the OrderDetail table 
    /// </summary>
    public partial class OrderDetail
    {
     

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; } // Refers to the OrderID in Order table

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrinkID { get; set; } //Refers to the DrinkID in the Drink table

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ToppingID { get; set; } //Refers to the ToppingID in the Topping table

        public int DrinkQuantity { get; set; }

        public virtual Drink Drink { get; set; } 

        public virtual Order Order { get; set; }

        public virtual Topping Topping { get; set; }
    }
}
