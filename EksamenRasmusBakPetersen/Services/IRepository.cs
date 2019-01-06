using EksamenRasmusBakPetersen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamenRasmusBakPetersen.Services
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Item> GetAll();
        Item GetItemById(int id);
        void CreateItem(Item item);
        void Save();
    }
}
