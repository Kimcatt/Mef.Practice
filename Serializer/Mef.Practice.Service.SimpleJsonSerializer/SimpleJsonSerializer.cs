using Mef.Practice.Service.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonSerializer
{
    [Export(typeof(ISerializer))]
    public class SimpleJsonSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj); 
        }
    }
}
