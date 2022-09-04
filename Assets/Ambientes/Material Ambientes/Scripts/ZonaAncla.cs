using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla : MonoBehaviour
{
    public enum AnclaTypes {ZONA, ACTIVIDAD};
    public AnclaTypes tipoAncla;
    public string IDAncla;
    public string IDAnclaDestino;
    public string nombreEscena;

    [Header("Informacion UI")]
    public string nombreAncla;
    public Sprite previewAncla;

    private bool playerCanClick = false;
    private bool isEnteringWorld = false;
    
    [HideInInspector] public Transform returnPosHelper;

    private void Awake()
    {
        returnPosHelper = transform.Find("ReturnPosHelper");
    }

    void Update()
    {
        if (playerCanClick && !isEnteringWorld && Input.GetMouseButtonDown(0))
        {
            ManagerEscenas.Instance.CargarEscena(nombreEscena, IDAncla, IDAnclaDestino, tipoAncla.ToString());
            playerCanClick = false;
            isEnteringWorld = true;
            HUD.Instance.HideAnclaInfo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HUD.Instance.ShowAnclaInfo();
        HUD.Instance.SetAnclaInfo(tipoAncla.ToString(),nombreAncla, previewAncla);
        StartCoroutine(WaitAndEnableClick(0.6f, true));
    }

    private void OnTriggerExit(Collider other)
    {
        HUD.Instance.HideAnclaInfo();
        StartCoroutine(WaitAndEnableClick(0.01f,false));
    }

    private IEnumerator WaitAndEnableClick(float waitTime, bool newValue)
    {
        yield return new WaitForSeconds(waitTime);
        playerCanClick = newValue;

    }
       
}
