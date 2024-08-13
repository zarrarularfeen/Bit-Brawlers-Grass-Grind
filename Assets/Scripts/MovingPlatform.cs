using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float liftspeed;
    public int startingPoint;
    public Transform[] points;
    public Rigidbody2D Ftire;
    public Rigidbody2D Btire;
    public float mowerspeed;
    private bool startLift = true;
    private int i;
    private int movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        // {
        //     i++;
        //     if (i == points.Length)
        //     {
        //         i = 0;
        //     }
        // }

        // transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BTire"))
        {
            Ftire.velocity = Vector2.zero;
            Ftire.angularVelocity = 0f;
            Btire.velocity = Vector2.zero;
            Btire.angularVelocity = 0f;

            StartCoroutine(StartLift());
        }
    }

    private IEnumerator StartLift()
    {
        while (startLift)
        {
            Move();
            yield return new WaitForFixedUpdate(); // Ensure it runs with physics updates
        }
    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                startLift = false;
                // Ftire.constraints = RigidbodyConstraints2D.None;
                // Btire.constraints = RigidbodyConstraints2D.None;
                movement = 1;
                Ftire.AddTorque(-movement * mowerspeed * Time.deltaTime);
                Btire.AddTorque(-movement * mowerspeed * Time.deltaTime);
                
            }
        }
        if (startLift == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, liftspeed * Time.deltaTime);
        }    
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    
}
