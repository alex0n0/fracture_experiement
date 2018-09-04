using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //STEP 1
    private CharacterController charControl;

    //STEP 3
    public float walkSpeed;

    void Awake()
    {
        //STEP 1: also need to go to the object in unity and add component: character controller
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        //STEP 2
        MovePlayer();
    }


    //STEP 2
    void MovePlayer()
    {
        //the next 2 lines recognise input from arrow keys and WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //STEP 3
                //movement along horizontal axis
                //
        Vector3 moveDirectionRight = transform.right * horizontal * walkSpeed;
                //movement along vertical axis
                //transform.forward refers to the forward vector of gameobject
        Vector3 moveDirectionForward = transform.forward * vertical * walkSpeed;

        //STEP 4
        charControl.SimpleMove(moveDirectionRight);
        charControl.SimpleMove(moveDirectionForward);
    }

}
