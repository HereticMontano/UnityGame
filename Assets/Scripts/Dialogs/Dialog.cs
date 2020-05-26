using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Dialog
    {
        public string name;
        [TextArea(3,10)]
        public string[] sentences;
    }
}
