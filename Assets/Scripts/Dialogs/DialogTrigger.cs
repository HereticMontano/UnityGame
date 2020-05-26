using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DialogTrigger: MonoBehaviour
    {
        public Dialog dialogue;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            FindObjectOfType<DialogManagerController>().StarDialog(dialogue);
            Destroy(gameObject);
        }
        
    }
}
