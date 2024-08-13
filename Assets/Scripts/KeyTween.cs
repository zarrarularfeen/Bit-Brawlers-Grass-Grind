using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTween : MonoBehaviour
{
    [SerializeField] LeanTweenType easeType;
    [SerializeField] float duration;
    [SerializeField] float distanceY;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Loop();
    }

    void Loop()
    {
        Vector3 endPos = new Vector3(startPos.x, startPos.y + distanceY, startPos.z);

        LeanTween.move(gameObject, endPos, duration).setEase(easeType).setOnComplete(() =>
        {
            LeanTween.move(gameObject, startPos, duration).setEase(easeType).setOnComplete(() =>
            {
                Loop();
            });
        });
    }
}
