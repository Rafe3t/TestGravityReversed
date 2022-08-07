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
    public float fallSpeed;
    public float fallFastSpeed;
    float ySpeed;
    public bool offGround;
    public GameObject groundCheck;
    //the object that the player is standing on
    public GameObject onObject;
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
        standing_on_object();
        
    }
    void Playermovement()
    {
        if(offGround == false)
        {
            playerRB.velocity = Mathf.Abs(Input.GetAxis("Horizontal")) * -transform.right * speed;
        }
        else
        {
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, -ySpeed);
        }
        //flips the player direction
        if (Input.GetAxis("Horizontal") > 0 && playerGameObj.transform.right.x > 0)
        {
            playerGameObj.transform.Rotate(0f, 180f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0 && playerGameObj.transform.right.x < 0)
        {
            playerGameObj.transform.Rotate(0f, 180f, 0f);
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
        // if the player pressed jump and he is touching the ground then jump
        if (Input.GetAxis("Jump") > 0 && !offGround)
        {
            playerRB.AddForce(new Vector2(0, jumpForce));
            offGround = true;
        }

        //allows player to fall faster
        if (Input.GetAxis("Vertical") < 0 && offGround == true)
        {
            ySpeed = fallFastSpeed;
        }
        else if(Input.GetAxis("Vertical")>=0 && offGround == true)
        {
            ySpeed = fallSpeed;
        }
        //checks if the object that the box overlaps is not null
        if (Physics2D.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale, groundCheck.transform.eulerAngles.z) != null)
        {
            if (Input.GetAxisRaw("Jump") == 0)
            {
                //checks the tag of the object it overlaps, if it's ground then allow the player to jump
                if (Physics2D.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale, groundCheck.transform.eulerAngles.z).gameObject.tag == "ground")
                {
                    offGround = false;
                }
                
            }
        }
        if(Input.GetAxisRaw("Jump")==1)
        {
            offGround = true;
        }

    }
    public void standing_on_object()
    {
        if(offGround == false)
        {
            if (Physics2D.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale, groundCheck.transform.eulerAngles.z) != null)
            {
                
                onObject = Physics2D.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale, groundCheck.transform.eulerAngles.z).gameObject;
                ySpeed = 0;
                
            }
            //the following code prevent the player from getting away from the falling object unless the player jumps
            GameObject b1, b2,surf;
            b1 = onObject.GetComponent<objectToFall>().border1;
            b2 = onObject.GetComponent<objectToFall>().border2;
            surf = onObject.GetComponent<objectToFall>().surface;
            if ((gameObject.transform.right.x < 0 && gameObject.transform.position.x >= b1.transform.position.x) || (gameObject.transform.right.x > 0 && gameObject.transform.position.x <= b2.transform.position.x))
            {
                speed = 0;
            }
            else
            {
                speed = 20;
            }
            if(transform.right.x > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, onObject.transform.eulerAngles.z);
            }
            else if(transform.right.x < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -onObject.transform.eulerAngles.z);
            }
            transform.SetParent(onObject.transform);
        }
        else
        {
            onObject = null;
            speed = 20;
            transform.SetParent(null);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

   
}
