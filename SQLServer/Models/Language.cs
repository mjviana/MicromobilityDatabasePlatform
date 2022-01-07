namespace SQLServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Languages")]
    public partial class Language
    {
        [Key]
        public int id_language { get; set; }

        [Column("language")]
        [Required]
        [StringLength(30)]
        public string language1 { get; set; }
    }
}
