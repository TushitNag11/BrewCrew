namespace BrewCrewDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Corresponds to the Topping table
    /// </summary>
    [Table("Topping")]
    public partial class Topping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topping()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ToppingID { get; set; } //Auto Generated ID

        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }

        [Required]
        [StringLength(100)]
        public string ToppingDescription { get; set; }

        public int ToppingCalories { get; set; }

        public decimal ToppingPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Refers to the topping in the order detail for each order
    }
}
