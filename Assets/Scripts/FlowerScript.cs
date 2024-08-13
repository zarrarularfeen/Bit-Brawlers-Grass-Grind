using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlowerScript : MonoBehaviour

    
{
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lawnmower"))
        {
           
            Destroy(gameObject);
            
        }


    }
    
}


