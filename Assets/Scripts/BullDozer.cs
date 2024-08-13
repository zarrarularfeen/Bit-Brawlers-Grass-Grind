using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullDozer : MonoBehaviour
{

    public ParticleSystem ejaculate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullDozer"))
        {
            Destroy(gameObject);
            Instantiate(ejaculate,transform.position,transform.rotation);
        }
    }
}
