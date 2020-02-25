using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore311_Issue19984Test.Entities
{
    [Table("ShelfBooks")]
    public class ShelfBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfBookId { get; set; }
        public int ShelfId { get; set; }
        public int BookId { get; set; }
        
        [ForeignKey(nameof(ShelfId))]
        public virtual Shelf Shelf { get; set; }
        
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
    }
}
