namespace Test_Invoice_Schad.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string CustName { get; set; }

        [Required]
        [StringLength(120)]
        public string Adress { get; set; }

        public bool Status { get; set; }

        [ForeignKey("CustomerTypes")]
        public int CustomerTypeId { get; set; }

        public virtual CustomerTypes CustomerTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
