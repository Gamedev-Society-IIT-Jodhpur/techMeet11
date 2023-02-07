using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameObject patientZero;
    public bool maskfill = false;
    float masktime = 5f;
    public Image maskImg;

IEnumerator MaskRemover(GameObject player,Vector3 scale,GameObject circle){
    // var RADIUS = patientZero.GetComponent<PatientScript>().RADIUS;
patientZero.GetComponent<PatientScript>().RADIUS = 0f;
    yield return new WaitForSeconds(5f);
    maskfill = false;
    player.transform.GetChild(1).gameObject.SetActive(false);
    var pen = patientZero.GetComponent<PatientScript>().penalty;
    circle.transform.localScale = new Vector3(6.9f*(1+pen*0.007f),6.9f*(1+pen*0.007f),0f);
        patientZero.GetComponent<PatientScript>().RADIUS = 2f*(1+pen*0.007f);




}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Mask"){
            maskfill = true;
             var circle = GameObject.FindGameObjectWithTag("INFLUENCE");
             Vector3 SCALE = circle.transform.localScale;
        circle.transform.localScale = new Vector3(0f,0f,0f);
        // RADIUS = RADIUS*(1+penalty*0.007f);
            var list = GameObject.FindGameObjectsWithTag("Infected");
            foreach(var i in list){
                i.transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine(MaskRemover(i,SCALE,circle));
                
            }

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Ladoo"){
            if(gameObject.GetComponent<PlayerMovement>().health+10f>=100){
                gameObject.GetComponent<PlayerMovement>().health=100f;
            }
            else{gameObject.GetComponent<PlayerMovement>().health+=10f;}
             
             

            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maskfill){
            maskImg.enabled = true;
            masktime-=Time.deltaTime;
            maskImg.fillAmount = masktime/5.0f;
        }
        else{
            maskImg.enabled = false;
            masktime=5f;
        }
        if(masktime<0){
            masktime=0;
        }



        
    }
}
