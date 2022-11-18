using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class bloque : MonoBehaviour
{
    public UnityEvent onRightPosition;
    public bool horizontal, vertical;
    Vector2 direccion = Vector2.zero;
    bool isInArea;
    public LayerMask layerMask;
    Rigidbody2D rb;
    Vector3 startPos;
    Quaternion startRot;

    public bool tieneVecino;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        startRot = transform.rotation;
        if (horizontal) direccion.x = -1;
        if (vertical) direccion.y = -1;
    }

    public void CheckArea()
    {
        if(isInArea)
        {
            rb.isKinematic = false;
        }
        else
        {
            StartCoroutine(ResetPos());
        }
    }

    RaycastHit2D hit;
    private void Update()
    {
        Debug.DrawRay(transform.position, direccion);
        hit = Physics2D.Raycast(transform.position, direccion, 1, layerMask);
        tieneVecino = hit.collider != null;
    }

    float lerpTime = 0.3f;
    IEnumerator ResetPos()
    {
        GetComponent<Collider2D>().enabled = false;
        Vector3 from = transform.position;
        float t = 0;
        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            transform.position = Vector3.Lerp(from, startPos, perc);
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("area"))
        {
            isInArea = true;
        }
        if (collision.CompareTag("1"))
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            transform.rotation = startRot;
            StartCoroutine(ResetPos());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("area"))
        {
            isInArea = false;
        }
    }
}
