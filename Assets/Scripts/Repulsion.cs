using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repulsion : MonoBehaviour
{
    GameObject[] persons;

    public float force = 10f;
    public float radius = 6f;
    public float cooldown = 10f, consfactor=5f,resfactor=1f;
    public AudioSource whistle_ads;
    public AudioClip whistel_ads1;


// Start is called before the first frame update
    public Image fill;
    

    void Start()
    {
        fill.fillAmount = 1;
    }

    void Update()
    {
        

        fill.fillAmount = cooldown/10f;
        if(fill.fillAmount>0.3f){
            fill.color = Color.cyan;
        }
        else{
            fill.color = Color.red;

        }
        if(Input.GetKeyDown(KeyCode.Space) && cooldown>3f){
            whistle_ads.Play();
        }
        if(Input.GetKeyUp(KeyCode.Space) || cooldown<=3f){
            whistle_ads.Stop();
        }
    
        if(Input.GetKey(KeyCode.Space) && cooldown > 0){

            cooldown-=Time.deltaTime*consfactor;
        persons = GameObject.FindGameObjectsWithTag("person");
        for(int i = 0; i < persons.Length; i++){
            if(Vector3.Distance(persons[i].transform.position,gameObject.transform.position)<=radius && cooldown>3f){
                Vector3 v=persons[i].transform.position-gameObject.transform.position;

                persons[i].GetComponent<Rigidbody2D>().AddForce( Vector3.Normalize(v)*force,ForceMode2D.Impulse);
            }
        }
        }
        else{
            // whistle_ads.Pause();
            if(cooldown>10)
            cooldown = 10f;
            else{
            cooldown += Time.deltaTime*resfactor;

            }

        }


    }
}




    



   
