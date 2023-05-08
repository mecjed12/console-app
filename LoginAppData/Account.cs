using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column("safety_word")]
        public string SafteyWord { get; set; }

        [Column("Admin_status")]
        public bool AccountType { get; set; }
    }
}
