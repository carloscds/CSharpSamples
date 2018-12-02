using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFAsNoTracking
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}