using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiRegisterMedical.Domain
{
    [Table("customer", Schema = "public")]
    public class Customer : Base
    {
        [Key]
        [Column("id_customer")]
        public int id { get; set; }

        [Column("tx_name")]
        public string name { get; set; }


        [Column("tx_email")]
        public string email { get; set; }
    }
}
