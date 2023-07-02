using Microsoft.AspNetCore.Mvc;
using System;

namespace Hillel_HW_12
{
    [ApiController]
    [Route("[controller]")]
    public class MyFamiliarSailController : Controller
    {
       private readonly ILoaderService loaderService;
       private readonly IMyFamiliarRegister myFamiliarRegister;
       
        public MyFamiliarSailController ( ILoaderService loaderService, IMyFamiliarRegister register )
        {
            this.loaderService = loaderService;
            this.myFamiliarRegister = register;
        }

    }
    [ApiController]
    [Route("[controller]")]
    public class NotebookController : ControllerBase
    {
        private readonly IMyFamiliarRegister familiarRegister; 
        public NotebookController( IMyFamiliarRegister familiarRegister)
        {
            this.familiarRegister = familiarRegister;
        }

        //public static List<MyFamiliar> MyFamiliarList { get; set; } = new List<MyFamiliar> { };

        [HttpPost]
        public ActionResult AddMyFamiliar([FromBody] MyFamiliar myFamiliar)
        {
            //var myFamiliar = new MyFamiliar
            //{
            //    ID = familiarRegister.Count,
            //    Avatarka = request.Avatarka,
            //    Name = request.Name,
            //    Surname = request.Surname,
            //    Age = request.Age,
            //    Number = request.Number,
            //    Sity = request.Sity,
            //    Description = request.Description,
            //};
            familiarRegister.AddMyFamiliar(myFamiliar);
            return Ok(myFamiliar);
        }

        [HttpPut("{name}")]
        public ActionResult Put([FromRoute] string name, [FromRoute] string surname, [FromBody] UpdateMyFamiliarRequest updatedMyFamiliar)
        {
            var person = MyFamiliarList.Find(x => x.Name == name && x.Surname == surname);
            if (person == null)
            {
                return NotFound(person);
            }
            else
            {
                person.Avatarka = updatedMyFamiliar.Avatarka;
                person.Age = updatedMyFamiliar.Age;
                person.Number = updatedMyFamiliar.Number;
                person.Sity = updatedMyFamiliar.Sity;
                person.Description = updatedMyFamiliar.Description;
                return Ok(person);
            }

        }

        [HttpGet]
        public ActionResult GetMyFamiliar()
        {
            return Ok(MyFamiliarList);
        }

        [HttpGet("{name}")]
        public IActionResult GetMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            var person = MyFamiliarList.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (person == null)
            {
                return NotFound(person);
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpDelete]
        public ActionResult DeletMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            var myFamiliarList = MyFamiliarList.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (myFamiliarList == null)
            { 
                return BadRequest(new {ErrorMassage = "wrong ID "}); 
            }
            else
            {
                MyFamiliarList.Remove(myFamiliarList);
                return Ok(myFamiliarList);
            }

        }

    }
}