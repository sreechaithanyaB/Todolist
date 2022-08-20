using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todolist.Models;
using Newtonsoft.Json;

namespace todolist.Controllers{
[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase{
private readonly TodoContext _context;
        
public TodoController(TodoContext context){
 _context=context;
}
    //get all tasks

    [HttpGet]

    public string GetAll(){
        List<todotask> list= _context.todotasks.ToList();
        todotaskResponseRoots t_d_t_r_r = new todotaskResponseRoots();
        t_d_t_r_r.Tasks=new List<todotaskResponse>();
        foreach (todotask t_d_t in list){
        todotaskResponse t_d_t_r = new todotaskResponse(t_d_t);
   
                  
        t_d_t_r_r.Tasks.Add(t_d_t_r);
        }
   return JsonConvert.SerializeObject(t_d_t_r_r);
}

    //Get By id- a particular task

    [HttpGet("{id}",Name ="GetTodo")]
    public string GetById(int id){
        todotask t_d_t = _context.todotasks.Find(id);
        if(t_d_t==null){
        string a="Not found";
        return a;
        }
        todotaskResponse t_d_t_r = new todotaskResponse(t_d_t);
        todotaskResponseRoot t_d_t_r_r = new todotaskResponseRoot();
        t_d_t_r_r.Task=t_d_t_r;
    return JsonConvert.SerializeObject(t_d_t_r_r);    }

    //create or add an task to the db
    [HttpPost]

    public string Create([FromBody] todotaskrequestRoot t_r_r_t)
    { 
    if (t_r_r_t == null)
    {
        string a="Not found";
        return a;
    }
        todotask t_d_t = todoTaskSerializer.createToDoTask(t_r_r_t);
        _context.todotasks.Add(t_d_t);
        _context.SaveChanges();
    
        todotaskResponse t_d_t_r = new todotaskResponse(t_d_t);
        todotaskResponseRoot t_d_t_r_r = new todotaskResponseRoot();
        t_d_t_r_r.Task=t_d_t_r;
        string b= JsonConvert.SerializeObject(t_d_t_r_r);
    return b;
    }


    //update: edit an partticular entry of the existing db

    [HttpPut("{id}")]
    public string Put(int id, [FromBody] todotaskrequestRoot t_r)
    {
    if (t_r == null)
    {
        string a="Bad request";
        return a;
    }
    todotask t_d_t = todoTaskSerializer.createToDoTask(t_r);
    
    todotask tt = _context.todotasks.Find(id);
    if (tt == null)
    {
        string b="Not found";
        return b;
    }
    tt.title = t_d_t.title;
    tt.description= t_d_t.description;
    _context.todotasks.Update(tt);
    _context.SaveChanges();
    todotaskResponse t_d_t_r = new todotaskResponse(tt);
        todotaskResponseRoot t_d_t_r_r = new todotaskResponseRoot();
        t_d_t_r_r.Task=t_d_t_r;
    return JsonConvert.SerializeObject(t_d_t_r_r);
    }

//Deletion of task by particular ID

[HttpDelete("{id}")]
    public string  Delete(int id)
    {
        todotask t_d_t = _context.todotasks.Find(id);
        if (t_d_t == null)
        {
            return "NotFound()";
        }

        _context.todotasks.Remove(t_d_t);
        _context.SaveChanges();
        todotaskResponse t_d_t_r = new todotaskResponse(t_d_t);
        todotaskResponseRoot t_d_t_r_r = new todotaskResponseRoot();
        t_d_t_r_r.Task=t_d_t_r;
    return JsonConvert.SerializeObject(t_d_t_r_r);
}



    }
}   
    
