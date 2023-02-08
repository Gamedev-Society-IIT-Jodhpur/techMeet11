using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientScript : MonoBehaviour
{
    private int state = -1;
    
    public float velocity_x = 1f;
    public float velocity_y = 1f;
    public float velocity_random = 1f;
    private float time = 1f;
    public float RADIUS = 2f;
    public int penalty = 0;
    public GameObject gameOverScreen;
    public AudioSource bgm;

    public void GameOver()
    {
        bgm.Stop();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // CIRCLE OF INFLUENCE

        if(state == -1 && this.gameObject.transform.position.x >= -69) 
        {
            state = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, 0f);
        }
        if(state == 0 && this.gameObject.transform.position.x >= -10) 
        {
            state = 1;        
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocity_y);
        }
        if(state == 1 && this.gameObject.transform.position.y <= -60) 
        {
            state = 2;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, 0f);
        }
        if(state == 2 && this.gameObject.transform.position.x >= 51) 
        {
            state = 3;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocity_y);
        }
        if(state == 3 && this.gameObject.transform.position.y >= -27) 
        {
            state = 4;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, 0f);
        }
        if(state == 4 && this.gameObject.transform.position.x >= 104) 
        {
            state = 5;
            //end;
        }

        if(state == 0)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, Random.Range(-velocity_random, velocity_random));
                time = 1f;
            }
        }
        if(state == 1)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-velocity_random, velocity_random) ,-velocity_y);
                time = 1f;
            }
        }
        if(state == 2)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, Random.Range(-velocity_random, velocity_random));
                time = 1f;
            }
        }
        if(state == 3)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-velocity_random, velocity_random) ,velocity_y);
                time = 1f;
            }
        }
        if(state == 4)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity_x, Random.Range(-velocity_random, velocity_random));
                time = 1f;
            }
        }



        GameObject[] persons = GameObject.FindGameObjectsWithTag("person");
        foreach (GameObject person in persons)
        {
            if(Vector3.Distance(person.transform.position, this.transform.position) <= RADIUS && person.gameObject.tag == "person")
            {
                penalty++;
                var openpos=penalty;
                for (int i = 1; i <= penalty; i++){
                    if(gameObject.transform.GetChild(i+5).childCount==0){
                        openpos = i;
                        break;
                    }
                }
                person.gameObject.tag = "Infected";
                person.transform.SetParent(this.gameObject.transform.GetChild(openpos + 5));
                person.GetComponent<Rigidbody2D>().isKinematic = true;
                person.transform.localPosition = Vector3.zero;
                person.GetComponent<npc_motion>().enabled =false;
                // person.GetComponent<PatientScript>().enabled =false;
                person.transform.GetChild(0).transform.gameObject.SetActive(true);
                
                var circle = GameObject.FindGameObjectWithTag("INFLUENCE");
        circle.transform.localScale = new Vector3(6.9f*(1+penalty*0.007f),6.9f*(1+penalty*0.007f),0f);
        RADIUS = RADIUS*(1+penalty*0.007f);
            }
        }

        if (penalty >= 14)
        {
            GameOver();
        }

    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position,RADIUS);
    }
}
