using System;
using EmployeePortal.Models;

namespace EmployeePortal.Models
{
    public class Meet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
