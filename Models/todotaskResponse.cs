using System.Collections.Generic;
using Newtonsoft.Json;
using System;
namespace todolist.Models{

    public class todotaskResponseRoot{
        public todotaskResponse Task{get;set;}  
    }
public class todotaskResponseRoots{
        public List<todotaskResponse> Tasks{get;set;}
    }
    public class todotaskResponse{
public int id{get;set;}
    public string code{get; set;}
    
    public string title {get; set;}
    public string description { get; set; }
    public todotaskResponse(todotask t_d){
        this.code="Task " +t_d.id;
        this.id=t_d.id;
        this.title=t_d.title;
        this.description=t_d.description;
       }
       
}
}