namespace SQLServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vehicles")]
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            trips = new HashSet<Trip>();
        }

        [Key]
        public int id_vehicle { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        public bool? active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> trips { get; set; }
    }
}
