using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirtparticle : MonoBehaviour
{
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the particle system collides with a specific GameObject
        if (collision.gameObject.CompareTag("Lawnmower"))
        {
            // Destroy the particle system
            Destroy(gameObject);
        }
    }
}








