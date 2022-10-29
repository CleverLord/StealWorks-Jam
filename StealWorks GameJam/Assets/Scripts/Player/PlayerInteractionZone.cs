using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractionZone : MonoBehaviour
{
    public bool activated = false;
    public float interactionTime = 3;
    public UnityEvent onInteracted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TestInteract()
    {
        Debug.Log("Interacted!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (other.CompareTag("Player"))
        {
            UiFiller.uf.StartSliding(interactionTime, () => { onInteracted.Invoke(); this.activated = true; });
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (activated) return;
        if (other.CompareTag("Player"))
        {
            UiFiller.uf.StopSliding();
        }
    }
}
