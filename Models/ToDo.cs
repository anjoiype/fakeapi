namespace ToDoApi.Models
{
    public class ToDo
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public string Title {get; set;}
        public bool Completd {get;set;}
    }

}
