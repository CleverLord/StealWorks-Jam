using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBonerSpawner : MonoBehaviour
{
    [SerializeField] float interval = 1;
    [SerializeField] GameObject prefab;
    [SerializeField] float currentTime = 0;
    void Start()
    {
        currentTime = interval;    
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            GameObject boneStack = Instantiate(prefab, this.transform);
            boneStack.transform.localPosition = Vector3.zero;
            currentTime = interval;
        } else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
