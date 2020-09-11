using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SeparatorBack.Models;
using System.Threading.Tasks;


namespace SeparatorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        GroupContext db;
        public GroupController(GroupContext context)
        {
            db = context;
            //if (!db.Groups.Any())
            //{                
            //    Group group = new Group("Pokorili");
            //    group.AddNewFriend("Paul");
            //    Dish dish = new Dish("Borsch", 70);
            //    group.Create_personal_dish(dish, "Paul");
            //    db.Groups.Add(group);
            //    db.SaveChanges();

            //}
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await db.Groups.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            Group group = await db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            return new ObjectResult(group);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            db.Groups.Add(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Group>> Put(Group group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            if (!db.Groups.Any(x => x.Id == group.Id))
            {
                return NotFound();
            }

            db.Update(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> Delete(int id)
        {
            Group group = db.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            db.Groups.Remove(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }
    }
}
