using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibary;
namespace LoginAppData
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("password")]
        public long Password { get; set; }

        [Column("date")]
        public DateTime CreatedAt { get; set; }

        [Column("account_type")]
        public bool AccountType { get; set; }
    }
}
