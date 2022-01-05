namespace SQLServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("historical")]
    public partial class historical
    {
        [Key]
        public int id_historical { get; set; }

        public int id_user { get; set; }

        public int id_trip { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        public virtual trip trip { get; set; }

        public virtual user user { get; set; }
    }
}
