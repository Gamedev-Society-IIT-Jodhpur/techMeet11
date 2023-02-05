using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectHeight;
    

    
    float vertical;

    public float step = 0.1f;

    void Start()
    {
        
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }


    // Update is called once per frame
    void Update()
    {
        
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 temp_Pos = transform.position;
        //temp_Pos.y = Mathf.Clamp(temp_Pos.y + vertical * step, screenBounds.y - objectHeight, screenBounds.y * -1 + objectHeight);
        temp_Pos.y=temp_Pos.y+vertical * step;
        if(temp_Pos.y<screenBounds.y-objectHeight && temp_Pos.y > (-1)*screenBounds.y+objectHeight)
        {
            transform.position = temp_Pos;
        }
        
    }

    


    

   

}
