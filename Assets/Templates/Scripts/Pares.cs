using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pares : MonoBehaviour
{
    public UnityEvent onMatch;

    public void Match()
    {
        print("Match");
        onMatch.Invoke();
    }
}
