using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusToHand : MonoBehaviour
{
	public Transform armPos;
    private bool enter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (enter)
        {
            gameObject.transform.position = armPos.position;
        }

        
        
    }
	
	 void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
            Debug.Log("dfsd");
            gameObject.transform.parent = null;
            
            Destroy(this.gameObject, 1f);
        }
    }
}
