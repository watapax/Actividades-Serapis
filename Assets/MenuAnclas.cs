using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnclas:MonoBehaviour
{
    public GameObject menu;
    public GraphicRaycaster graphicRaycaster;

    bool is_open = false;
    float key_press_time = 0;

    CursorLockMode prevMouseLockMode;
    bool prevMouseVisibleState;

    // Update is called once per frame
    void Update()
    {
        if (!is_open)
        {
            if (Input.GetKey(KeyCode.F10))
            {
                key_press_time += Time.deltaTime;
                if (key_press_time > 1.0)
                {
                    is_open = true;
                    menu.SetActive(true);
                    graphicRaycaster.enabled = true;

                    prevMouseLockMode = Cursor.lockState;
                    prevMouseVisibleState = Cursor.visible;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    
                }
            }
            else if(Input.GetKeyUp(KeyCode.F10))
            {
                key_press_time = 0;
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                key_press_time = 0;
                is_open = false;
                menu.SetActive(false);
                graphicRaycaster.enabled = false;

                Cursor.lockState = prevMouseLockMode;
                Cursor.visible = prevMouseVisibleState;
            }
        }

    }
}
