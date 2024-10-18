using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Part_2_APi.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Name")]
        public string Title { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        [DisplayName("Range")]
        public int Range { get; set; }
      

    }
}
