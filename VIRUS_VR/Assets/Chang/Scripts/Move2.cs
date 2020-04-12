using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public int ran;
    public float radius =12f;
    public float speed = 1.5f;
    public Collider[] checkpoints;
   // int layerID = 8;
    int layerMask = 1 << 8;

   // private float timer =0.5f;
    
    void Start()
    {
        checkpoints = Physics.OverlapSphere(this.transform.position, radius, layerMask);
        ran = Random.Range(0, checkpoints.Length);
        Debug.Log(ran);
        StartCoroutine(NumberGen());
    }
    void Update()
    {
        checkpoints = Physics.OverlapSphere(this.transform.position, radius, layerMask);
        /* if (timer < 0)
         {
             ran = Random.Range(0, checkpoints.Length);
             Debug.Log("d");
             timer = 2f;
         }
         else if (timer <= 1)
         {
             timer -= Time.deltaTime;
         }*/
        if (ran > checkpoints.Length) {
            ran = Random.Range(0, checkpoints.Length);
        }
        if (checkpoints.Length >0) 
        { this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, checkpoints[ran].transform.position, speed * Time.deltaTime); }
         
        if (gameObject.transform.position == checkpoints[ran].transform.position) {
           ran = Random.Range(0, checkpoints.Length);
            //Debug.Log(ran);
          }
    }
    private void FixedUpdate()
    {
       
        
       /* foreach (var checkpoint in checkpoints) {
            if (this.gameObject.transform.position == checkpoint.transform.position) {
                ran = Random.Range(0, checkpoints.Length);
            }
        }*/

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    IEnumerator NumberGen()
    {
        while (true)
        {
            ran = Random.Range(0, checkpoints.Length);
            yield return new WaitForSeconds(5);
        }
    }
}
