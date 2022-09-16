using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiadorEscenas : MonoBehaviour
{
    
    //Este script llama al ManagerEscenas para que vaya a la escena.
    //Se conecta automaticante si es que hay un boton, para simplificar las cosas.
    //Alternativamente se puede llamar la funcion CambiarDeEscena desde un evento u otro script.

    public string nombreEscenaDestino;
    public string IDAnclaDestino;

    Button button;

    private void Start()
    {
        if(GetComponent<Button>() != null)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonPressed);
        }
    }

    public void OnButtonPressed()
    {
        button.interactable = false;
        CambiarDeEscena();
    }

    public void CambiarDeEscena()
    {
        ManagerEscenas.Instance.CargarEscena(nombreEscenaDestino, "", IDAnclaDestino, "ZONA");
    }
}
