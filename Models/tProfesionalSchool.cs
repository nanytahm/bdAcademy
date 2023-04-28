using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Models
{
    public class tProfesionalSchool
    {
        [Key]
        public long IdProfesionalSchool{get;set;}
        public string Name{get;set;}=string.Empty;
        public ICollection<tCareer>? Careers{get;set;}
        
    }
}