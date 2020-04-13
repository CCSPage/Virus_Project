using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatt : MonoBehaviour
{
	 private float speed = 50f; 
	 private Vector3 direction;
 void Start() 
     {
         direction = (new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f),0.0f)).normalized;
        transform.Rotate(direction);
     }
     
     void Update()
     {
         Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
         GetComponent<Rigidbody>().MovePosition (newPos);
     }
     
     void OnCollisionEnter (Collision col)
     {
         Debug.Log ("Collision");
         if (col.gameObject.tag == "wall")   
         {
             direction = col.contacts[0].normal;
             direction = Quaternion.AngleAxis(Random.Range(-70.0f, 70.0f), Vector3.forward) * direction;
             transform.rotation = Quaternion.LookRotation(direction);
         }
     }
 }