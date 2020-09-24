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
    public class GroupController : ControllerBase
    {
        GroupContext db;
        public GroupController(GroupContext context)
        {
            db = context;
            //if (!db.Groups.Any())
            //{
            //    Group group = new Group("Pokorili");
            //    Friend friend = new Friend("Paul");               
            //    Dish dish = new Dish("Borsch", 70);
            //    friend.Add_dish(dish);
            //    group.AddNewFriend("Paul");
            //    db.Groups.Add(group);
            //    db.SaveChanges();

            //}
        }
        [HttpGet]
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await db.Groups.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            //Group group = await db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            return new ObjectResult(group);
        }

        // GET api/users/5 by name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Group>> GetByName(string name )
        {
            //Group group = await db.Groups.FindAsync(id);
            Group group = await db.Groups.FirstOrDefaultAsync(x => x.Name == name);
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

        // POST api/users
        [HttpPut("addDish/")]
        public async Task<ActionResult<Group>> PostDish(Dish dish)
        {
            if (dish == null)
            {
                return BadRequest();
            }
            Friend friend = await db.Friends.FindAsync(dish.FriendId);
            Group group = await db.Groups.FindAsync(friend.GroupId);
            if (dish.Type)
            {
                group.Create_communal_dish(dish);
            }
            else
            {
                group.Create_personal_dish(dish, friend.Name);
            }
            db.Groups.Update(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

        // PUT api/users/
        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> Put(Friend friend)
        {
            if (friend == null)
            {
                return BadRequest();
            }
            Group group = await db.Groups.FindAsync(friend.GroupId);
            if (!db.Groups.Any(x => x.Id == group.Id))
            {
                return NotFound();
            }
            group.AddNewFriend(friend);
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
