using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnfOfGameScript : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI tfp;
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(true);
        tfp.gameObject.SetActive(true);
        LeanTween.value(0, 1, 3).setDelay(4).setOnUpdate((float val) => panel.color = new Color(0, 0, 0, val));
        LeanTween.value(0, 1, 2).setDelay(9).setOnUpdate((float val) => tfp.color = new Color(1, 1, 1, val));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
