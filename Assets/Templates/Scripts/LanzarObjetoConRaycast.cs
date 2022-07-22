using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarObjetoConRaycast : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask layerMask;
    bool viajando;
    bool activado = true;
    public float fuerza;
    Vector3 startPos;
    public float correccionX;
    string startTag;
    public string targetTag;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        startPos = transform.position;
        startTag = gameObject.tag;
    }

    private void Update()
    {
        if (!activado) return;
        if(Input.GetMouseButtonDown(0) && !viajando)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, layerMask))
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Vector3 direccion = hit.point - transform.position;
            transform.forward = direccion;
            transform.localEulerAngles = new Vector3(correccionX + transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            rb.isKinematic = false;
            rb.AddForce(transform.forward * fuerza, ForceMode.Impulse);
            viajando = true;
        }
    }

    public void SetComponent(bool _state)
    {
        activado = _state;
        if (!activado)
            gameObject.tag = "Untagged";
    }


    public void ResetComponent()
    {
        viajando = false;
        activado = true;
        gameObject.tag = startTag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        viajando = false;
    }





}
