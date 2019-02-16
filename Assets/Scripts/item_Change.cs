using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Change : MonoBehaviour
{
    Rigidbody2D rg;
    public float time = 8.0f;
    public bool change = false;
    //Sun exchange;

    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, time);
        // exchange = GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>();
    }

    // Update is called once per frame
    void Update()
    {
        float height = rg.transform.localPosition.y;
        if (height > 0) rg.gravityScale = 0.5f;
        else rg.gravityScale = -0.5f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Playera" || collision.gameObject.tag == "Playerb")
        {
            //  change = true;
            //exchange.flag = true;
            //Debug.Log(change);

            Destroy(this.gameObject);
        }
    }
}

