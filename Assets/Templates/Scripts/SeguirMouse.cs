using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMouse : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 up =  (Vector3) mousePos - transform.position;
        transform.up = up;

    }
}
