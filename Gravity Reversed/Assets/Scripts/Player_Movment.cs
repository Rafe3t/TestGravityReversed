using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey("a"))
        {

            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
