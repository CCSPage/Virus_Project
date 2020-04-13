using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeranim2 : MonoBehaviour
{
    Animator anim;
 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("go2");
        }
    }
    }