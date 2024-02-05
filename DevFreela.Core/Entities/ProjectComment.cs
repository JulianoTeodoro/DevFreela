using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}