using System;
using System.Collections.Generic;

namespace testdevbackjr.Models
{
    public class Area
    {
        public int IDArea { get; set; }
        public required string AreaName { get; set; }
        public int StatusArea { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}