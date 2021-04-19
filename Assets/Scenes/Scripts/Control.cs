using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Camera cam;
    public GameObject orb1;
    public GameObject panel;
    public Text ending_text;
    public GameObject overlay_text;
    private int spawn_amt = 10;
    private float spawn_dist = 2f;
    private float spawn_range = 1f;
    private float r_low;
    private float r_high;
    private float b_low;
    private float b_high;
    private float g_low;
    private float g_high;
    private bool ended;
    private bool hint_active = false;
    private Vector3 mouse;
    public Text hint;
    // Start is called before the first frame update
    void Start()
    {
        //Color32 cam_color = new Color32((byte)Random.Range(r_low,r_high), (byte)Random.Range(g_low,g_high), (byte)Random.Range(b_low,b_high), (byte)255);
        //cam.clearFlags = CameraClearFlags.SolidColor;
        //cam.backgroundColor = cam_color;
        r_low = Random.Range(10,235);
        r_high = r_low + 40;
        b_low = Random.Range(10,235);
        b_high = r_low + 40;
        g_low = Random.Range(10,235);
        g_high = r_low + 40;

        Debug.Log(r_low + "-" + r_high);
        Debug.Log(g_low + "-" + g_high);
        Debug.Log(b_low + "-" + b_high);
        spawn_amt = Random.Range(15,30);
        PlayerPrefs.SetInt("ActiveOrbs", spawn_amt);
        for (int i = 0; i < spawn_amt; i++)
        {
            spawn_dist = Random.Range(-10,10);
            spawn_range = Random.Range(-10,10);
            Color32 obj_color = new Color32((byte)Random.Range(r_low,r_high), (byte)Random.Range(g_low,g_high), (byte)Random.Range(b_low,b_high), (byte)255);
            GameObject instance = Instantiate(orb1, new Vector3(spawn_dist, spawn_range, 0), Quaternion.identity) as GameObject;
            instance.GetComponent<SpriteRenderer>().color = obj_color;
            instance.transform.localScale *= Random.Range(1,3);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("ActiveOrbs") == 1 && !ended)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        overlay_text.SetActive(false);
        ended = true;
        panel.SetActive(true);
        GameObject last_obj = GameObject.FindGameObjectsWithTag("orb")[0];
        ending_text.color = new Color(last_obj.GetComponent<SpriteRenderer>().color.r, last_obj.GetComponent<SpriteRenderer>().color.g, last_obj.GetComponent<SpriteRenderer>().color.b);
        ending_text.text += "r" + (float)(last_obj.GetComponent<SpriteRenderer>().color.r * 255) + " g" + (float)(last_obj.GetComponent<SpriteRenderer>().color.g * 255) + " b" + (float)(last_obj.GetComponent<SpriteRenderer>().color.b * 255);
    }

    public void Reset(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Hint(){
        
        if (!ended && !hint_active)
        {
            mouse = Input.mousePosition;
            GameObject find = GameObject.FindGameObjectsWithTag("orb")[0];
            //cam.transform.position = find.transform.position;
            hint.text = "x:" + find.transform.localPosition.x + ", y:" + find.transform.localPosition.y;
        }
        else if (!ended && hint_active)
        {
            cam.transform.position = mouse;
        }

    }
}
