using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBussiness
{
    public class Candidate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Candidate ID")]
        public int CandidateID { get; set; }
        [Display(Name = "Candidate name")]
        public string CandidateName { get; set; }
        [Display(Name = "Phone number")]
        [RegularExpression("^0[1-9]\\d\\d{3}\\d{4}$")]
        public string Phone { get; set; }
        [RegularExpression("\\w+@+\\w+\\.+\\w+\\w")]
        public string Email { get; set; }
        [Display(Name = "Home town")]
        public string Hometown { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public virtual ExamRegister? ExamRegister { get; set; }
    }
}
