using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrbitingBallAttractionPoint : MonoBehaviour
{
    public OrbitingBall ob;
    public UnityEvent onOrbitingBallEntered;
    public bool obEntered = false;
    public string orbitingBallKey = "red";
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (!target)
            target = this.gameObject;
    }
    public void TestEnter()
    {
        Debug.Log(orbitingBallKey + " entered");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObEntered();
    }
    void CheckForObEntered()
    {
        if (!ob) return;
        if (obEntered) return;
        Vector3 dir = target.transform.position - ob.transform.position;
        if (dir.magnitude < 0.1)
        {
            obEntered = true;
            onOrbitingBallEntered?.Invoke();
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var ob = other.GetComponent<OrbitingBall>();
        if (ob)
        {
            if (ob.key != orbitingBallKey) return;

            ob.orbitPlayer = false;
            ob.goToTarget = true;
            ob.target = target;
            this.ob = ob;
        }
    }
}
