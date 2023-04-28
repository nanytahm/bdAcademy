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
    public class QuestionsController: ControllerBase
    {
        private Context _context;
        public QuestionsController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tQuestions>GetQuestions(){
           return _context.Questions.ToList();
        }
        [HttpPost]
    public tQuestions InsertQuestions(tQuestions questions){
        _context.Questions.Add(questions);
        _context.SaveChanges();
        return questions;
    }

    //Update 
    [HttpPut]
    public tQuestions? UpdateQuestions(tQuestions questions){
        var questionsDbo = _context.Questions.Find(questions.IdQuestion);

        if(questionsDbo == null) return null;

        questionsDbo.Question = questions.Question;
        _context.SaveChanges();
        return questionsDbo;
    }

    //Delete
    [HttpDelete("{id}")]
    public bool DeleteQuestions(long id){
        var questionsDbo = _context.Questions.Find(id);
        if(questionsDbo==null) return false;

        _context.Questions.Remove(questionsDbo);
        _context.SaveChanges();
        return true;
    }
    }
}