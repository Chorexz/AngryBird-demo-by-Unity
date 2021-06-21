using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigKing : MonoBehaviour
{
    public float maxSpeed = 8;
    public float minSpeed = 4;
    private SpriteRenderer render;
    public Sprite hurtpigKing;
    public GameObject boomAnime;
    public GameObject score;
    public bool isPig = false;
    public float moveSpeed = 10;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurtpigKing;

        }
    }

    void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boomAnime, transform.position, Quaternion.identity);    //生成一个prefab
        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(go, 1.5f);
    }

    void move() {
        float xm = 0, ym = 0;
        if (Input.GetKey(KeyCode.W)) {
            ym += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) { 
            ym -= moveSpeed * Time.deltaTime;
        }
        transform.Translate( xm,ym,0);
  
    }

	private void Update()
	{
       // move();
	}


}
