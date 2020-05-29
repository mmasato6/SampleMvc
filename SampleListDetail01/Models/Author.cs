using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleListDetail01.Models
{
    /// <summary>
    /// 著者
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        [Display(Name="著者名")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int PrefectureId { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual Prefecture Prefecture { get; set; }
    }
}
