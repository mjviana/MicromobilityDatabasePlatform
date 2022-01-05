namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class payment
    {
        [Key]
        public int id_payment { get; set; }

        public int id_user { get; set; }

        public int id_trip { get; set; }

        public DateTime datapayment { get; set; }

        public decimal amount { get; set; }

        [Required]
        [StringLength(50)]
        public string payment_type { get; set; }

        public virtual trip trip { get; set; }
    }
}
