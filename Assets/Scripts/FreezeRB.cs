using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRB : MonoBehaviour
{
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze()
    {
        Time.timeScale = 0;
        // rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnFreeze()
    {
        Time.timeScale = 1;
        // rb.constraints = RigidbodyConstraints2D.None;
    }
}
