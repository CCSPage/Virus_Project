using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float num = 3f;
    //private float speed = 1f;
    public GameObject [] checkPoint;
    public int randomNum;

    void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0f, 300), Random.Range(0f, 300), Random.Range(0f, 300));
        randomNum = Random.Range(0, checkPoint.Length);
        StartCoroutine(NumberGen());
    }

    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * speed; 
        num -= Time.deltaTime;
        if (num < 0)
        {
            //transform.rotation = Quaternion.Euler(Random.Range(0f, 300), Random.Range(0f, 300), Random.Range(0f, 300));
            num = 3f;
        }
       
        transform.position = Vector3.Lerp(gameObject.transform.position, checkPoint[randomNum].transform.position, 0.85f * Time.deltaTime);

        if (transform.position == checkPoint[randomNum].transform.position) {
            randomNum = Random.Range(0, checkPoint.Length);
        }
    }
    IEnumerator NumberGen()
    {
        while (true)
        {
            randomNum = Random.Range(0, checkPoint.Length);
            yield return new WaitForSeconds(3);
        }
    }
}
