namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("trips")]
    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            historicals = new HashSet<Historical>();
            payments = new HashSet<Payment>();
            problems = new HashSet<Problem>();
        }

        [Key]
        public int id_trip { get; set; }

        public int id_user { get; set; }

        public int id_vehicle { get; set; }

        public DateTime datai { get; set; }

        public DateTime dataf { get; set; }

        public int satisfaction { get; set; }

        [StringLength(255)]
        public string feedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historical> historicals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Problem> problems { get; set; }

        public virtual User user { get; set; }

        public virtual Vehicle vehicle { get; set; }
    }
}
