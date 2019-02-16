using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {
    public Transform Sun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 sunPosition = Sun.transform.localPosition;
        transform.position = new Vector2(-sunPosition.x, -sunPosition.y);
	}
}
