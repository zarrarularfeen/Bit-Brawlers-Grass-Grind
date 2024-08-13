using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScriptDozer : MonoBehaviour
{
    public Transform destination;
    public GameObject player;
    public AudioSource src;
    public AudioClip portalsound;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dozer"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.5f)
            {
                src.clip = portalsound;
                src.Play();
                player.transform.position = destination.transform.position;
            }
        }
    }
}
