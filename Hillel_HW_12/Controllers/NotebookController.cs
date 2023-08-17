using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;

namespace Hillel_HW_12
{
    [ApiController]
    [Route("[controller]")]
    public class NotebookController : ControllerBase
    {
        private readonly ILogger<NotebookController> logger;
        private readonly IMyFamiliarRegister myFamiliarRegister;

        public NotebookController(IMyFamiliarRegister familiarRegister, ILogger<NotebookController> logger)
        {
            this.myFamiliarRegister = familiarRegister;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult AddMyFamiliar([FromBody] MyFamiliar myFamiliar)
        {
            bool answer = myFamiliarRegister.AddMyFamiliar(myFamiliar);
            logger.LogInformation($"Inform");
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
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult DeletMyFamiliar([FromRoute] string name, [FromRoute] string surname)
        {
            var answer = myFamiliarRegister.DeletMyFamiliar(name, surname);

            if (answer == false)
            {
                logger.LogWarning("wrong Id");
                return BadRequest(new { ErrorMassage = "wrong ID " });
            }
            else
            {
                return Ok(answer);
            }
  
        }
    }

}