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
        public ActionResult AddMyFamiliar([FromBody] CreateMyFamiliarRequest myFamiliar)
        {
            bool answer = myFamiliarRegister.AddMyFamiliar(myFamiliar);
            return Ok(answer);
        }


        [HttpPut("{id}"/*"{name}"*/)]
        public ActionResult PutMyFamiliar([FromRoute] int id/*[FromRoute] string name, [FromRoute] string surname*/, [FromBody] UpdateMyFamiliarRequest updatedMyFamiliar)
        {
            var person = myFamiliarRegister.PutMyFamiliar(id/*name, surname*/, updatedMyFamiliar);
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
            return Ok(myFamiliarRegister.GetMyFamiliar);
        }

        [HttpGet("{id}"/*"{name}"*/)]
        public IActionResult GetMyFamiliarName(int id/*[FromRoute] string name, [FromRoute] string surname*/)
        {
            var person = myFamiliarRegister.GetMyFamiliarName(id/*name, surname*/);
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
        public ActionResult DeletMyFamiliar([FromRoute] int id/*[FromRoute] string name, [FromRoute] string surname*/)
        {
            var answer = myFamiliarRegister.DeletMyFamiliar(/*name, surname*/id);

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