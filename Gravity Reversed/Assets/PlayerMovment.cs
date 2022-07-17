using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKey("d"))
        {
            player.velocity = new Vector2(speed, player.velocity.y);
        
        }
        if (Input.GetKey("a"))
        {
            player.velocity = new Vector2(-speed, player.velocity.y) ;

        }
        if (Input.GetKey("w"))
        {
            player.velocity = new Vector2(player.velocity.x, speed) ;

        }
        if (Input.GetKey("s"))
        {
            player.velocity = new Vector2(player.velocity.x, -speed) ;

        }


    }
}
