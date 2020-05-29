using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleListDetail01.Models
{
    /// <summary>
    /// 書籍
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int Price { get; set; }
        public DateTime? PublishDate { get; set; }
        public string ISBN { get; set; }
    }
}
