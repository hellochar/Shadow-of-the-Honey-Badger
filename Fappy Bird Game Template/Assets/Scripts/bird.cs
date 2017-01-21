using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead= false; // checks if character is stopped
    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isDead == false)
        {
            if(Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero; //rb2d will be either going up or down
                rb2d.AddForce(new Vector2(0, upForce)); //sets character to move up only, 0 horizontally
                anim.SetTrigger("Flap"); //changes to Flap sprite state
            }

        }
     	
	}
    void OnCollisionEnter2D ()  // once hits the floor cannot move birdy anymore
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die"); //changes to die spirte state
        GameControl.instance.BirdDied();    }
}
