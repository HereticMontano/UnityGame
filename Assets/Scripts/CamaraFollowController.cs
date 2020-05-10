using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CamaraFollowController : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offSet;

        private void FixedUpdate()
        {
            Vector3 desirePosition = target.position + offSet;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}
