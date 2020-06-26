using System;
using System.Collections.Generic;

namespace SampleWebApi.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PrefectureId { get; set; }

        public Prefecture Prefecture { get; set; }
    }
}
