using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    [Range(0.005f,0.04f)]
    public float fogDencity = 0.04f;
    public Color fogColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogColor = fogColor;
        Camera.main.backgroundColor = fogColor;
        RenderSettings.fogDensity = fogDencity;
    }
}
