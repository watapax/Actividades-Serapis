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
        InfoGameObject.GetComponent<Animator>().SetTrigger("Show");
    }

    public void HideAnclaInfo()
    {
        //InfoGameObject.SetActive(false);
        InfoGameObject.GetComponent<Animator>().SetTrigger("Hide");
    }

    public void SetAnclaInfo(string newType,string newName, Sprite newSprite)
    {
        sceneTypeText.SetText(newType);
        sceneNametext.SetText(newName);
        image.sprite = newSprite;
    }


}
