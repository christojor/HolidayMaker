using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker
{
    /// <summary>
    /// A class that shows the structure of secrets inside this project. The secrets are stored in secrets.json and should be read from here when needed. 
    /// </summary>
    public class Secret
    {
        public string Name { get; init; }
        public string Key { get; init; }
    }
}
