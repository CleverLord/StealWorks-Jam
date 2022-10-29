using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBall : MonoBehaviour
{
    public bool orbitPlayer = true;
    public bool goToTarget = false;
    public GameObject target;

    public string key="red";
    public float orbitingRadius = 0.7f;
    public float orbitingHeight = 1f;
    public GameObject orbiter;
    public GameObject player;
    public float closeDistance = 0.1f;
    public float angualarSpeed = 12f;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!orbiter)
        {
            orbiter = new GameObject("orbiter");
            orbiter.transform.parent = player.transform;
            Vector3 dir = this.transform.position - player.transform.position;
            orbiter.transform.position = dir.normalized * orbitingRadius+ player.transform.position;
            orbiter.transform.position = new Vector3(orbiter.transform.position.x, orbitingHeight, orbiter.transform.position.z);
        }
    }

    public bool isCloseToOrbit => (this.transform.position - orbiter.transform.position).magnitude < closeDistance;
    public void Update()
    {
        if (isCloseToOrbit)
            orbiter.transform.RotateAround(player.transform.position, Vector3.up, angualarSpeed * Time.deltaTime);
        if(orbitPlayer)
            MoveTowardsOrbit();
        if (goToTarget)
            MoveTowardsTarget();

    }
    public float maxSpeed = 1;
    public void MoveTowardsOrbit()
    {
        Vector3 dir = orbiter.transform.position - transform.position;
        if (dir.magnitude > maxSpeed * Time.deltaTime)
            dir = dir.normalized * maxSpeed * Time.deltaTime;
        transform.position += dir;
    }
    public void MoveTowardsTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude > maxSpeed * Time.deltaTime)
            dir = dir.normalized * maxSpeed * Time.deltaTime;
        transform.position += dir;
    }
}
