using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Models
{
    public class tAnswerStudent
    {
        [Key]
        public long IdAnswerStudent{get;set;}
        public string AnswerStudent{get;set;}
        public ICollection<tQuestions>? Questions{get;set;}
    }
}