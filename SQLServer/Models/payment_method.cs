namespace SQLServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("payment_method")]
    public partial class Payment_method
    {
        [Key]
        public int id_payment_method { get; set; }

        [Required]
        [StringLength(50)]
        public string payment_type { get; set; }
    }
}
