using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MoverAPosRandom : MonoBehaviour
{
    public UnityEvent onComplete;

    public Transform originTransformPostition;
    public Transform[] targets;
    public float lerpTime = 0.7f;
    public bool fromScale0;
    public bool startOnAwake;
    List<Transform> ShuffleTargets = new List<Transform>();
    Vector3[] targetPos;


    int indexPos = 0;
    int indexScale = 0;

    private void Awake()
    {
        targetPos = new Vector3[targets.Length];
        Shuffle();
        ResetPosition();
        if (fromScale0)
            ResetScale();
       
    }
    private void Start()
    {
        if(startOnAwake)
            Mover();
        
    }

    void Shuffle()
    {
        ShuffleTargets = targets.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < ShuffleTargets.Count; i++)
        {
            targetPos[i] = ShuffleTargets[i].position;
        }
    }

    void ResetPosition()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].position = originTransformPostition.position;
        }
    }

    void ResetScale()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].localScale = Vector3.zero;
        }
    }

    public void Mover()
    {
        StartCoroutine(Interpolar());
        StartCoroutine(Escalar());
        
    }

    IEnumerator Interpolar()
    {
        
        float t = 0;

        while(t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            perc = perc * perc * perc * (perc * (6f * perc - 15f) + 10f);
            targets[indexPos].position = Vector3.Lerp(originTransformPostition.position, targetPos[indexPos], perc);
            yield return null;
        }

        indexPos++;

        if (indexPos < targetPos.Length)
            StartCoroutine(Interpolar());
        else
            onComplete.Invoke();    
    }

    IEnumerator Escalar()
    {
        if (!fromScale0) yield return null;

        float t = 0;

        while (t < lerpTime)
        {
            t += Time.deltaTime;
            float perc = t / lerpTime;
            perc = perc * perc * perc * (perc * (6f * perc - 15f) + 10f);
            targets[indexScale].localScale = Vector3.Lerp(Vector3.zero, Vector3.one, perc);
            yield return null;
        }

        indexScale++;

        if (indexScale < targetPos.Length)
            StartCoroutine(Escalar());

    }

}
