using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectToFall : MonoBehaviour
{
    public float fallSpeed;
    public GameObject border1;
    public GameObject border2;
    public GameObject surface;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * fallSpeed);
    }
}
