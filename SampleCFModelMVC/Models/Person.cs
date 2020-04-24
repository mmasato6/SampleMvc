using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCFModelMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        //Prefectureへの外部参照
        public int PrefectureId { get; set; }
        public Prefecture Prefecture { get; set; }
        public DateTime? HireDate { get; set; }//入社日
        public bool IsAttend { get; set; }//出退勤
        public string Email { get; set; }
        public string Blog { get; set; }
        public string EmployeeNo { get; set; }//社員番号
    }
}
