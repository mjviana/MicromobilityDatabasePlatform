namespace SQLServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Payment
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

        public virtual Trip trip { get; set; }
    }
}
