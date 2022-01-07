namespace SQLServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("problems")]
    public partial class Problem
    {
        [Key]
        public int id_problem { get; set; }

        public int id_user { get; set; }

        public int id_trip { get; set; }

        [Column("problem", TypeName = "text")]
        [Required]
        public string description { get; set; }

        public DateTime dataproblem { get; set; }

        public virtual Trip trip { get; set; }
    }
}
