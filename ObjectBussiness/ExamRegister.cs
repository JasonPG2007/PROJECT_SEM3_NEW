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
    public class ExamRegister
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Exam Register ID")]
        public int ExamRegisterID { get; set; }
        [ForeignKey("Candidate")]
        [Display(Name = "Candidate ID")]
        public int CandidateID { get; set; }
        [JsonIgnore]
        public virtual Candidate? Candidate { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
    }
}
