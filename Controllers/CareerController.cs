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
    public class CareerController:ControllerBase
    {
        private Context _context;
        public CareerController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tCareer>GetCareers(){
           return _context.Careers.ToList();
        }
        [HttpPost]
    public tCareer InsertCareer(tCareer career){
        _context.Careers.Add(career);
        _context.SaveChanges();
        return career;
    }

    //Update beer
    [HttpPut]
    public tCareer? UpdateCareer(tCareer career){
        var careerDbo = _context.Careers.Find(career.IdCareer);

        if(careerDbo == null) return null;

        careerDbo.NameCareer = career.NameCareer;
        _context.SaveChanges();
        return careerDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteCareer(long id){
        var careerDbo = _context.Careers.Find(id);
        if(careerDbo==null) return false;

        _context.Careers.Remove(careerDbo);
        _context.SaveChanges();
        return true;
    }
    }
}