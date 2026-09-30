using System.Data.Common;
using Combine_Day_Twenty_N_tier_API.Data;
using Combine_Day_Twenty_N_tier_API.Models;

namespace Combine_Day_Twenty_N_tier_API.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly AppDbContext _db;

        //Construcotor runs once when the class is called automatically
        //ASP.NET Core hands us the database connection because we registered it in the Program.cs
        public SupplyRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Supply> GetAll()
        {
            return _db.Supplies.ToList();
        }

        public Supply? GetById(int id)
        {
            return _db.Supplies.FirstOrDefault(s => s.Id == id);
        }

        public Supply Add(Supply supply)
        {
            _db.Supplies.Add(supply);
            _db.SaveChanges();
            return supply;
        }

        public void Update(Supply supply)
        {
            //The supply camout of out of the DB through GetById so Ef Core is already Tracking it
            //We just ned to save the changes
            _db.SaveChanges();
        }

        public void Delete(Supply supply)
        {
            _db.Supplies.Remove(supply);
            _db.SaveChanges();
        }
    }
}