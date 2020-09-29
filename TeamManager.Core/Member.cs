using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManager.Core
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
