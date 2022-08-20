
using System.Text.Json.Serialization;

namespace todolist.Models{

    public class todotask{
        public int id{get; set;}
        public string title {get; set;}
       public string description { get; set; }
    }
}
