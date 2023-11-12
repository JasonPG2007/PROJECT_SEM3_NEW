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
    public class Result
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultId { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public virtual Question? Question { get; set; }
    }
}
