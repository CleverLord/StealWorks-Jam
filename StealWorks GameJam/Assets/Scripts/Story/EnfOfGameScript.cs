using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnfOfGameScript : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI textOnWin;
    public TextMeshProUGUI textOnDeath;
    // Start is called before the first frame update
    public void onWin()
    {
        Debug.Log("onWin");
        panel.gameObject.SetActive(true);
        textOnWin.gameObject.SetActive(true);
        LeanTween.value(0, 1, 3).setDelay(3).setOnUpdate((float val) => panel.color = new Color(0, 0, 0, val));
        LeanTween.value(0, 1, 2).setDelay(6).setOnUpdate((float val) => textOnWin.color = new Color(1, 1, 1, val));
    }

    public void onLose()
    {
        Debug.Log("onLose");
        panel.gameObject.SetActive(true);
        textOnDeath.gameObject.SetActive(true);
        textOnDeath.text = new string[] {"The dream won't end that easily",
            "Only you can end this torment",
            "You will be stuck here until you wake up... if you wake up..."}[Random.Range(0,3)];

        LeanTween.value(0, 1, 3).setDelay(3).setOnUpdate((float val) => panel.color = new Color(0, 0, 0, val));
        LeanTween.value(0, 1, 2).setDelay(6).setOnUpdate((float val) => textOnDeath.color = new Color(1, 1, 1, val));

    }
    // Update is called once per frame
    void Update()
    {

    }
}
