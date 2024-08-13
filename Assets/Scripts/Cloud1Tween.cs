using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud1Tween : MonoBehaviour
{
    [SerializeField] LeanTweenType easeType;
    [SerializeField] float duration;
    [SerializeField] float distanceX; // Serialized field for distance to be moved in the x axis
    [SerializeField] float distanceY; // Serialized field for distance to be moved in the x axis

    void Start()
    {
        Loop();
    }

    void Loop()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z);

        LeanTween.move(gameObject, endPos, duration).setEase(easeType).setOnComplete(() =>
        {
            transform.position = startPos;
            Loop();
        });
    }
}
