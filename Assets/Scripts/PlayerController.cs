using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce;
    public int maxJumpIncrease;
    bool rising = false;
    Rigidbody2D rb;
    int jumpIncrease;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector2(0, jumpForce));
            rising = true;
            jumpIncrease = 0;
        }
        if (rising = true && Input.GetKey(KeyCode.Space) && jumpIncrease < maxJumpIncrease)
        {
            rb.AddForce(new Vector2(0, jumpForce / 10));
            jumpIncrease++;
        }

	}
}
