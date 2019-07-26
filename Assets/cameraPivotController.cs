using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPivotController : MonoBehaviour
{

    // public variables --------------------
    

    // private variables -------------------
    private float m_target;                     // Target rotation of where the pivot should go
    private float m_rVelocity = 0.0f;           // Velocity used in the rotation movement
    private bool m_listenMouse = false;         // If the mouse input is triggered, only listen to it


    // -------------------------------------
    // Start is called before update
    // -------------------------------------
    void Start()
    {
 
    }

    // -------------------------------------
    // Update is called once per frame
    // -------------------------------------
    void Update()
    {
        // Always chgeck for inputs 
        CheckInput();

        // Rotate pivot
        RotatePOV();
    }


    // -------------------------------------
    // Methods
    // -------------------------------------
    // Check if the user presses left or right ----------------------------------------
    private void CheckInput()
    {
        // Check if the mouse is triggerred
        if (Input.GetAxis("Fire1") > 0)
            m_listenMouse = true;
        else
            m_listenMouse = false;
    }


    // Moving animation ---------------------------------------------------------------
    private void RotatePOV()
    {
        // Variable for speed 0f animation
        float speed = 0.2f;

        // Check which input to listen to
        if (!m_listenMouse)
            m_target += Input.GetAxis("Horizontal");
        else if (m_listenMouse)
            m_target += Input.GetAxis("Mouse X");

        // Smooth animation from the current angle to the target angle
        float nextPos = Mathf.SmoothDampAngle(transform.eulerAngles.y, m_target, ref m_rVelocity, speed);
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, nextPos, transform.eulerAngles.z);
    }
}
