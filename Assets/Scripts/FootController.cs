using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts
{
    public class FootController : MonoBehaviour
    {

        public ParticleSystem particles;
        
        private ParticleSystem leftSideParticle;

        private void Start()
        {
            leftSideParticle = Instantiate(particles);
        }

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                if (GetComponentInParent<Transform>().rotation.y == 0)
                {
                    particles.transform.position = transform.position + new Vector3(7, -15, 0);
                    leftSideParticle.transform.position = transform.position + new Vector3(-14, -15, 0);
                }
                else
                {
                    particles.transform.position = transform.position + new Vector3(-7, -15, 0);
                    leftSideParticle.transform.position = transform.position + new Vector3(14, -15, 0);
                }
                particles.Play();
                leftSideParticle.Play();
            }
        }
    }
}
