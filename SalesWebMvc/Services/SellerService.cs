using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;


namespace SalesWebMvc.Services
{
    public class SellerService
    {

        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll ()
        {
            //return _context.Seller.Select(s => s).ToList();
            return _context.Seller.ToList();
        }

        public Seller FindById (int id)
        {
            //return _context.Seller.Where(s => s.Id == id).First();
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Insert (Seller obj)
        {
            _context.Seller.Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Seller obj = FindById(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update (Seller obj)
        {
            if (!_context.Seller.Any(s => s.Id == obj.Id))
            {
                throw new NotFoundException("Id not found.");
            }
            try
            {
                _context.Seller.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
