using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetTexture : MonoBehaviour
{
    public Vector2 velocidad;
    public float speed;
    public SpriteRenderer spr;
    

    void Update()
    {
        velocidad.x += speed * Time.deltaTime;
        velocidad.y += speed * Time.deltaTime;
        spr.sharedMaterial.SetTextureOffset("_MainTex", velocidad);
    }
}
