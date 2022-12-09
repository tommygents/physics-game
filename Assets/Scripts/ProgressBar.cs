using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class ProgressBar : MonoBehaviour
{
    public GameObject Bar;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(Bar, 1, time);
    }
}