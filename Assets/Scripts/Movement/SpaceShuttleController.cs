using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleController : MonoBehaviour
{
    public ParticleSystem[] partycle;
    private bool wasLaunched;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in partycle)
        {
            item.Stop();
        }

    }

    private void FixedUpdate()
    {
        if (wasLaunched)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity += Vector2.up * 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wasLaunched = true;
            foreach (var item in partycle)
                item.Play();

            FindObjectOfType<CinemachineVirtualCamera>().Follow = transform;
        }
    }
}
