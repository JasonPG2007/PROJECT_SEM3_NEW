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
    public class Round
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Round ID")]
        public int RoundID { get; set; }
        [Display(Name = "Test ID")]
        public int TestID { get; set; }
        [Display(Name = "Round Number")]
        public int RoundNumber { get; set; }
        [JsonIgnore]
        public virtual Test? Tests { get; set; }
    }
}
