using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDash : MonoBehaviour
{
    public KeyCode tapRight;
    public int rightTotal = 0;
    public float rightTimeDelay = 0;
    

    void Update()
    {
        if (Input.GetKeyDown(tapRight))
        {
            rightTotal += 1;
        }

        if ((rightTotal == 1) && (rightTimeDelay < .5))
            rightTimeDelay += Time.deltaTime;

        if ((rightTimeDelay ==1) && (rightTimeDelay > .5))
        {
            rightTimeDelay = 0;
            rightTotal = 0;
        }

        if ((rightTotal == 2) && (rightTimeDelay >= .5))
        {
            rightTotal = 0;
            rightTimeDelay = 0;
        }

    }
}
