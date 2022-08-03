using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRef : MonoBehaviour
{
    public Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, cam.rotation.eulerAngles.y, 0);
    }
}
