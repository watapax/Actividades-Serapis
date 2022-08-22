using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float height = 1f;
    public float speed = 2f;
    Vector3 startPos;
 
    void Start() 
    {
        startPos = this.transform.position;
    }
 
    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Cos(Time.time * speed) * height;
    }
}
