using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWave : MonoBehaviour
{
    public Transform[] objetos;
    public float yCenter = 0;
    public float maxY;
    public float speed;
    

    private void FixedUpdate()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].transform.position = new Vector3(objetos[i].transform.position.x, yCenter + Mathf.PingPong(Time.time * speed, maxY) - maxY / 2f, objetos[i].transform.position.z);//move on y axis only
        }
    }
}
