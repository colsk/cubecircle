using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Strong : MonoBehaviour {
    Rigidbody2D rg;
    public float time = 8.0f;
	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,time);
	}
	
	// Update is called once per frame
	void Update () {
        float height = rg.transform.localPosition.y;
        if (height > 0) rg.gravityScale = 0.5f;
        else rg.gravityScale = -0.5f;

	}
}
