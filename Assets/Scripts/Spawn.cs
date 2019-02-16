using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public float colddown=20f;
    public GameObject item_Change;

    float nextSpawn=0;

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + colddown;
            Vector3 spawnP = transform.position;
            spawnP.x += Random.Range(-14f, 14f);
            spawnP.y += Random.Range(1,2)==1?0:-24;
            Instantiate(item_Change, spawnP, transform.rotation);


        }
	}
}
