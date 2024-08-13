using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrassDestroyer : MonoBehaviour
{
    public ParticleSystem bust;
    public AudioSource src;
    // public AudioClip grasssound;

    // Start is called before the first frame update
    void Start()
    {
        // src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lawnmower"))
        {
            // src.clip = grasssound;
            src.Play();
            Destroy(gameObject);
            Instantiate(bust,transform.position,Quaternion.identity);
        }
        
    }
}   