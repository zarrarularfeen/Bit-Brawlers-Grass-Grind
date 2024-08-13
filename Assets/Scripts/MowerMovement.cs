
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject drawshit;
    private Rigidbody2D body;
    public Vector2 force = new Vector2(10f, 0f); // Adjust the force as needed
    private bool applyForce = true;


    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    public void Move()
    {
        // body.velocity = new Vector2(speed, body.velocity.y);

        StartCoroutine(ApplyConstantForce());
        Destroy(drawshit);
    }

    private IEnumerator ApplyConstantForce()
    {
        while (applyForce)
        {
            ApplyForce();
            yield return new WaitForFixedUpdate(); // Ensure it runs with physics updates
        }
    }

    private void ApplyForce()
    {
        body.AddForce(force);
    }

    // Optional: Stop applying force, if needed
    public void StopApplyingForce()
    {
        applyForce = false;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed *= -1; // Reverse the direction

            // Flip the sprite's face
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }*/
}
