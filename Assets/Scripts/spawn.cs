using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject cubePrefab;
    public float radius=8f;
    public float inner_radius=7f;
    public float width,length;
    public GameObject player;
    public Vector3 p1,p2,p3,p4;

    void Update()
    {    
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnobject();
        }
    }
    void spawnobject(){
        // Vector2 randomSpawnPosition = Random.insideUnitCircle*radius;
        var ran = Random.Range(inner_radius, radius);
        Debug.Log(inner_radius);
        Debug.Log(radius);
        Debug.Log("Radius "+ran.ToString()+" radius");
        var theta = Random.Range(0,6.283f);
        GameObject cube_=Instantiate(cubePrefab, player.transform.position+new Vector3(ran*Mathf.Cos(theta),ran*Mathf.Sin(theta),0),Quaternion.identity);
        Debug.Log("Cos " + (ran*Mathf.Cos(theta)).ToString()+" Sin is"+(ran*Mathf.Sin(theta)).ToString());
        var rb = cube_.GetComponent<Rigidbody2D>();
        var t = Random.Range(0f,1f);
        p1=new Vector3(inner_radius,0f,0f)+player.transform.position-cube_.transform.position;
        p2=new Vector3(-inner_radius,0f,0f)+player.transform.position-cube_.transform.position;
        p3=new Vector3(0f,inner_radius,0f)+player.transform.position-cube_.transform.position;
        p4=new Vector3(0f,-inner_radius,0f)+player.transform.position-cube_.transform.position;

        var ran1 = Random.Range(inner_radius, radius);
        var theta1 = Random.Range(0,6.283f);
       
        var velx = player.transform.position+new Vector3(ran1*Mathf.Cos(theta1),ran*Mathf.Sin(theta1),0) - cube_.transform.position;
        var vec = new Vector2(velx.x,velx.y);
        vec.Normalize();
            rb.velocity = vec;
        
        
        // Debug.Log(select);
        // Debug.Log(vel.y);
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position,radius);
        // Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position,inner_radius);
    }
    



}