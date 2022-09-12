using UnityEngine;
using UnityEngine.Events;
public class EventosBoton : MonoBehaviour
{
    public UnityEvent onMouseDown, onMouseUp, onMouseEnter, onMouseExit;
    private void OnMouseDown()
    {
        print("peoB");
        onMouseDown.Invoke();      
    }

    private void OnMouseUpAsButton()
    {
        onMouseUp.Invoke();
    }

    private void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }

    private void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
}
