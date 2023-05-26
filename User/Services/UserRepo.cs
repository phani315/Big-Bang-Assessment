using System.Diagnostics;
using User.Interfaces;
using User.Models;

namespace User.Services
{
    public class UserRepo : IBaseRepo<string, UserDetails>
    {
        private readonly Context _context;

        public UserRepo(Context context)
        {
            _context = context;
        }
        public UserDetails Add(UserDetails item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public UserDetails Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == key);
            return user;
        }

    }
}
