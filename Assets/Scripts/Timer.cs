using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    public AudioSource vehiclesrc;
    public AudioSource src;
    public AudioClip timeendsound, levelfail;    
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime;
    [SerializeField] GameObject failScreen;
    private bool startTimer = true;

    // Update is called once per frame

    private void Start()
    {
        src = GetComponent<AudioSource>();
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void OnPlay()
    {   
        StartCoroutine(TButton());
    }

    private IEnumerator TButton()
    {
        while (startTimer)
        {
            TStart();
            yield return new WaitForFixedUpdate(); // Ensure it runs with physics updates
        }
    }

    private void TStart()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if  (remainingTime == 4)
            {
                vehiclesrc.Stop();
                // src.clip = timeendsound;
                // src.Play();
            }
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            // Game Over
            timerText.color = Color.red;
            failScreen.SetActive(true);
            src.clip = levelfail;
            // src.time = 2.0f;
            src.Play();
            Time.timeScale = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
