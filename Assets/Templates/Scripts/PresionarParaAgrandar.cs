using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PresionarParaAgrandar : MonoBehaviour
{
    public Transform target;
    public Transform objeto;
    public float scaleSpeed;

    public UnityEvent onFitScale;

    float scaleTarget;
    bool canScale;
    bool finishScale;
    private void Awake()
    {
        scaleTarget = target.localScale.x;
    }

    public void StartScale() => canScale = true;


    public void DeneterScale() => canScale = false;


    private void Update()
    {
        if (finishScale) return;

        if(canScale)
            objeto.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

        if (objeto.transform.localScale.x >= scaleTarget)
        {
            onFitScale.Invoke();
            finishScale = true;
        }
    }
}
