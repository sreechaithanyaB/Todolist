namespace todolist.Models{

    public class todoTaskSerializer{
        public static todotask createToDoTask(todotaskrequestRoot item){
            todotask t_d_d = new todotask();
            t_d_d.title = item.task.title;
            t_d_d.description = item.task.description;
            return t_d_d;
        }
       
    }
}