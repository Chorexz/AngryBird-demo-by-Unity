using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{


    public Sprite [] spritemove;
    public int moveAnimeNum = 0;
    private SpriteRenderer render;

    public float moveSpeed;


	private void Awake()
	{
        render = GetComponent<SpriteRenderer>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move() {
        float xm = 0, ym = 0;
        bool moveorNo = false;
        if (Input.GetKey(KeyCode.W))
        {
            ym += moveSpeed * Time.deltaTime;
            moveorNo = true;
        }
        else if (Input.GetKey(KeyCode.S)) {
            ym -= moveSpeed * Time.deltaTime;
            moveorNo = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            xm += moveSpeed * Time.deltaTime;
            moveorNo = true;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            xm -= moveSpeed * Time.deltaTime;
            moveorNo = true;

        }
        transform.Translate(new Vector2(xm, ym));
        if (moveorNo == true) 
        {
            moveAnimation();

        }
    }

    void moveAnimation() {
        if (moveAnimeNum  >= spritemove.Length)
        {
            moveAnimeNum = 0;
        }
        render.sprite = spritemove[moveAnimeNum++];
    }
}
