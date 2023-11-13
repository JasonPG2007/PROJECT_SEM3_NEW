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
    public class Test
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Test ID")]
        public int TestID { get; set; }
        [Display(Name = "Question ID")]
        public int QuestionID { get; set; }
        [Display(Name = "Account ID")]
        public int AccountID { get; set; }
        public DateTime DateCreateTest { get; set; }
        public DateTime TestDay { get; set; }
        [JsonIgnore]
        public virtual ResultOfCandidate? ResultOfCandidate { get; set; }
        [JsonIgnore]
        public virtual ICollection<Round>? Round { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<Question>? Question { get; set; }
    }
}
