using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        public List<ToDo> Data {get; set;}
        public TodosController()
        {
            Data  = JsonConvert.DeserializeObject<List<ToDo>>(System.IO.File.ReadAllText(@"./Data/todo.json"));
        }

        [HttpGet]
        public ActionResult Get([FromQuery]string ids)
        {
            var result = new List<ToDo>();

            var idList = ids?.Split(',');
            if (idList == null)
                return Ok(Data);

            foreach(var id in idList)
            {
                var item = Data.FirstOrDefault(x => x.Id.ToString() == id);
                result.Add(item);
                
            }           
            
            return Ok(result); 
        }

    }
}