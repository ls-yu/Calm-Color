using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Camera cam;
    public GameObject orb1;
    private int spawnAmt = 10;
    private float spawnDist = 2f;
    private float spawnRange = 1f;
    private float r_low;
    private float r_high;
    private float b_low;
    private float b_high;
    private float g_low;
    private float g_high;

    // Start is called before the first frame update
    void Start()
    {
        Color32 cam_color = new Color32((byte)Random.Range(r_low,r_high), (byte)Random.Range(g_low,g_high), (byte)Random.Range(b_low,b_high), (byte)255);
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = cam_color;
        r_low = Random.Range(0,235);
        r_high = r_low + 20;
        b_low = Random.Range(0,235);
        b_high = r_low + 20;
        g_low = Random.Range(0,235);
        g_high = r_low + 20;

        Debug.Log(r_low + "-" + r_high);
        Debug.Log(g_low + "-" + g_high);
        Debug.Log(b_low + "-" + b_high);
        spawnAmt = Random.Range(8,15);
        for (int i = 0; i < spawnAmt; i++)
        {
            spawnDist = Random.Range(-5,5);
            spawnRange = Random.Range(-4,4);
            Color32 obj_color = new Color32((byte)Random.Range(r_low,r_high), (byte)Random.Range(g_low,g_high), (byte)Random.Range(b_low,b_high), (byte)255);
            GameObject instance = Instantiate(orb1, new Vector3(spawnDist, spawnRange, 0), Quaternion.identity) as GameObject;
            instance.GetComponent<SpriteRenderer>().color = obj_color;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
