using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet] //We use Get to return something 
        //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/activities/dfdfdfdf
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id= id});
        }

        [HttpPost]//When we create a ressource in an API we use Http Post
        public async Task<IActionResult> CreateActivity(Activity activity)//It give us acces to Http request but we dont need to specify the type 
        {
            await Mediator.Send(new Create.Command {Activity = activity});
            return Ok();
        }

        [HttpPut("{id}")]//Edit 
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;

            await Mediator.Send(new Edit.Command {Activity = activity});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command{Id=id});
            return Ok();
        }
    }
}