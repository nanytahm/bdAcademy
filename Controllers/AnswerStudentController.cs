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
    public class AnswerStudentController: ControllerBase
    {
        private Context _context;
        public AnswerStudentController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tAnswerStudent>GetAnswerStudents(){
           return _context.AnswerStudents.ToList();
        }
        [HttpPost]
    public tAnswerStudent InsertAnswerStudent(tAnswerStudent answerStudent){
        _context.AnswerStudents.Add(answerStudent);
        _context.SaveChanges();
        return answerStudent;
    }

    //Update beer
    [HttpPut]
    public tAnswerStudent? UpdateAnswerStudent(tAnswerStudent answerStudent){
        var answerStudentDbo = _context.AnswerStudents.Find(answerStudent.IdAnswerStudent);

        if(answerStudentDbo == null) return null;

        answerStudentDbo.AnswerStudent =answerStudent.AnswerStudent;
        _context.SaveChanges();
        return answerStudentDbo;
    }

    //Delete beer
    [HttpDelete("{id}")]
    public bool DeleteAnswerStudent(long id){
        var answerStudentDbo = _context.AnswerStudents.Find(id);
        if(answerStudentDbo==null) return false;

        _context.AnswerStudents.Remove(answerStudentDbo);
        _context.SaveChanges();
        return true;
    }
    }
}