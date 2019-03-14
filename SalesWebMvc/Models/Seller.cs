using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{

    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        //[StringLength(60,MinimumLength=3,ErrorMessage ="Name size should be between 3 and 60")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0,5000.0, ErrorMessage ="{0} must be from {1} and {2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            /*
            double totalSales;

            totalSales =
                (
                from sr in Sales
                where sr.Date.CompareTo(initial) >= 0 && sr.Date.CompareTo(final) <= 0
                select sr.Amount
                ).DefaultIfEmpty(0).Sum();

            return totalSales;
            */
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Select(sr => sr.Amount).DefaultIfEmpty(0.0).Sum();
        }


    }
}
