using UnityEngine;
using UnityEngine.Events;

public class ChequearDistancia : MonoBehaviour
{
    public float minDistance;
    public Transform target;
    public UnityEvent onDistance;

    public void CompararDistancia()
    {
        if(Vector3.Distance(transform.position , target.position)<= minDistance)
        {
            onDistance.Invoke();
        }
    }

}
