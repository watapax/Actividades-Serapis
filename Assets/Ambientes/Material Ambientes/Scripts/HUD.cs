using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject InfoGameObject;
    public TextMeshProUGUI sceneTypeText;
    public TextMeshProUGUI sceneNametext;
    public Image image;
    public bool isShowing;

    //Singleton stuff
    public static HUD Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void ShowAnclaInfo()
    {
        //InfoGameObject.SetActive(true);
        InfoGameObject.GetComponent<Animator>().SetBool("IsShowing", true);
        //InfoGameObject.GetComponent<Animator>().Play("Show");
        isShowing = true;
    }

    public void HideAnclaInfo()
    {
        //InfoGameObject.SetActive(false);
        InfoGameObject.GetComponent<Animator>().SetBool("IsShowing", false);
        //InfoGameObject.GetComponent<Animator>().Play("Hide");
        isShowing = false;
    }

    public void SetAnclaInfo(string newType,string newName, Sprite newSprite)
    {
        sceneTypeText.SetText(newType);
        sceneNametext.SetText(newName);
        image.sprite = newSprite;

        if(newType == "ACTIVIDAD")
        {
            sceneNametext.color = new Color(1,0.950f,0.350f);
            //sceneNametext.color = new Color32(255,235,83);
        }
        else
        {
            sceneNametext.color = new Color(0.55f,0.85f,1f);
            //sceneNametext.color = new Color32(58,200,81);
        }
    }


}
