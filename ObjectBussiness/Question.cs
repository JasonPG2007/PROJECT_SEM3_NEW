﻿using System;
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
        [Display(Name = "Question ID")]
        public int QuestionID { get; set; }
        [Display(Name = "Test ID")]
        public int TestID { get; set; }
        [Display(Name = "Question name")]
        public string QuestionName { get; set; }
        public string CorrectAnswer { get; set; }
        public double Point { get; set; }
        public string? Note { get; set; }
        [JsonIgnore]
        public virtual Test? Test { get; set; }
    }
}
