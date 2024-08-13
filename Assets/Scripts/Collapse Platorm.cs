using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsePlatorm : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lawnmower"))
        {
            Destroy(gameObject);
        }
    }
}
