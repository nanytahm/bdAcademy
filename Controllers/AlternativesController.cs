using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlternativesController: ControllerBase
    {
        private Context _context;
        public AlternativesController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tAlternatives>GetAlternatives(){
           return _context.Alternatives.ToList();
        }
        [HttpPost]
    public tAlternatives InsertAlternatives(tAlternatives alternatives){
        _context.Alternatives.Add(alternatives);
        _context.SaveChanges();
        return alternatives;
    }

    //Update 
    [HttpPut]
    public tAlternatives? UpdateAlternatives(tAlternatives alternatives){
        var alternativesDbo = _context.Alternatives.Find(alternatives.IdAlternative);

        if(alternativesDbo == null) return null;

        alternativesDbo.Alternative = alternatives.Alternative;
        _context.SaveChanges();
        return alternativesDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteAlternatives(long id){
        var alternativesDbo = _context.Alternatives.Find(id);
        if(alternativesDbo==null) return false;

        _context.Alternatives.Remove(alternativesDbo);
        _context.SaveChanges();
        return true;
    }
    }
}