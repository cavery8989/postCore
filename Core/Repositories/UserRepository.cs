using System.Linq;
using Core.Models.Database;

namespace Core.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository (DatabaseContext databaseContext){
            _databaseContext = databaseContext;
        }

        public UserDatabaseModel GetByEmail(string email)
        {
            return _databaseContext.Users.SingleOrDefault(u => u.Email == email);

        }

        public void SaveUser (UserDatabaseModel user){
            UserDatabaseModel userFromDb = _databaseContext.Users.SingleOrDefault(u => u.Id == user.Id);
            if(userFromDb != null)
            {
                _databaseContext.Users.Add(user);
            }
            else
            {
                userFromDb = user;
            }
            _databaseContext.SaveChanges();
        } 
    }
}