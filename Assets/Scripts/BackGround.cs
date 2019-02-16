using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {
    private Animator _animator;
    public Transform Sun;
    public float edge;
    public bool itemget = false;
    Vector2 sunposition;
	// Use this for initialization
	void Start () {
        _animator = this.GetComponent<Animator>();
       
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 sunposition = Sun.transform.localPosition;
        if (sunposition.y > 0 && sunposition.x > edge&&sunposition.x<edge+0.04) _animator.SetTrigger("dton");
        if (sunposition.y < 0 && sunposition.x <-edge&&sunposition.x>-edge-0.04) _animator.SetTrigger("ntod");
        if (itemget&&sunposition.x>-edge&&sunposition.x<edge) {
            if (sunposition.y > 0) _animator.SetTrigger("ntod");
            if (sunposition.y < 0) _animator.SetTrigger("dton");
            itemget = false;
        }
    }
}
