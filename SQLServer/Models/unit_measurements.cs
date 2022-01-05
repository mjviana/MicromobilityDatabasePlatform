namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class unit_measurements
    {
        [Key]
        public int id_unit_measurement { get; set; }

        [Required]
        [StringLength(30)]
        public string unit_measurement { get; set; }
    }
}
