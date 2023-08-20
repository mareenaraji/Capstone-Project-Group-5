using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Admin_BookAPI.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double price { get; set; }   
        public DateTime PublishedDate { get; set; }
        public int IsbnNo { get; set; }        
    }
}
