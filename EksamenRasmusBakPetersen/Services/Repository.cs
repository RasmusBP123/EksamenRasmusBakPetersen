using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EksamenRasmusBakPetersen.Data;

namespace EksamenRasmusBakPetersen.Services
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public void CreateItem(Item item)
        {
            _context.Items.Add(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //Dispose///

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed != true)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
