using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla : MonoBehaviour
{
    public enum AnclaTypes {ZONA, ACTIVIDAD};
    public AnclaTypes anclaType;
    public string anclaSceneName;
    public string anclaName;
    public Sprite anclaThumbnail;

    private bool playerCanClick = false;
    private bool isEnteringWorld = false;
    private Transform returnPosHelper;

    private void Start()
    {
        returnPosHelper = transform.Find("ReturnPosHelper");
    }

    void Update()
    {
        if (playerCanClick && !isEnteringWorld && Input.GetMouseButtonDown(0))
        {
            //m_MyEvent.Invoke();
            ManagerEscenas.Instance.CargarEscena(anclaSceneName, returnPosHelper.position);
            playerCanClick = false;
            isEnteringWorld = true;
            HUD.Instance.HideAnclaInfo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HUD.Instance.ShowAnclaInfo();
        HUD.Instance.SetAnclaInfo(anclaType.ToString(),anclaName, anclaThumbnail);
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
