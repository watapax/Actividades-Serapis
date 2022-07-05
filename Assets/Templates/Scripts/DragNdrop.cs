using UnityEngine;
using UnityEngine.Events;
public class DragNdrop : MonoBehaviour
{

    Vector3 diferencia;
    public UnityEvent onMouseDown, onMouseUp;

    public GameObject destacador;
    bool blockDrag;
    bool isDragging;
    bool blockComponent;

    private void Awake()
    {
        if(destacador)destacador.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (blockComponent) return;

        if (blockDrag) return;

        isDragging = true;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        diferencia = transform.position - worldPos;
        onMouseDown.Invoke();
    }

    private void OnMouseDrag()
    {
        if (blockComponent) return;

        if (blockDrag) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos + diferencia;
        
    }

    private void OnMouseUp()
    {
        if (blockComponent) return;

        isDragging = false;
        onMouseUp.Invoke();
    }


    public void BloquearDrag() => blockDrag = true;
    public void DesbloquearDrag() => blockDrag = false;
    public void BloquearComponente() => blockComponent = true;


    public void SwitchDestacador(bool state)
    {

         if(!isDragging) destacador.SetActive(state);
    }    
}
