using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CheckBloque : MonoBehaviour
{
    public UnityEvent onComplete;
    public bloque[] bloques;
    public int cantidad = 0;
    public int total;
    bool checking;
    float waitTime = 3;
    bool stop;
    private void Update()
    {
        if (stop) return;
        cantidad = 0;
        for (int i = 0; i < bloques.Length; i++)
        {
            cantidad += bloques[i].tieneVecino ? 1 : -0;
            cantidad = Mathf.Clamp(cantidad, 0, total);
        }
        if(cantidad == total && !checking)
        {
            StartCoroutine(CheckCantidad());
        }

    }

    IEnumerator CheckCantidad()
    {
        checking = true;
        yield return new WaitForSeconds(waitTime);

        if (cantidad == total)
        {
            onComplete.Invoke();
            stop = true;
        }
        else
            checking = false;
    }
}
