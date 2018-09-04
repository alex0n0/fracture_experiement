using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    //NOTE: because it is a component of PlayerCamera, it is alreaody attached
    //NOTE: becaues it is not a component of Player, player instance must be instantiated
    //STEP 4
    //this is how you let this controller affect another game object
    public Transform playerBody;

    //value representing rotation speed
    public float mouseSensitivity;

    //STEP 5
    float xAxisClamp = 0.0f;


    //STEP 3: lock cursor
    //function only called once in each game object
    //can also put it in lockState in Update method
    void Awake() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    //STEP 1
    void Update() //to lock cursor
    {
        RotateCamera();
    }

    //STEP 2
    void RotateCamera()
    {
        //captures amount of X and Y movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //amount of rotation on x and y axes
        //get the amount of rotation by position * sensitivity
        //all in degrees and not radians
        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;



        //STEP 4: retain rotation y axis. 
        /*
                //(old method, now change player body rotation)
                //targetRot is used to get the rotation
              //then put targetRot into game object rotation
              //extract rotation with targetRot
              //purpose of euler
               //transform.rotation is a quarterion
               //.eulerAngles converts it into a Vector3

                Vector3 targetRot = transform.rotation.eulerAngles;
                targetRot.x += rotAmountX;
                targetRot.y += rotAmountY;
                targetRot.x -= rotAmountY;//camera movement around x axies depends on Y position of mouse
                targetRot.y += rotAmountX;//camera movement around y axis depends on X position of mouse
                //only allow vertical
        */
        Vector3 targetRotCam = transform.rotation.eulerAngles; // rotate the camera up and down
        targetRotCam.x -= rotAmountY;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles; //rotate the body, and child camera
        targetRotBody.y += rotAmountX;//body rotates on the y axis

        //STEP 5
        xAxisClamp -= rotAmountY;
        targetRotCam.z = 0; //ensures that mouse y cannot flip camera upside down
        if (xAxisClamp > 90) { //models looking directly down (0 horizontal, 90 down)
            xAxisClamp = 90;
            targetRotCam.x = 90;
        } else if (xAxisClamp < -90) {//models looking directly upwards
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        //STEP 4
        /*
        //above is getting rotation, below is putting it into the object's rotation
        //if transforming vector 3 back into quaternion, use Quaterion.Euler(Vector3) to turn back into quaternion
        transform.rotation = Quaternion.Euler(targetRot);
        */
        transform.rotation = Quaternion.Euler(targetRotCam);//transform refers to the main object
        playerBody.rotation = Quaternion.Euler(targetRotBody);//playerBody refers to the linked object

    }
    
}
