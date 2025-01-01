using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model_Binding.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<string> Hobbies { get; set; }
        public bool TermsAccepted { get; set; }
    }
}