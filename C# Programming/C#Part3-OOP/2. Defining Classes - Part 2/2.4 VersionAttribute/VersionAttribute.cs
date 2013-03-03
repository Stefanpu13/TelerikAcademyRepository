using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
        AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Interface) ]
    class VersionAttribute: System.Attribute
    {
        public VersionAttribute(int major, int minor) 
        {
            MajorVersion = major;
            MinorVersion = minor;            
        }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }
       

        public override string ToString()
        {
            

            string versionInfo = " Version: " + MajorVersion + "." + MinorVersion;
            return versionInfo;
        }
    }
}
