using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleCFModelMVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20,ErrorMessage ="最大文字数は20文字までです")]
        [Display(Name ="名前")]
        public string Name { get; set; }

        [Range(18,100,ErrorMessage ="年齢は18歳から100歳までです")]
        [Display(Name="年齢")]
        [DisplayFormat(DataFormatString = "{0}歳")]
        public int? Age { get; set; }

        //Prefectureへの外部参照
        [Display(Name ="出身地")]
        public int PrefectureId { get; set; }
        public Prefecture Prefecture { get; set; }

        //入社日
        [Display(Name="入社日")]
        [DisplayFormat(DataFormatString ="{0:yyyy年MM月dd日}")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        //出退勤
        [Display(Name ="出社状態")]
        public bool IsAttend { get; set; }

        //EMail
        [Display(Name ="メールアドレス")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="ブログページ(URL)")]
        [Url]
        public string Blog { get; set; }


        //社員番号(XXX-0000)
        [RegularExpression("[A-Z]{3}-[0-9]{4}")]
        [Display(Name ="社員番号")]
        public string EmployeeNo { get; set; }
    }
}
