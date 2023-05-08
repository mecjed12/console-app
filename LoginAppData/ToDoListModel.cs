using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppData
{
    [Table("todolist")]
    public class ToDoListModel
    {
        [Key]
        [Column("id")]
        public int ListId { get; set; }

        [Column("name")]
        public string? ListName { get; set; }

        public virtual ICollection<ToDoItem> Items { get; set; }
    }

    [Table("todoitems")]
    public class ToDoItem
    {
        [Key]
        [Column("id")]
        public int ItemId { get; set; }

        [Column("task")]
        public string? Task { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("completed")]
        public bool Completed { get; set; }

        [ForeignKey("ListId")]
        public int ListId { get; set; }

        public virtual ToDoListModel List { get; set; }
    }
}
