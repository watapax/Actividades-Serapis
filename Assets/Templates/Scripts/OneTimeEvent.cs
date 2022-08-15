using UnityEngine;
using UnityEngine.Events;
public class OneTimeEvent : MonoBehaviour
{
    public UnityEvent evento;
    bool wasCalled;

    public void EjecutarEvento()
    {
        if (wasCalled) return;

        evento.Invoke();
        wasCalled = true;
    }


}
