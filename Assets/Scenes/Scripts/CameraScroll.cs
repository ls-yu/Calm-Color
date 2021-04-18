using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScroll : MonoBehaviour
{
    float edge_size = 30f;
    float speed = 2f;
    float zoom_speed = 2f;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Input.mousePosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        txt.text = "x: " + loc.x + ", y: " + loc.y;
        if (Input.mousePosition.x >= Screen.width - edge_size)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if (Input.mousePosition.x <= 0 + edge_size)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if ( Input.mousePosition.y >= Screen.height - edge_size )
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if ( Input.mousePosition.y <= 0 + edge_size )
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                GetComponent<Camera>().fieldOfView += zoom_speed;
            }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                GetComponent<Camera>().fieldOfView -= zoom_speed;
            }
    }
}
