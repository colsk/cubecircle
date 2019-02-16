using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Playera : MonoBehaviour {
    private Animator _animator;
    public float speedCircle = 03f;
    public float jumpForce = 100f;
    public float speedCube = 04f;
    public static bool round = true;
    private bool coll=false;
    public Transform Sun;
    private bool onGround;
    public float mute = 0.05f;
    public float delaytime1 = 1f;
    //public bool item_Change = false;
    //public bool item_Strong = false;
    //public bool bdie = false;
    //public bool cdie = false;
    //public bool btoc = false;
    //public bool ctob = false;
    //public bool item_weak = false;
    //public bool strong = false;
    //public float time = 07f;
    public GameObject red;
    CircleCollider2D circle;
    BoxCollider2D box;
    Rigidbody2D rg;
    AudioSource au;
    Sun sun;
    public GameObject hourglass;
    public GameObject win;
    public GameObject light_green;
    public bool item = false;
    public bool timeenable = false;
    public float delaytime = 5f;
    public bool sunchange = false;
    public float diedelaytime = 0.7f;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        _animator = this.GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        au = GetComponent<AudioSource>();
        circle.enabled = true;
        box.enabled = false;
        red.SetActive(false);
        win.SetActive(false);
        light_green.SetActive(false);
        sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>();
        hourglass.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (item)
        {
            item = false;
            timeenable = true;
            StartCoroutine(TimeDelay());
        }
        bool beforeround = round;
        float height = rg.transform.localPosition.y;
        Vector2 sunPosition = Sun.transform.localPosition;
        if (sunPosition.y * height > 0) round = true;
        else round = false;
        //if (!item_Strong)
        //{
            if (beforeround != round && round == true)
            {
                circle.enabled = true;
                box.enabled = false;
                _animator.SetTrigger("btoc");
                //Debug.Log("btoc");
            }
            if (beforeround != round && round == false)
            {
                circle.enabled = false;
                box.enabled = true;
              //  btoc = true;
                _animator.SetTrigger("ctob");
                //Debug.Log("ctob");
            }
        //}
        /*if (item_Strong) {
            time -= Time.deltaTime;
            if (time <= 0f) {
                strong = false;
                item_weak = true;

            }
        }*/

        if (height > 0) rg.gravityScale = 1;
        else rg.gravityScale = -1;

        if (Input.GetKeyDown(KeyCode.Space) && timeenable == true){
            timeenable = false;
            hourglass.SetActive(true);
            StartCoroutine(ItemDelay());
        }
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
            if (coll == true) {
                _animator.SetTrigger("cdie");
                red.SetActive(true);
                win.SetActive(true);
                StartCoroutine(DieDelay());
                //Time.timeScale = 0;
                //SceneManager.LoadScene("PlayerBwin");

            }

            //if (coll == true&&strong==false) cdie=true;//animation cdie
            
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
            


        }
        //if (bdie) _animator.SetTrigger("bdie");
        //if (cdie) _animator.SetTrigger("cdie");
        //if (item_Strong) _animator.SetTrigger("thorn");
        //if (item_Strong) Debug.Log("change");
        if (timeenable) light_green.SetActive(true);
        if (!timeenable) light_green.SetActive(false);
        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Playerb")
            if (rg.transform.localPosition.y > mute || rg.transform.localPosition.y < -mute)
                coll = true; 
        if (collision.gameObject.tag == "Ground") {
            onGround = true;
            au.Play();

        }
        if (collision.gameObject.tag == "item_Change") item = true;
        //if (collision.gameObject.tag == "item_Strong") { item_Strong = true; strong = true; }
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") onGround = false;
    }
    IEnumerator TimeDelay()
    {
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
