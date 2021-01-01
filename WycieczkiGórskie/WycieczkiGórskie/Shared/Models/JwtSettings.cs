using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WycieczkiGórskie.Shared.Models
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }
}
