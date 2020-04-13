using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1: MonoBehaviour
{
    //SOURCE: https://www.youtube.com/watch?v=2tkNfsYlENs
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    Destroy(bc.gameObject);
                }
            }
        }
    }

}