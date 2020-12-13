using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Config
{
    public class AppSettings : StringPairConfiguration
    {
        public AppSettings() : base("vrjc-settings")
        {
        }
    }
}
