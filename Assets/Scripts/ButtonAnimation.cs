using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Pressed()
    {
        transform.LeanScale(Vector3.one * 0.8f, 0.2f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            transform.LeanScale(Vector3.one, 0.2f).setEase(LeanTweenType.easeOutQuad);
        });
    }
}
