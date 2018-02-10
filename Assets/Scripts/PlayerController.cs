using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float sideVelocity;

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
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
        }
        if (rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y*(fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y>0 && !Input.GetKey(KeyCode.Space)){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)){
            Movement(1);
        }
        if (Input.GetKey(KeyCode.A)){
            Movement(-1);
        }
    }
    void Movement (int dir)//1 = righ, -1 = left
    {
        rb.velocity = new Vector2(1 * dir * sideVelocity, rb.velocity.y);
    }
}
