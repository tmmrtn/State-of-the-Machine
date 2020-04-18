using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool facingRight;
    bool feetOnFloor;
    bool bodyTouchingCollider;
    CapsuleCollider2D footBox;
    BoxCollider2D[] bodyBox;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        footBox = gameObject.GetComponent<CapsuleCollider2D>();
        bodyBox = gameObject.GetComponents<BoxCollider2D>();
        facingRight = true;
        feetOnFloor = false;
        bodyTouchingCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        feetOnFloor = FeetOnFloor();
        bodyTouchingCollider = BodyTouchingCollider();

        if(Input.GetKey(KeyCode.D) && (feetOnFloor || bodyTouchingCollider))
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
            rb.AddForce(new Vector2(2, 0));
        }
        if (Input.GetKey(KeyCode.A) && (feetOnFloor || bodyTouchingCollider))
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
            rb.AddForce(new Vector2(-2, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && feetOnFloor)
        {
            rb.AddForce(new Vector2(0, 0.8f), ForceMode2D.Impulse);
        }
    }

    bool FeetOnFloor()
    {
        //footBox may or may not be already initialized, so lets just make sure it is.
        //note to future self: as an optimisation you could take out this check once you're sure
        //that "void Start() always executes before void Update() does its first loop."
        if(!footBox)
            footBox = gameObject.GetComponent<CapsuleCollider2D>();
        Collider2D[] colliders = new Collider2D[5];
        footBox.GetContacts(colliders);
        if (colliders[0])
            return true;

        return false;
    }

    bool BodyTouchingCollider()
    {
        if(bodyBox.Length < 1)
            bodyBox = gameObject.GetComponents<BoxCollider2D>();
        BoxCollider2D[] colliders = new BoxCollider2D[5];
        for (int i = 0; i < bodyBox.Length; i++)
        {
            bodyBox[i].GetContacts(colliders);
            if (colliders[0])
                return true;
        }

        return false;
    }
}
