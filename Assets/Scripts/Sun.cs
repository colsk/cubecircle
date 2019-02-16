using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    public float speed = 02f;
    public float sunx = 12f;
    public float suny = 05f;
    public bool flag = false;
    //AudioSource au;
    BackGround Itemget;
    // Use this for initialization
    void Start () {
        //item = GameObject.FindGameObjectWithTag("item_Change").GetComponent<item_Change>();
        Itemget = GameObject.FindGameObjectWithTag("Background").GetComponent<BackGround>();
        //au = GetComponent<AudioSource>();
        //playera = GameObject.FindGameObjectWithTag("Playera").GetComponent<Playera>();
        //playerb = GameObject.FindGameObjectWithTag("Playerb").GetComponent<Playerb>();


    }
	
	// Update is called once per frame
	void Update () {
        //exchange = item.change;
        Vector2 sunPosition = transform.localPosition;
        if (sunPosition.y>0) transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (sunPosition.y<0) transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (sunPosition.x > sunx ) transform.position = new Vector2(sunx,-suny);
        if (sunPosition.x < -sunx) transform.position = new Vector2(-sunx, suny);

        if (flag) {
            transform.position = new Vector2(-sunPosition.x,-sunPosition.y);
            //Itemget.itemget = true;
            //au.Play();
            flag = false;
            Itemget.itemget = true;
        }
    }

    //script
}
