using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update

    public float zoomScale = 10f;
    public float zoomMin = 0.1f;
    public float zoomMax = 10f;

    private Vector3 mousePosStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zoom(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetMouseButtonDown(1))
        {
            mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            pan();
        }
    }

    private void zoom(float zoomdif)
    {
        if (zoomdif != 0.0f)
        {
            Vector3 mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomdif * zoomScale, zoomMin, zoomMax);
            Vector3 mousePosDiff = mousePosStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mousePosDiff;


        }
    }

    private void pan()
    {
        if(Input.GetAxis("Mouse Y")!=0.0f||Input.GetAxis("Mouse X") != 0.0f)
        {
            Vector3 mousePosDiff = mousePosStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mousePosDiff;
        }
    }
}
