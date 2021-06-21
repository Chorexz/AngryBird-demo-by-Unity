using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public Transform rightPot;              //弹弓右端点 
    public Transform leftPot;                //弹弓左端点 
    public float maxDis = 1.5F;
    public LineRenderer rightLine;
    public LineRenderer leftLine;
    public GameObject boomAnime;
    [HideInInspector]
    public SpringJoint2D sp;                   //弹绳
    public bool isFlying = false;
    public Vector3 springAnchor;                //弹绳锚点


    private int birdNo = 0;
    private bool isClick = false;
    private Rigidbody2D rg;
    private TestMyTrail myTrail;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        springAnchor = (rightPot.position + leftPot.position) / 2;
        sp.connectedAnchor = springAnchor;
        myTrail = GetComponent<TestMyTrail>();
    }

    private void OnMouseDown () {       //鼠标按下
        isClick = true;
        rg.isKinematic = true;
    }

    private void OnMouseUp () {          //鼠标抬起
        isClick = false;
        rg.isKinematic = false;
        rightLine.enabled = false;
        leftLine.enabled = false;
        Invoke("Fly", 0.1f);
        isFlying = true;


    }
    
    private void Update () {
        if (isClick == true) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, springAnchor) >maxDis)
            {
                Vector3 dire = (transform.position - springAnchor).normalized;
                dire *= maxDis;
                transform.position = dire + springAnchor;

            }
            LineWriter();
         
        }
    }

    private void Fly()
    {
        sp.enabled = false;
        Invoke("Next", 5);
        myTrail.trailStart();

    }

    private void LineWriter()
    {
        rightLine.enabled = true;
        leftLine.enabled = true;

        rightLine.SetPosition(0, rightPot.position);
        rightLine.SetPosition(1, transform.position);

        leftLine.SetPosition(0, leftPot.position);
        leftLine.SetPosition(1, transform.position);
    }

    /// <summary>
    /// 小鸟轮换
    /// </summary>
    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boomAnime, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myTrail.clearTrail();

    }


}