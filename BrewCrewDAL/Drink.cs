namespace BrewCrewDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Corresponds to the Drink table in the database
    /// </summary>
    [Table("Drink")]
    public partial class Drink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drink()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int DrinkID { get; set; } // Auto generated ID

        [Required]
        [StringLength(50)]
        public string DrinkName { get; set; }

        [Required]
        [StringLength(150)]
        public string DrinkDescription { get; set; }

        public int DrinkCalories { get; set; }

        public decimal DrinkPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } //Refers to the drinks in the order details for each order
    }
}
