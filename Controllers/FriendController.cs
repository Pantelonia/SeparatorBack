using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SeparatorBack.Models;
using System.Threading.Tasks;
using System;

namespace SeparatorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        GroupContext db;
        public FriendController(GroupContext context)
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
        public async Task<ActionResult<IEnumerable<Friend>>> Get()
        {
            return await db.Friends.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend>> Get(int id)
        {
            Friend friend = await db.Friends.FindAsync(id);
            //Group group = await db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (friend == null)
                return NotFound();
            return new ObjectResult(friend);
        }


        //PUT api/users/
        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> Put(Dish dish)
        {
            if (dish == null)
            {
                return BadRequest();
            }
            Friend friend = await db.Friends.FindAsync(dish.FriendId);
            if (!db.Groups.Any(x => x.Id == friend.Id))
            {
                return NotFound();
            }
            friend.Add_dish(dish);
            db.Update(friend);
            await db.SaveChangesAsync();
            return Ok(friend);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Friend>> Delete(int id)
        {
            Friend friend = db.Friends.FirstOrDefault(x => x.Id == id);
            if (friend == null)
            {
                return NotFound();
            }
            db.Friends.Remove(friend);
            await db.SaveChangesAsync();
            return Ok(friend);
        }

        // DELETE api/users/5
        [HttpDelete("deleteDish/{id}")]
        public async Task<ActionResult<Friend>> DeleteDish(int  id)
        {
            Dish dish = db.Dishes.FirstOrDefault(x => x.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            db.Dishes.Remove(dish);
            await db.SaveChangesAsync();
            return Ok(dish);
        }
    }
}
