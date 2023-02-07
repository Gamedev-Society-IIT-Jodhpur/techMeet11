using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_motion : MonoBehaviour
{
    float time = 2f;
    bool enabled = false;
    public bool impulse = false;
    public Transform player;
    bool first = false;
    // Start is called before the first frame update
    void Start()
    {

        time = Random.Range(0.5f,2);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        impulse = (Vector3.Distance(transform.position,player.position) < player.GetComponent<Repulsion>().radius);
        time = time -Time.deltaTime;
        if(time<0){
            time = 2f;
            enabled=!enabled;
            first = true;
        }
        if(enabled ){
            if(first){
        var rb = gameObject.GetComponent<Rigidbody2D>();
       var theta = Random.Range(0f,6.28f);
       rb.velocity = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta))*2;
       first = false;
            }
        }
        else{
            if(!impulse){
            var rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            
        }
    }

   

}
}
