namespace SQLServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("historical")]
    public partial class Historical
    {
        [Key]
        public int id_historical { get; set; }

        public int id_user { get; set; }

        public int id_trip { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        public virtual Trip trip { get; set; }

        public virtual User user { get; set; }
    }
}
