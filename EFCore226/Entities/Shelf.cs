using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore226.Entities
{
    [Table("Shelfs")]
    public class Shelf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ShelfBook> ShelfBooks { get; set; }

    }
}
