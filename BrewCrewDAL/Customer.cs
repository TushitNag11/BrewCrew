namespace BrewCrewDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    /// <summary>
    /// Corresponds to the Customer table in the database
    /// </summary>
    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerID { get; set; } //Auto generated ID

        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } //refers to the list of orders for each customer

    }
}
