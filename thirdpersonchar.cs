using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonchar : MonoBehaviour
{
    public float speed;
    private float rspeed;
    private double dspeed;
    private float currentspeed;
    
    
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {     

        float hor = -(Input.GetAxis("Horizontal"));
        float ver = -(Input.GetAxis("Vertical"));

        

        Vector3 playerMovement = new Vector3(hor, 0f, ver) * rspeed * Time.deltaTime;
     
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            rspeed = speed + 5;
        }
        else
        {
            rspeed = speed;
        }

    }
}
