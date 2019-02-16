using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Playerb : MonoBehaviour {
    private Animator _animator;
    public float speedCircle = 03f;
    public float jumpForce = 100f;
    public float speedCube = 04f;
    public static bool round = false;
    public Transform Sun;
    private bool onGround = false;
    private bool coll;
    CircleCollider2D circle;
    BoxCollider2D box;
    Rigidbody2D rg;
    AudioSource au;
    Sun sun;
    public GameObject hourglass;
    public GameObject light_red;
    public GameObject green;
    public float mute = 0.05f;
    public GameObject win;
    public bool item=false;
    public bool timeenable=false;
    public float delaytime=5f;
    public float delaytime1 = 1f;
    public float diedelaytime = 0.7f;
    //public bool sunchange=false;


	// Use this for initialization
	void Start () {
        light_red.SetActive(false);
        _animator = this.GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        au = GetComponent<AudioSource>();
        circle.enabled = false;
        box.enabled = true;
        green.SetActive(false);
        win.SetActive(false);
        sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>();
        hourglass.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (item) {
            item = false;
            timeenable = true;
            StartCoroutine(TimeDelay());  }
        //judge round
        bool beforeround = round;
        float height = rg.transform.localPosition.y;
        Vector2 sunposition = Sun.transform.localPosition;//unknown
        if (sunposition.y * height > 0) round = false;
        else round = true;
        //judge transform
        if (beforeround != round && round == true) {
            circle.enabled = true;
            box.enabled = false;
            _animator.SetTrigger("btoc");
        }

        if (beforeround != round && round == false) {
            circle.enabled = false;
            box.enabled = true;
            _animator.SetTrigger("ctob");
        }
        //judge gravition
        if (height > 0) rg.gravityScale = 1;
        else rg.gravityScale = -1;
        if (Input.GetKeyDown(KeyCode.DownArrow) && timeenable == true) {
            timeenable = false;
            hourglass.SetActive(true);
            StartCoroutine(ItemDelay()); }

        //circle move
        if (round) {
            if (Input.GetKey(KeyCode.LeftArrow)) rg.velocity = new Vector2(-speedCircle, rg.velocity.y);
            if (Input.GetKey(KeyCode.RightArrow)) rg.velocity = new Vector2(speedCircle, rg.velocity.y);
            if (Input.GetKeyDown(KeyCode.UpArrow)&& onGround == true) {
                if (height > 0) rg.AddForce(Vector2.up * jumpForce);
                else rg.AddForce(Vector2.down * jumpForce);
            }
            
            if (coll == true) {
                _animator.SetTrigger("cdie");
                
                green.SetActive(true);
                win.SetActive(true);
                StartCoroutine(DieDelay());
                //Time.timeScale = 0;
                //SceneManager.LoadScene("PlayerAwin"); 
            }
           
        }
        //box move
        if (!round) {
            if (Input.GetKey(KeyCode.LeftArrow)) rg.velocity = new Vector2(-speedCircle, rg.velocity.y);
            if (Input.GetKey(KeyCode.RightArrow)) rg.velocity = new Vector2(speedCircle, rg.velocity.y);
        }
        Debug.Log("timeenable"+timeenable);
        if (timeenable) light_red.SetActive(true);
        if (!timeenable) light_red.SetActive(false);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Playera") 
            if(rg.transform.localPosition.y > mute||rg.transform.localPosition.y<-mute)
            coll = true;
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            au.Play();
        }
        if (collision.gameObject.tag == "item_Change") item = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") onGround = false;
    }
    IEnumerator TimeDelay() {
        yield return new WaitForSeconds(delaytime);
        timeenable = false;
    }
    IEnumerator ItemDelay()
    {
        yield return new WaitForSeconds(delaytime1);
        sun.flag = true;
        hourglass.SetActive(false);
    }
    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(diedelaytime);
        Time.timeScale = 0;
    }
}
