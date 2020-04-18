using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool facingRight;                   //used for making the hero face the proper way when player presses left/right
    bool feetOnFloor;                   //used to prevent double/tripple jumping 
    bool bodyTouchingCollider;          // used to determine of the body is touching a wall. Without this the player can get stuck in corners 
                                
    CapsuleCollider2D footBox;          //Seperate collider for the feet to detect feet touching floor
    BoxCollider2D[] bodyBox;            //seperate collider for the body to detect touching walls. there are 2 hence the array.

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();                //Rigid body for hero
        footBox = gameObject.GetComponent<CapsuleCollider2D>(); 
        bodyBox = gameObject.GetComponents<BoxCollider2D>();
        facingRight = true;
        feetOnFloor = false;
        bodyTouchingCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check once per loop for the hero touching floor and walls
        feetOnFloor = FeetOnFloor();
        bodyTouchingCollider = BodyTouchingCollider();
        //Slow the hero quickly if not pressing left/right
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Space) && (feetOnFloor)) //|| bodyTouchingCollider))
        {
            rb.AddRelativeForce(-1 * rb.velocity);
        }

        //process user input
        if (Input.GetKey(KeyCode.D) && (feetOnFloor || bodyTouchingCollider))    //Move right if touching floor or wall and key pressed
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
            // new Vector2(1, 0)       ... Add force to the right
            // * 6                    ... power of the force
            // - (rb.velocity          ... Subtract the player velocity, so that the faster the player goes, the less force we add. This produces a constant speed
            // * new Vector2(1, 0)     ... This cancels the Y axis of the velocity moderation, because the Y axis (jump) is affected only by an impulse force and doeasn't need to be moderated
            rb.AddRelativeForce(new Vector2(1, 0) * 6 - (rb.velocity * new Vector2(1, 0)));

        }
        if (Input.GetKey(KeyCode.A) && (feetOnFloor || bodyTouchingCollider))   //Move left if touching floor or wall and key pressed
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
            // new Vector2(-1, 0)      ... Add force to the left
            // * 6                    ... power of the force
            // - (rb.velocity          ... Subtract the player velocity, so that the faster the player goes, the less force we add. This produces a constant speed
            // * new Vector2(1, 0)     ... This cancels the Y axis of the velocity moderation, because the Y axis (jump) is affected only by an impulse force and doeasn't need to be moderated
            rb.AddRelativeForce(new Vector2(-1, 0) * 6 - (rb.velocity * new Vector2(1, 0)));
        }
        if (Input.GetKeyDown(KeyCode.Space) && feetOnFloor)         //Jump if space spressed and feet are on floor
        {
            rb.AddForce(new Vector2(0, 0.7f), ForceMode2D.Impulse);
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
