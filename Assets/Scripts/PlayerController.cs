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

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        contactPoints = new ContactPoint2D[16];
    }

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
		/* Quindi, se ho capito bene...
		 * Mentre salta la gravità è normale
		 * Se sta salendo, e il salto viene interrotto in anticipo la gravità viene moltiplicata per il lowJumpMultiplier
		 * Mentre cade la gravità viene moltiplicata per il fallMultiplier
		 * --Steffo
		 */
        if (rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        } else if (rb.velocity.y>0 && !Input.GetKey(KeyCode.Space)){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }

		if (Input.GetKey(KeyCode.RightArrow)){
            Movement(1);
        }
		if (Input.GetKey(KeyCode.LeftArrow)){
            Movement(-1);
        }
    }
    void Movement (int dir)//1 = righ, -1 = left
    {
        rb.velocity = new Vector2(dir * sideVelocity, rb.velocity.y);
    }
}
