using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public People(int id, string name, bool isActive)
        {
            this.Id = id;
            this.Name = name;
            this.IsActive = isActive;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " IsActive: " + IsActive;
        
        }

    }
}
