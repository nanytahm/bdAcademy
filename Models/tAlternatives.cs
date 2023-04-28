using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.Models
{
    public class tAlternatives
    {
        [Key]
        public long IdAlternative{get;set;}
        public string Alternative{get;set;}
        public string Description{get;set;}
        public bool IsTheAnswer{get;set;}
        public long IdQuestion {get;set;}

        [ForeignKey(nameof(IdQuestion))]
        public tQuestions? Questions {get;set;}
    }
}