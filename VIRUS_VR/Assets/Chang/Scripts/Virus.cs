using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public Transform armPos;
    private bool enter = false;
    private int score = 1;

    void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0f, 300), Random.Range(0f, 300), Random.Range(0f, 300));
         GameMananger.virusTotal += score;
         GameMananger.virusRemain += score;
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            gameObject.transform.position = armPos.position;
        }

        if (transform.parent != null) {
            this.gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, transform.parent.position,0.015f*Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
            GameMananger.virusRemain -= score;
            gameObject.transform.parent = null;
            
            Destroy(this.gameObject, 1f);
        }
    }
}
