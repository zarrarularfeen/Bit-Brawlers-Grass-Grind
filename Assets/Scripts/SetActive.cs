using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Time.timeScale = 1;
        if (gameobject.activeInHierarchy == false)
        {
            gameobject.SetActive(true);
        }
        else
        {
            gameobject.SetActive(false);
        }
    }
}
