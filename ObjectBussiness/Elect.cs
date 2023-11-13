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
    public class Elect
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Elect ID")]
        public int ElectID { get; set; }
        [ForeignKey("ResultOfCandidate")]
        [Display(Name = "Result Of Candidate ID")]
        public int ResultOfCandidateID { get; set; }
        [Display(Name = "Result Elect")]
        public bool ResultElect { get; set; }
        [JsonIgnore]
        public virtual ResultOfCandidate? ResultOfCandidate { get; set; }
    }
}
