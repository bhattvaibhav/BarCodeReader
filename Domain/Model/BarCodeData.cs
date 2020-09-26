using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class BarCodeData
    {
        public string type { get; set; }
        public Symbol[] symbol { get; set; }
    }
}
