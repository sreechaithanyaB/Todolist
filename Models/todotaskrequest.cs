using System.Collections.Generic;
using Newtonsoft.Json;

using System;
namespace todolist.Models{


    public class todotaskrequestRoot{
        public todotaskrequest task{get;set;}
        public void hai(){
            Console.WriteLine(task.title);
            Console.WriteLine(task.description);
            
        }    

        }
        
    public class todotaskrequest{
      
        public string title {get; set;}
       public string description { get; set; }

       public todotaskrequest(){

       }
    }
}
