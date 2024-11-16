using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScript : MonoBehaviour
{
    public Transform transform;
    public float x;
    public float y;
    public GameObject Cube;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            y += 3*Time.deltaTime;
            transform.position = new Vector3(x, y, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 3 * Time.deltaTime;
            transform.position = new Vector3(x, y, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            y -= 3 * Time.deltaTime;
            transform.position = new Vector3(x, y, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 3 * Time.deltaTime;
            transform.position = new Vector3(x, y, 0.0f);
        }
        void Start()
        {
            transform.position = new Vector3(2.0f, 0.0f, 0.0f);
        }

    }
}