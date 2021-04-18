using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbScript : MonoBehaviour
{
    public GameObject orb1;
    private bool selected = false;
    public float red;
    public float green;
    public float blue;
    public Text txt;
    public AudioClip[] sounds;
    public AudioSource source;
    //public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0,5);
        source.clip = sounds[i];
        //Debug.Log(source.clip.name);
        source.Play();
        GameObject canvas_obj = GameObject.Find("SelectedColor");
        txt = canvas_obj.GetComponent<Text>();
        red = (float)GetComponent<SpriteRenderer>().color.r * 255;
        green = (float)GetComponent<SpriteRenderer>().color.g * 255;
        blue = (float)GetComponent<SpriteRenderer>().color.b * 255;
        //s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected){
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
        }
        
    }

    public float getRed(){
        return red;
    }

    public float getBlue(){
        return blue;
    }

    public float getGreen(){
        return green;
    }

    public void OnMouseOver(){
        if(!selected && Input.GetMouseButtonDown(0)){
            selected = true;
            txt.text = "r" + red + " g" + green + " b" + blue;
        }
        else if (selected && Input.GetMouseButtonDown(0)){
            selected = false;
        }
    }

    void OnTriggerStay2D(Collider2D coll){
        if (selected)
        {
            GetComponent<AudioSource>().Play();
            GameObject other = coll.gameObject;
            float new_red = (red + (float)other.GetComponent<SpriteRenderer>().color.r * 255)/2;
            float new_green = (green + (float)other.GetComponent<SpriteRenderer>().color.g * 255)/2;
            float new_blue = (blue + (float)other.GetComponent<SpriteRenderer>().color.b * 255)/2;
            Color32 obj_color = new Color32((byte)new_red, (byte)new_green, (byte)new_blue, (byte)255);
            GameObject instance = Instantiate(orb1, transform.position, Quaternion.identity) as GameObject;
            instance.GetComponent<SpriteRenderer>().color = obj_color;
            instance.transform.localScale = (other.transform.localScale + gameObject.transform.localScale)/1.5f;
            Destroy(other);
            Destroy(gameObject);
            selected = false;
            PlayerPrefs.SetInt("ActiveOrbs", PlayerPrefs.GetInt("ActiveOrbs")-1);
        }
            
    }
}
