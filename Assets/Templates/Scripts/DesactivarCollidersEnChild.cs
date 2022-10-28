using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCollidersEnChild : MonoBehaviour
{
    public void DesactivatCollider(GameObject parent)
    {
        Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }

    public void ActivarColliders(GameObject parent)
    {
        Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = true;
        }
    }
}
