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
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Result>? Result { get; set; }
    }
}
