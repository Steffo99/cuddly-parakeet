﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    Rigidbody2D rb;
    ContactPoint2D[] contactPoints;
    int contactCount;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        contactPoints = new ContactPoint2D[16];
    }
	
	// Update is called once per frame
	void Update () {
        contactCount = rb.GetContacts(contactPoints);
        for (int i = 0; i < contactCount; i++)
        {
            if (contactPoints[i].collider.gameObject.tag == "Ground")
            {
                Debug.Log("grounded");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
        }
        if (rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y*(fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y>0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

	}
}
