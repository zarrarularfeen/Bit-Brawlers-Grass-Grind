using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScript : MonoBehaviour
{
    [SerializeField] LeanTweenType easeType;

    void Start()
    {
        ScaleUp();
    }

    void ScaleUp()
    {
        LeanTween.scale(gameObject, transform.localScale*(1.15f), 4f).setEase(easeType).setLoopPingPong();
    }
}
