using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public int ran;
    public Collider[] checkpoints;
   // int layerID = 8;
    int layerMask = 1 << 8;

    private float timer =0.5f;
    
    void Start()
    {
        checkpoints = Physics.OverlapSphere(this.transform.position, 15f, layerMask);
        ran = Random.Range(0, checkpoints.Length);
        Debug.Log(ran);
    }
    void Update()
    {
        if (timer < 0)
        {
            ran = Random.Range(0, checkpoints.Length);
            Debug.Log("d");
            timer = 2f;
        }
        else if (timer <= 1)
        {
            timer -= Time.deltaTime;
        }
        if (checkpoints.Length >0) { this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, checkpoints[ran].transform.position, 0.8f * Time.deltaTime); }
         if (gameObject.transform.position == checkpoints[ran].transform.position) {
           ran = Random.Range(0, checkpoints.Length);
          }
    }
    private void FixedUpdate()
    {
       
        checkpoints = Physics.OverlapSphere(this.transform.position, 15f, layerMask);
       /* foreach (var checkpoint in checkpoints) {
            if (this.gameObject.transform.position == checkpoint.transform.position) {
                ran = Random.Range(0, checkpoints.Length);
            }
        }*/

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 15f);
    }
}
