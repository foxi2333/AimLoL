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

    private void Update()
    {
        y += 2 * Time.deltaTime;
        x += speed * Time.deltaTime;
        transformCube.position = new Vector3(x, y, 25f);

    }
}
