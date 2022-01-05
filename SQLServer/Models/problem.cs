namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class problem
    {
        [Key]
        public int id_problem { get; set; }

        public int id_user { get; set; }

        public int id_trip { get; set; }

        [Column("problem", TypeName = "text")]
        [Required]
        public string problem1 { get; set; }

        public DateTime dataproblem { get; set; }

        public virtual trip trip { get; set; }
    }
}
