using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System;

namespace Hillel_HW_12
{
    [ApiController]
    [Route("[controller]")]
    public class NotebookController : ControllerBase
    {
        private readonly IMyFamiliarRegister myFamiliarRegister;

        public NotebookController(IMyFamiliarRegister familiarRegister)
        {
            this.myFamiliarRegister = familiarRegister;
        }

        [HttpPost]
        [LogFilter]
        public ActionResult AddMyFamiliar([FromBody] MyFamiliar myFamiliar)
        {
            bool answer = myFamiliarRegister.AddMyFamiliar(myFamiliar);
            return Ok(answer);
        }


        [HttpPut("{name}/{surname}")]
        public ActionResult PutMyFamiliar([FromRoute] string name, [FromRoute] string surname, [FromBody] UpdateMyFamiliarRequest myFamiliar)
        {
            var person = myFamiliarRegister.PutMyFamiliar(name, surname, myFamiliar);
            if (person == null)
            {
                return NotFound(person);
            }
            else
            {
                return Ok(person);
            }

        }

        [HttpGet]
        public ActionResult GetMyFamiliar()
        {
            return Ok(myFamiliarRegister.GetMyFamiliar());
        }

        [HttpGet("{name}/{surname}")]
        public IActionResult GetMyFamiliarName([FromRoute] string name, [FromRoute] string surname)
        {
            var person = myFamiliarRegister.GetMyFamiliarName(name, surname);
            if (person == null)
            {
                return NotFound(person);
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpDelete("{name}/{surname}")]
        public ActionResult DeletMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            var answer = myFamiliarRegister.DeletMyFamiliar(name, surname);

            if (answer == false)
            {
                return BadRequest(new { ErrorMassage = "wrong ID " });
            }
            else
            {
                return Ok(answer);
            }

        }
    }

}