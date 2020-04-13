using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    static public bool grabBool = false;
    private Collider col;
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (grabBool) {
            col.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Virus")
        {
            grabBool = true;
            col.enabled = false;
            Debug.Log("FF");
        }
        else 
        {
            grabBool = false;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        grabBool = false;
        Debug.Log("FF");
    }
}
