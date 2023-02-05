using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectHeight;
    private float objectWidth;
    Rigidbody2D body;
    
    
    

    
    float vertical;
    float horizontal;

    public float step = 10f;

    void Start()
    {
        
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        body=GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(horizontal, vertical).normalized;
        body.velocity = dir * step;
        
    }

    


    

   

}
