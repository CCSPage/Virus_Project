using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeranim : MonoBehaviour
{

    // Start is called before the first frame update
 bool reached = false; 
        public GameObject coll; 
    Animator anim;
 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		coll.GetComponent<Collider>(); 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("go");
			reached = true; 
			
        }
		
		if(Input.GetMouseButtonUp(0))
		{
			anim.SetTrigger("back"); 
			reached  = false; 
		}
		
		if(reached){
			coll.GetComponent<Collider>().enabled = true; 
		}
		else{
			coll.GetComponent<Collider>().enabled = false; 
    }
	}
	
	
	
}

  

