using System;
using System.Collections.Generic;

namespace SampleDBModelMVC.Models
{
    public partial class Prefecture
    {
        public Prefecture()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
