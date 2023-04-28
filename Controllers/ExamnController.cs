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
    public class ExamnController: ControllerBase
    {
        private Context _context;
        public ExamnController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tExamn>GetExamns(){
           return _context.Examns.ToList();
        }
        [HttpPost]
    public tExamn InsertExamn(tExamn examn){
        _context.Examns.Add(examn);
        _context.SaveChanges();
        return examn;
    }

    //Update 
    [HttpPut]
    public tExamn? UpdateExamn(tExamn examn){
        var examnDbo = _context.Examns.Find(examn.IdExam);

        if(examnDbo == null) return null;

        examnDbo.NroPreguntas = examn.NroPreguntas;
        _context.SaveChanges();
        return examnDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteExamn(long id){
        var examnDbo = _context.Examns.Find(id);
        if(examnDbo==null) return false;

        _context.Examns.Remove(examnDbo);
        _context.SaveChanges();
        return true;
    }
    }
}