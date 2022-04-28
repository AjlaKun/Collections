﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Models
{
    internal class LogEntry
    {

        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime timeOfEvent { get; set; }
    }
}
