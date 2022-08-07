using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(player.transform.position.x - transform.position.x > 2f)
            {
                transform.position = new Vector3(player.transform.position.x - 2f,transform.position.y,transform.position.z);
            }
            if (player.transform.position.x - transform.position.x < -2f)
            {
                transform.position = new Vector3(player.transform.position.x + 2f, transform.position.y, transform.position.z);
            }

            if (player.transform.position.y - transform.position.y > 2f)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y -2f, transform.position.z);
            }
            if (player.transform.position.y - transform.position.y < -2f)
            {
                transform.position = new Vector3(transform.position.x , player.transform.position.y +2f, transform.position.z);
            }
        }
    }
}
