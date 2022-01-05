namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trip()
        {
            historicals = new HashSet<historical>();
            payments = new HashSet<payment>();
            problems = new HashSet<problem>();
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
        public virtual ICollection<historical> historicals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<problem> problems { get; set; }

        public virtual user user { get; set; }

        public virtual vehicle vehicle { get; set; }
    }
}
