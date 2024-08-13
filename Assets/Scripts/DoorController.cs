using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject opendoor;
    public GameObject closeddoor;
    public GameObject key; 
    public AudioSource src;
    // public AudioClip doorsound;

    // Start is called before the first frame update
    void Start()
    {
        // src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D()
    {
        // src.clip = doorsound;
        src.time = 3.0f;
        src.Play();
        key.SetActive(false);
        closeddoor.SetActive(false);
        opendoor.SetActive(true);
        
    }
}
