using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_project_hashtable
{
    public class HashNode
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public HashNode Next { get; set; }

        public HashNode(string key, object value)
        {
            this.Key = key;
            this.Value = value;
            this.Next = null;
        }
    }
}
