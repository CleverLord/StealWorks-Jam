using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BekonScript : MonoBehaviour
{
    public GameObject spotLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateLight()
    {
        spotLight.SetActive(true);
        spotLight.LeanMoveLocalY(2, 2);
    }
}
