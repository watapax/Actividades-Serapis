using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ManagerEscenas : MonoBehaviour
{
    public string nombreSiguienteEscena;
    public Vector3 posicionRetorno;
    public string ultimaEscena;
    public UnityEvent onLoadScene;
    float waitTime;

    public static ManagerEscenas Instance { get; private set; }

    void Awake()
    {
        //Se borra a si mismo si hay otro activo
        if (Instance != null && Instance != this) 
        { 
            Debug.Log("Existing manager found, deleting self...");
            Destroy(this.gameObject); 
        } 
        else 
        { 
            Debug.Log("No manager found, setting self as new manager...");
            Instance = this; 
        } 

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Cursor.visible = true;
        waitTime = GetComponent<ManagerTransicionCanvas>().duracionFade +1;
        SceneManager.sceneLoaded += TerminarCarga;
    }

    public void CargarEscena(string nombreEscena, Vector3 posicion)
    {
        ultimaEscena = SceneManager.GetActiveScene().name;
        posicionRetorno = posicion;
        nombreSiguienteEscena = nombreEscena;
        onLoadScene.Invoke();
        Invoke("Cargar", waitTime);
    }

    public void CargarUltimaEscena()
    {
        CargarEscena(ultimaEscena, posicionRetorno);
    }

    void Cargar()
    {   
        SceneManager.LoadScene(nombreSiguienteEscena);
    }

    void TerminarCarga(Scene scene, LoadSceneMode mode)
    {
        GetComponent<ManagerTransicionCanvas>().FadeOutBlanco();
        Cursor.lockState = CursorLockMode.None; //Mas adelante se podria cambiar en base a si es una "actividad" o una "zona"


        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Debug.Log("Setting player pos");
            player.transform.position = posicionRetorno;

        }
    }
}
