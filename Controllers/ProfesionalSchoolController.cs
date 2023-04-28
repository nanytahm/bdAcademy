using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesionalSchoolController:ControllerBase
    {
        private Context _context;
        public ProfesionalSchoolController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tProfesionalSchool>GetProfesionalSchools(){
           return _context.ProfesionalSchools.ToList();
        }
        [HttpPost]
    public tProfesionalSchool InsertProfesionalSchool(tProfesionalSchool profesionalSchool){
        _context.ProfesionalSchools.Add(profesionalSchool);
        _context.SaveChanges();
        return profesionalSchool;
    }

    //Update 
    [HttpPut]
    public tProfesionalSchool? UpdateProfesionalSchool(tProfesionalSchool profesionalSchool){
        var profesionalSchoolDbo = _context.ProfesionalSchools.Find(profesionalSchool.IdProfesionalSchool);

        if(profesionalSchoolDbo == null) return null;

        profesionalSchoolDbo.Name = profesionalSchool.Name;
        _context.SaveChanges();
        return profesionalSchoolDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteProfesionalSchool(long id){
        var profesionalSchoolDbo = _context.ProfesionalSchools.Find(id);
        if(profesionalSchoolDbo==null) return false;

        _context.ProfesionalSchools.Remove(profesionalSchoolDbo);
        _context.SaveChanges();
        return true;
    }
    }
}