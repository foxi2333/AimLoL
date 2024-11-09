using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
     public Transform transformCube;
     public Transform transformSphere;
    public float x;
    public float y;
    public int speed;
     private void Start()
    {
        x += 1 * Time.deltaTime;
        y += 1 * Time.deltaTime;
        transformCube.position = new Vector3(x, y, 25f);
    }
    
    
        
 }

