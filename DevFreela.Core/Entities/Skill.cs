using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description) {
            CreatedAt = DateTime.Now;
            Description = description;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}