using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion : MonoBehaviour
{
    GameObject[] persons;

    public float force = 10f;
    public float radius = 6f;

    void Start()
    {
        
    }

    void Update()
    {
        persons = GameObject.FindGameObjectsWithTag("person");
        for(int i = 0; i < persons.Length; i++){
            if(Vector3.Distance(persons[i].transform.position,gameObject.transform.position)<=radius){
                Vector3 v=persons[i].transform.position-gameObject.transform.position;

                persons[i].GetComponent<Rigidbody2D>().AddForce( Vector3.Normalize(v)*force,ForceMode2D.Impulse);
            }
        }


    }
}