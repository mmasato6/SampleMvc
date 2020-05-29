using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleListDetail01.Models
{
    /// <summary>
    /// 出版社
    /// </summary>
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
