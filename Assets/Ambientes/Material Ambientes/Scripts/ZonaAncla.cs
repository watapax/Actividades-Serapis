using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ZonaAncla : MonoBehaviour
{


    public string anclaType;
    public string anclaName;
    public Sprite anclaThumbnail;


    private void OnTriggerEnter(Collider other)
    {
        HUD.Instance.ShowAnclaInfo();
        HUD.Instance.SetAnclaInfo(anclaType,anclaName, anclaThumbnail);
    }

    private void OnTriggerExit(Collider other)
    {
        HUD.Instance.HideAnclaInfo();
    }

       
}
