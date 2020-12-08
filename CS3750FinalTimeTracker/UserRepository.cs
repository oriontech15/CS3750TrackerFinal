using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public IEnumerable<SelectListItem> GetUserListForDropDown()
        //{
        //    return _db.User.Select(i => new SelectListItem()
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    });
        //}

        //public IEnumerable<SelectListItem> GetUserListForDropDown()
        //{
        //    throw new NotImplementedException();s
        //}

        //public void Update(User user)
        //{
        //    var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

        //    objFromDb.Name = category.Name;
        //    objFromDb.DisplayOrder = category.DisplayOrder;

        //    _db.SaveChanges();
        //}

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
