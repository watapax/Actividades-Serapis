using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimeAnimation : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("offset", Random.Range(0.00f, 1.00f));
    }
}
