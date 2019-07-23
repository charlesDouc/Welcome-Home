﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPivotController : MonoBehaviour
{

    // public variables --------------------
    

    // private variables -------------------
    private Vector3[] m_POV;                    // Instance of Point of view around the pivot
    private Vector3 m_target;                   // Target rotation of where the pivot should go
    private Vector3 m_currentRot;               // Current rotation of the pivot
    private float m_step = 90f;                 // Step that the the rotation uses for each transformation
    private bool m_isMoving = false;            // Check if the pivot is moving atm
    private float m_rVelocity = 0.0f;


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

        // If an inpout has been triggered
        if (m_isMoving)
            RotatePOV();

        
    }


    // -------------------------------------
    // Methods
    // -------------------------------------
    // Check if the user presses left or right ----------------------------------------
    private void CheckInput()
    {
        // if it goes right
        if (Input.GetAxis("Horizontal") > 0f && !m_isMoving)
        {
            // Catch the current rotation and pivot it to the right
            m_currentRot = transform.rotation.eulerAngles;
            m_target = new Vector3 (m_currentRot.x, m_currentRot.y - m_step, m_currentRot.z);

            // Can now move
            m_isMoving = true;
        }

        // if it goes left
        if (Input.GetAxis("Horizontal") < 0f && !m_isMoving)
        {
            // Catch the current rotation and pivot it to the right
            m_currentRot = transform.rotation.eulerAngles;
            m_target = new Vector3 (m_currentRot.x, m_currentRot.y + m_step, m_currentRot.z);

            // Can now move
            m_isMoving = true;
        }
    }

    // Moving animation ---------------------------------------------------------------
    private void RotatePOV()
    {
        float nextPos = Mathf.SmoothDampAngle(transform.eulerAngles.y, m_target.y, ref m_rVelocity, 0.5f);
        transform.eulerAngles = new Vector3(m_currentRot.x, nextPos, m_currentRot.z);

        if (m_currentRot.y >= m_target.y - 0.01f)
            m_isMoving = false;


    }
}