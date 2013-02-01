using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using CanteenBoard.Core.Meal;

namespace Repositories
{
    public class MenuRepository : MongoRepository
    {
        private const string _collName = "Food";

        public void AddFood(string name)
        {
            var col = Database.GetCollection<Food>(_collName);

            var x = from f in col.AsQueryable()
                    where f.Title == "Rezen"
                    select f;

            Food r = x.FirstOrDefault();
        }
    }
}
