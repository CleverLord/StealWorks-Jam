using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UiFiller : MonoBehaviour
{
    public Slider s;
    public float tStart;
    public float tEnd;
    public bool sliding = true;
    public static UiFiller uf;
    public Action onEnd;
    // Start is called before the first frame update
    void Start()
    {
        uf = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sliding)
            return;
        s.value = Mathf.InverseLerp(tStart, tEnd, Time.time);
        if (s.value == 1)
        {
            onEnd?.Invoke();
            StopSliding();
        }
    }

    public void StartSliding(float slidingTime,Action a)
    {
        onEnd = a;
        tStart = Time.time;
        tEnd = Time.time + slidingTime;
        s.gameObject.SetActive(true);
        sliding = true;
    }
    public void StopSliding()
    {
        s.gameObject.SetActive(false);
        sliding = false;
    }
}
