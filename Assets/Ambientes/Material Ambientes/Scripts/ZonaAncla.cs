using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla:MonoBehaviour
{
    public enum AnclaTypes { ZONA, ACTIVIDAD };
    public AnclaTypes tipoAncla;
    public string IDAncla;
    public string IDAnclaDestino;
    public string nombreEscena;
    //public float distanciaActivacion;
    public Outline AnclaMeshOutline;


    [Header("Informacion UI")]
    public string nombreAncla;
    public Sprite previewAncla;

    private bool playerCanClick = false;
    private bool isEnteringWorld = false;

    [HideInInspector] public Transform returnPosHelper;

    private GameObject player;


    private void Awake()
    {
        returnPosHelper = transform.Find("ReturnPosHelper");
        
    }

    private void Start()
    {
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = false;
        }
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

        
        /* //This part of the script allows for a different way of detecting the player
        //If player is in Ancla zone, calculate distance
        if (player != null)
        {

            //If player is within set distance, show HUD info
            if (Vector3.Distance(player.transform.position, transform.position) < distanciaActivacion)
            {
                if (!HUD.Instance.isShowing)
                {
                    HUD.Instance.ShowAnclaInfo();
                    HUD.Instance.SetAnclaInfo(tipoAncla.ToString(), nombreAncla, previewAncla);
                    StartCoroutine(WaitAndEnableClick(0.6f, true)); //Waits for animation to end before enabling teleport
                }

            } else
            {
                if (HUD.Instance.isShowing)
                {
                    HUD.Instance.HideAnclaInfo();
                    playerCanClick = false;
                }

            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = true;
        }
        player = other.gameObject;
        HUD.Instance.ShowAnclaInfo();
        HUD.Instance.SetAnclaInfo(tipoAncla.ToString(), nombreAncla, previewAncla);
        StartCoroutine(WaitAndEnableClick(0.6f, true)); //Waits for animation to end before enabling teleport
    }

    private void OnTriggerExit(Collider other)
    {
        if (AnclaMeshOutline != null)
        {
            AnclaMeshOutline.enabled = false;
        }

        player = null;
        HUD.Instance.HideAnclaInfo();
        playerCanClick = false;
    }

    private IEnumerator WaitAndEnableClick(float waitTime, bool newValue)
    {
        yield return new WaitForSeconds(waitTime);

        if (player != null)
        {
            playerCanClick = newValue;
        }
        
    }

    /*
    void OnDrawGizmosSelected()
    {
        // Draw a sphere to show activation distance
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaActivacion);
    }*/
}
