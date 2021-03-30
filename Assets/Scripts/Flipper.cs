using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{   
    HingeJoint hinge;
    public float restpos = -20f;
    public float pressedpos = 60f;
    public bool isLeft = true;
    
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = 10000f;
        spring.damper = 150f;
        if(isLeft){
            if (Input.GetKey(KeyCode.LeftArrow))
                spring.targetPosition = pressedpos;
            else
                spring.targetPosition = restpos;
        }else{
            if (Input.GetKey(KeyCode.RightArrow))
                spring.targetPosition = pressedpos;
            else
                spring.targetPosition = restpos;
        }
        
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}

