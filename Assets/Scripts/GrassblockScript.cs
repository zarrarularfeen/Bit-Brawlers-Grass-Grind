using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassblockScript : MonoBehaviour
{
    public GameObject dirtPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lawnmower"))
        {
            ReplacewithDirt();
        }
            
    }

        


    private void ReplacewithDirt()
    {
        GameObject dirtBlock = Instantiate(dirtPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}


