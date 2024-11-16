using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDestroy : MonoBehaviour
{
    public Transform transformCube;
    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    void Start()
    {
        transformCube.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
