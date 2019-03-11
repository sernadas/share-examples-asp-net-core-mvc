using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // database has been seeded
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department { Id=4, Name="Books"};


            Seller s1 = new Seller(1, "Bob Brown", "Bob@gmail.com", new DateTime(1980, 10, 10), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "Maria@gmail.com", new DateTime(1980, 10, 11), 1100.0, d1);
            Seller s3 = new Seller(3, "Alex Grey", "Alex@gmail.com", new DateTime(1980, 10, 12), 1200.0, d2);
            Seller s4 = new Seller(4, "Martha Red", "Martha@gmail.com", new DateTime(1980, 10, 13), 1300.0, d2);
            Seller s5 = new Seller(5, "Donald Blue", "Donald@gmail.com", new DateTime(1980, 10, 14), 1400.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "Pink@gmail.com", new DateTime(1980, 10, 15), 1500.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2019, 03, 10), 10000, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2019, 03, 10), 11000, SaleStatus.Canceled, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2019, 03, 11), 12000, SaleStatus.Pending, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2019, 03, 11), 13000, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2019, 03, 12), 14000, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2019, 03, 12), 15000, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2019, 03, 12), 16000, SaleStatus.Pending, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7);

            _context.SaveChanges();

        }
    }
}
