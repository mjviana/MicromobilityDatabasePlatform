namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            historicals = new HashSet<historical>();
            trips = new HashSet<trip>();
        }

        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(30)]
        public string password { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string numero_conta { get; set; }

        [StringLength(100)]
        public string nome_utilizador { get; set; }

        public int? id_unit_measurement { get; set; }

        public int? id_language { get; set; }

        public int? id_payment_method { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historical> historicals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trip> trips { get; set; }

        public override string ToString()
        {
            string details = $"id: {id_user}, name: {name}, password: {password}," +
                $"email: {email}, numero conta: {numero_conta}, nome user: {nome_utilizador}, id unidade medida: {id_unit_measurement}," +
                $"language id: {id_language}, payment method id: {id_payment_method}";
            return details;
        }
    }
}
