using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D playerRB;
    public GameObject playerGameObj; 
    public float speed;
    public float jumpForce;
    public bool offGround = false;
    public GameObject groundCheck;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Playermovement();
        playerAnimation();
        jump();
    }
    void Playermovement()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerGameObj.transform.right = new Vector2(-1f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {

            playerGameObj.transform.right = new Vector2(1f, 0f);
        }

       
    }
    void playerAnimation()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1)
        {
            anim.SetBool("Running", true);

        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
    void jump()
    {
        if (Input.GetAxis("Jump") > 0 && !offGround)
        {
            playerRB.AddForce(new Vector2(0, jumpForce));
            offGround = true;

        }
     //   if (Physics2D.OverlapBox(groundCheck.transform.position,
       //     groundCheck.transform.localScale, 0).gameObject.tag=="ground")
      //  {
         //   print("haha");
      //  }
    }
}
