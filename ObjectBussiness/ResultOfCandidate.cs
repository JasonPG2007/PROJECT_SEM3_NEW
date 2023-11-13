using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ObjectBussiness
{
    public class ResultOfCandidate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ResultOfCandidate ID")]
        public int ResultOfCandidateID { get; set; }
        [ForeignKey("Test")]
        [Display(Name = "Test ID")]
        public int TestID { get; set; }
        [JsonIgnore]
        public virtual Test? Test { get; set; }
        [JsonIgnore]
        public virtual Elect? Elect { get; set; }
    }
}
