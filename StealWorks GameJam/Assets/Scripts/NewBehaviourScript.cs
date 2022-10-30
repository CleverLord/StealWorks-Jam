using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Image im;
    void Start()
    {
        im = GetComponent<Image>();
        LeanTween.value(1, 0, 4).setDelay(1).setOnUpdate((float val) => im.color = new Color(0, 0, 0, val));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
