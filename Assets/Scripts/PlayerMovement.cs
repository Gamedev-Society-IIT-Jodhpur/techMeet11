using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectHeight;
    private float objectWidth;
    public Rigidbody2D body;

    public GameObject patientZero;

    float vertical;
    float horizontal;
    public float health = 100f,healthfactor=1f;
    public float step = 10f;

    public Image fill;
    

    void Start()
    {
        fill.fillAmount = 1;
    }

    void Update()
    {
        

        fill.fillAmount = health/100f;
        


   
        if(Vector3.Distance(transform.position, patientZero.transform.position)<patientZero.GetComponent<PatientScript>().RADIUS){
            health-= Time.deltaTime * healthfactor;
        }
        
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(horizontal, vertical).normalized;
        body.velocity = dir * step;
        
    }
}
