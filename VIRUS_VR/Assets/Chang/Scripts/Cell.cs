using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private float speed = 1.6f;
    private bool enter = false;
    public Transform armPos;
    
    void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0f, 360), Random.Range(0f, 360), Random.Range(0f, 360));
    }


    void Update()
    {
        //transform.rotation = Random.rotation;
        //transform.Rotate(new Vector3(0, 0, Random.Range(0f, 300f)) * Time.deltaTime * speed);

        if (enter)
        {
            gameObject.transform.position = armPos.position;
        }
        else 
        {
            transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)) * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            enter = true;
            gameObject.transform.parent = null;
            Destroy(this.gameObject, 1f);

        }
    }
}
