using System.Collections.Generic;

namespace EmployeePortal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<Meet> Meets { get; set; }
    }
}
