using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Models
{
    public class OpeningTimeSection
    {
        public TimeSpan StartAt { get; set; }
        public TimeSpan FinishAt { get; set; }

    }
}