using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D Ftire;
    public Rigidbody2D Btire;
    public float speed;
    public float movement;
    public AudioSource[] src;
    public AudioClip mowersound, bgmusic, levelpass, levelfail;
    private bool applyForce = true;
    public ParticleSystem smoke;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject endScreen;
    public GameObject failScreen;
    [SerializeField] private GameObject drawshit;
    [SerializeField] private GameObject buttonshit;
    [SerializeField] private GameObject linecountshit;
    private Timer timerScipt;
    public GameObject stars1;
    public GameObject stars2;
    public GameObject stars3;
    private int starCount;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponents<AudioSource>();
        timerScipt = timer.GetComponent<Timer>();
    }

    void Awake()
    {
        src[0].clip = bgmusic;
        src[0].Play();
        src[0].loop = true;
    }
    // Update is called once per frame
    private void Update()
    {
        movement = 1;
    }


    // FixedUpdate is called multiple times per frame
    public void Button()
    {
        // src[0].volume = 0.2f;
        src[1].clip = mowersound;
        src[1].volume = 0.3f;
        src[1].Play();
        

        StartCoroutine(Move());
        
        Destroy(drawshit);
        Destroy(buttonshit);
        Destroy(linecountshit);
    }
    private IEnumerator Move()
    {
        while (applyForce)
        {
            ApplyForce();
            yield return new WaitForFixedUpdate(); // Ensure it runs with physics updates
        }
    }
    private void ApplyForce()
    {

        Ftire.AddTorque(-movement * speed * Time.deltaTime);
        Btire.AddTorque(-movement * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("offScreen"))
        {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        


        if (collision.gameObject.CompareTag("endFlag"))
        {
            speed = 0;
            movement = 0;
            Ftire.AddTorque(-movement * speed * Time.deltaTime);
            Btire.AddTorque(-movement * speed * Time.deltaTime);
            timer.SetActive(false);
            endScreen.SetActive(true);
            src[1].Stop();
            src[2].clip = levelpass;
            src[2].Play();
            Time.timeScale = 0;


           
            GameObject[] grassObjects = GameObject.FindGameObjectsWithTag("Grass");
            starCount = 1;
            // Check if the length of the array is greater than zero
            if (grassObjects.Length == 0)
            {
                
                starCount += 1;
                
            }
           
            float timeleft = timerScipt.remainingTime;
            
            if (timeleft >= 3)
            {
              
                starCount++;
                
            }

            if (starCount == 3)
            {
                stars3.SetActive(true);
                Debug.Log("stars count" + starCount);

            }
            else if (starCount == 2)
            {
                stars2.SetActive(true);
                Debug.Log("stars count" + starCount);
            }
            else
            {
                stars1.SetActive(true);
                Debug.Log("stars count" + starCount);
            }

            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
                PlayerPrefs.Save();
            }
        }

        if (collision.gameObject.CompareTag("rotatorFlag"))
        {
            collision.enabled = false;
            speed *= -1; // Reverse the direction
            Vector3 originalScale = gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
            SetParticleVelocity();

        }
        if(collision.gameObject.CompareTag("Flower"))
        {
            Debug.Log("Flower destroyed");
            Invoke("DelayFailScreen", 0.55f);        
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            src[1].Stop();
            src[2].clip = levelfail;
            src[2].Play();
            failScreen.SetActive(true);
            Time.timeScale = 0;
            
        }



    }

    private void SetParticleVelocity()
    {
        var velocityModule = smoke.velocityOverLifetime;
        velocityModule.enabled = true;
        ParticleSystem.MinMaxCurve currentX = velocityModule.x;
        float newX = currentX.constant * -1;
        velocityModule.x = new ParticleSystem.MinMaxCurve(newX);
    }

    private void DelayFailScreen()
    {
        Time.timeScale = 0;
        failScreen.SetActive(true);
    }

}
