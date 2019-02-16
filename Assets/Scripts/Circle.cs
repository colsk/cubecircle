using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {
    public float speedCircle = 03f;
    public float jumpForce = 100f;
    public float speedCube = 04f;
    public static bool round = true;
    private bool coll=false;
    public Transform Sun;
    private bool onGround;
    Rigidbody2D rg;
	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        bool beforeround = round;
        float height = rg.transform.localPosition.y;
        Vector2 sunPosition = Sun.transform.localPosition;
        if (sunPosition.y * height > 0) round = true;
        else round = false;
        if (beforeround != round && round == true) Debug.Log("changetocube");
        if (beforeround != round && round == false) Debug.Log("changetoround");
        if (height > 0) rg.gravityScale = 1;
        else rg.gravityScale = -1;

        if (round) {
            if (Input.GetKey(KeyCode.A)) {
                rg.velocity = new Vector2(-speedCircle, rg.velocity.y);

            }
            if (Input.GetKey(KeyCode.D)) {
                rg.velocity = new Vector2(speedCircle, rg.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.W)&&onGround==true) {
                if (height > 0) rg.AddForce(Vector2.up * jumpForce);
                else rg.AddForce(Vector2.down * jumpForce);
                
            }
            if (coll == true) Debug.Log("lose");

        }
        if (!round) {
            if (Input.GetKey(KeyCode.A))
            {
                rg.velocity = new Vector2(-speedCube, rg.velocity.y);

            }
            if (Input.GetKey(KeyCode.D))
            {
                rg.velocity = new Vector2(speedCube, rg.velocity.y);
            }
            if (coll == true) Debug.Log("win");


        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2") coll = true;
        if (collision.gameObject.tag == "Ground") onGround = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") onGround = false;
    }

}
 


// Player
// circlr 
// box


    // get componet 

    // circle.enabled = trure;
    // box.enabled = false;