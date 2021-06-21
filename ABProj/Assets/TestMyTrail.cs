using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyTrail : MonoBehaviour
{
    public WeaponTrail myTrail;

    private Animator animator;
    private float t = 0.03f;
    private float tempT = 0;
    private float animationIncrement = 0.003f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myTrail.SetTime(0.0f, 0.0f, 1.0f);


    }

    private void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);
        if (t > 0)
        {
            while (tempT < t)
            {
                tempT += animationIncrement;
                if (myTrail.time > 0)
                {
                    myTrail.Itterate(Time.time - t + tempT);

                }
                else
                {
                    myTrail.ClearTrail();

                }
            }
            tempT -= t;
            if (myTrail.time > 0)
            {
                myTrail.UpdateTrail(Time.time, t);

            }

        }
    }

    

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 50, 50), "攻击"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void trailStart()
    {
        myTrail.SetTime(2.0f, 0.0f, 1.0f);
        myTrail.StartTrail(0.5f, 0.4f);

    }

    public void clearTrail()
    {
        myTrail.ClearTrail();

    }
}
