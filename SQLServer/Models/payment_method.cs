namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class payment_method
    {
        [Key]
        public int id_payment_method { get; set; }

        [Required]
        [StringLength(50)]
        public string payment_type { get; set; }
    }
}
