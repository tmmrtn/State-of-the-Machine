using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if(!facingRight)
            {
                // Switch the way the player is labelled as facing
                facingRight = !facingRight;

                // Multiply the player's x local scale by -1
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            rb.AddForce(new Vector2(5, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                // Switch the way the player is labelled as facing
                facingRight = !facingRight;

                // Multiply the player's x local scale by -1
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            rb.AddForce(new Vector2(-5, 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }
}
