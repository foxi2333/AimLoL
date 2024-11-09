using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public Transform transformCube;
    public Transform transformSphere;
    public float x;
    public float y;
    public int speed;
    private void Update()
    {
        x += speed * Time.deltaTime;
        y += 1 * Time.deltaTime;
         transformCube.position = new Vector3 (x, y,35f);

    }
    
}
