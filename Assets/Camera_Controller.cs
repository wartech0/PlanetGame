using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float mouseSensitivity = 1.0f;

    private Rigidbody cameraRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        cameraRigidBody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        cameraRigidBody.velocity += transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.fixedDeltaTime;
        cameraRigidBody.velocity += transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * mouseSensitivity, mouseX * mouseSensitivity, 0);


        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            movementSpeed *= 3;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            movementSpeed /= 3;
        }

        if(Input.GetKey(KeyCode.LeftControl)) {
            cameraRigidBody.velocity += transform.up * -movementSpeed * Time.fixedDeltaTime;
        }
        
        if(Input.GetKey(KeyCode.Space)) {
            cameraRigidBody.velocity += transform.up * movementSpeed * Time.fixedDeltaTime;
        }
    }
}
