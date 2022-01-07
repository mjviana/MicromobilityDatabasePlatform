namespace SQLServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("unit_measurements")]
    public partial class UnitOfMeasure
    {
        [Key]
        public int id_unit_measurement { get; set; }

        [Required]
        [StringLength(30)]
        public string unit_measurement { get; set; }
    }
}
