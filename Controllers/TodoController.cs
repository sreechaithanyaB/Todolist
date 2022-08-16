using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todolist.Models;

namespace todolist.Controllers{
[ApiController]
[Route("[controller]")]
    public class TodoController : ControllerBase{
        private readonly TodoContext _context;
        public TodoController(TodoContext context){
            _context=context;
            if(_context.todotasks.Count()==0){
                _context.todotasks.Add(new todotask{title = "Item1", description = "item1Description"});
                

            
            
                _context.todotasks.Add(new todotask{title = "Item2", description = "item1Description2"});
                _context.SaveChanges();

            }
        }
    //get all tasks

    [HttpGet]
    public ActionResult<List<todotask>> GetAll(){
        return _context.todotasks.ToList();

    }

    //Get By id- a particular task

    [HttpGet("{id}",Name ="GetTodo")]
    public ActionResult<todotask> GetById(int id){
        var item = _context.todotasks.Find(id);
        if(item==null){
            return NotFound();
        }
        return item;


    }

    //create or add an task to the db
    [HttpPost]
    public ActionResult<todotask> Create([FromBody] todotask item)
    { 
    if (item == null)
    {
        return BadRequest();
    }

    _context.todotasks.Add(item);
    _context.SaveChanges();

    return Ok();
    }


    //update: edit an partticular entry of the existing db

    [HttpPut("{id}")]
    public ActionResult<todotask> Put(int id, [FromBody] todotask item)
    {
         if (item == null)
        {
            Console.WriteLine("this is the error");
            return BadRequest();
        }

        var todotask = _context.todotasks.Find(id);
        if (todotask == null)
        {
            return NotFound();
        }

        
        todotask.title = item.title;
        todotask.description= item.description;
        

        _context.todotasks.Update(todotask);
        _context.SaveChanges();
        return Ok();
    }

//Deletion of task by particular ID

[HttpDelete("{id}")]
    public ActionResult<todotask>  Delete(int id)
    {
        var todotask = _context.todotasks.Find(id);
        if (todotask == null)
        {
            return NotFound();
        }

        _context.todotasks.Remove(todotask);
        _context.SaveChanges();
        return Ok();
    }



    }
}   
    
