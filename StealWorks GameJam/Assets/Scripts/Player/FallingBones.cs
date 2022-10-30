using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FallingBones : MonoBehaviour
{
    List<Rigidbody> boneObjects;
    int lastIdx = 0;
    void Start()
    {
        //disable all colliders ffs
        //this.GetComponentsInChildren<Collider>().ToList().ForEach(c => c.isTrigger = true);

        //get only rigidbodies with meshes
        boneObjects = this.GetComponentsInChildren<Rigidbody>().ToList()
            .Where(r => r.GetComponentInChildren<MeshFilter>())
            .OrderBy(r => r.gameObject.transform.position.y).ToList();
        Debug.Log(boneObjects.Count+" bones");

    }
    private void Update()
    {
        float f = Mathf.InverseLerp(0, PlayerMovement.lifeTime, Time.time);
        for (int i = lastIdx; i <= f * boneObjects.Count && i < boneObjects.Count; i++)
        {
            boneObjects[i].isKinematic = false;
            boneObjects[i].useGravity = true;
            boneObjects[i].transform.parent = GameObject.Find("Enviro").transform;
            //boneObjects[i].GetComponentInChildren<MeshCollider>().isTrigger = false;
            //var sc= boneObjects[i].gameObject.AddComponent<SphereCollider>();
            //sc.radius = 0.01f;
            lastIdx = i;
        }
    }
}
