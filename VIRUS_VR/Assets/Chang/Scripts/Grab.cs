using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private Animator ani;
    public GameObject hand;
    private Collider handPosCol;
    public bool handIsStretching = false;
   // public Hand handScript;    
    
    private State state;
    private enum State {
        Normal,
        Shoot,
        Grab
    }

    private void Awake()
    {
        state = State.Normal;
    }
    
    void Start()
    {
        ani = GetComponent<Animator>();
        handPosCol = hand.GetComponent<Collider>();
    }


    void Update()
    {

        if (Input.GetMouseButton(0) && GameMananger.gameOver == false)
        {
            ani.SetBool("shoot", true);
            Hand.grabBool = false;
           
        }
        else if (Hand.grabBool)
        {
            ani.SetBool("shoot", false);
            //ani.SetTrigger("eating");
            state = State.Grab;
           // Hand.grabBool = false;
            Debug.Log("vi");
        }
        else 
        {
            ani.SetBool("shoot", false);
         // handIsStretching = false;
        }
        if (handIsStretching ) {
            state = State.Shoot;
        }
        if (!handIsStretching||Hand.grabBool) {
            state = State.Normal;
        }
      
      
        
        switch (state)
        {
            default:
            case State.Normal:
                Normal();
                break;
            case State.Shoot:
                Shoot();
                break;
            case State.Grab:
                GrabSomething();
                break;
        }
    }
/*
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Virus") {
            ani.SetBool("shoot", false);
            
            
        }
    }
    */
    private void Normal()
    {
        handPosCol.enabled = false;
    }
    private void Shoot() {
        handPosCol.enabled = true;
    }
    private void GrabSomething() {
        handPosCol.enabled = false;
    }
 
}
