using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    

    //Este script se usa en los botones de "volver", llama al ManagerEscenas para que vuelva a la escena anterior.
    //Se conecta solo, para simplificar las cosas.

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonPressed);
    }

    public void OnButtonPressed()
    {
        button.interactable = false;
        //ManagerEscenas.Instance.CargarEscena(nombreEscenaDestino, "", IDAnclaDestino, "ZONA");
        ManagerEscenas.Instance.CargarUltimaEscena();
    }
}
