using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Models
{
    public class tStudent
    {
        [Key]
        public long IdStudent{get;set;}
        public string Name{get;set;}
        public string LastName{get;set;}
        //course
        public long IdCourse{get;set;}
        
        [ForeignKey(nameof(IdCourse))]
        public tCourse? course {get;set;}
        
    }
}