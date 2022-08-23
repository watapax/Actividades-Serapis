using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla : MonoBehaviour
{
    public UnityEvent m_MyEvent;

    public string anclaType;
    public string anclaName;
    public Sprite anclaThumbnail;

    private bool playerCanClick = false;


    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();
        //StartCoroutine(WaitAndEnableClick);
    }

     void Update()
    {
        if (playerCanClick && Input.GetMouseButtonDown(0) && m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HUD.Instance.ShowAnclaInfo();
        HUD.Instance.SetAnclaInfo(anclaType,anclaName, anclaThumbnail);
        StartCoroutine(WaitAndEnableClick(0.5f, true));
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
