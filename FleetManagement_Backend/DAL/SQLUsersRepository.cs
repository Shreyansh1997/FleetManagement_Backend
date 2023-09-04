using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace FleetManagement_Backend.DAL
{
    public class SQLUsersRepository : IUsersInterface
    {

         private readonly AppDbContext _context;

        public SQLUsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Users>?> GetUsersByEmailId(string emailid)
        {
            var user = await _context.Users
                       .Where(u => u.EmailId == emailid)
                        .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            return user;
         
        }

        public async Task<ActionResult<Users>?> GetUsersByEmailIdAndPassword(string emailid, string password)
        {
            var user = await _context.Users
                  .Where(u => u.EmailId == emailid && u.Password == password)
                  .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<ActionResult<Users>? >PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (user);
        }
    }

}

