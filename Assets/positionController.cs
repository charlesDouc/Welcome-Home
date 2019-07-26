using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Which elements to deactivate in the view")]
    public bool m_deactivateNorth;                  // Deactivate all elements on the North side
    public bool m_deactivateWest;                   // Deactivate all elements on the West side
    public bool m_deactivateSouth;                  // Deactivate all elements on the South side
    public bool m_deactivateEast;                   // Deactivate all elements on the East side
    [Space(10)]
    public bool m_cameraIn;                         // Detect if the camera is in this position

    // private variables ------------------------
    private GameObject[] m_northObjects;            // All the objects that can be hidden on the North side
    private GameObject[] m_westObjects;             // All the objects that can be hidden on the West side
    private GameObject[] m_southObjects;            // All the objects that can be hidden on the South side
    private GameObject[] m_eastObjects;             // All the objects that can be hidden on the East side


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // If the camera is in position, deactivate sides and activates the visible ones
        if (m_cameraIn)
        {
            DeactivateSides();
            ActivateSides();
        }
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    // Triggers to detect the current camera position ---------------------------------
    private void OnTriggerStay(Collider col)
    {   
        // Check if the camera enters/stays the position
        if (col.gameObject.tag == "MainCamera")
            m_cameraIn = true;
    }

    private void OnTriggerExit(Collider col)
    {
        // Check if the camera exits the position
        if (col.gameObject.tag == "MainCamera")
            m_cameraIn = false;
    }


    // Activate all elements in targetted by this position -------------------------
    private void ActivateSides()
    {
        // If this position targets the North side
        if(!m_deactivateNorth)
        {
            // Check for all elements standing on the North side
            m_northObjects = GameObject.FindGameObjectsWithTag("North");

            // Activate all those selected objects
            for (int i = 0; i < m_northObjects.Length; i++)
                m_northObjects[i].GetComponent<hideFromView>().m_hiding = false;
        }


        // If this position targets the West side
        if(!m_deactivateWest)
        {
            // Check for all elements standing on the West side
            m_westObjects = GameObject.FindGameObjectsWithTag("West");

            // Activate all those selected objects
            for (int i = 0; i < m_westObjects.Length; i++)
                m_westObjects[i].GetComponent<hideFromView>().m_hiding = false;
        }


        // If this position targets the South side
        if(!m_deactivateSouth)
        {
            // Check for all elements standing on the South side
            m_southObjects = GameObject.FindGameObjectsWithTag("South");

            // Activate all those selected objects
            for (int i = 0; i < m_southObjects.Length; i++)
                m_southObjects[i].GetComponent<hideFromView>().m_hiding = false;
        }
        

        // If this position targets the East side
        if(!m_deactivateEast)
        {
            // Check for all elements standing on the East side
            m_eastObjects = GameObject.FindGameObjectsWithTag("East");

            // Activate all those selected objects
            for (int i = 0; i < m_eastObjects.Length; i++)
                m_eastObjects[i].GetComponent<hideFromView>().m_hiding = false;
        }
    }


    // Deactivate all elements in targetted by this position -------------------------
    private void DeactivateSides()
    {
        // If this position targets the North side
        if(m_deactivateNorth)
        {
            // Check for all elements standing on the North side
            m_northObjects = GameObject.FindGameObjectsWithTag("North");

            // Deactivate all those selected objects
            for (int i = 0; i < m_northObjects.Length; i++)
                m_northObjects[i].GetComponent<hideFromView>().m_hiding = true;
        }


        // If this position targets the West side
        if(m_deactivateWest)
        {
            // Check for all elements standing on the West side
            m_westObjects = GameObject.FindGameObjectsWithTag("West");

            // Deactivate all those selected objects
            for (int i = 0; i < m_westObjects.Length; i++)
                m_westObjects[i].GetComponent<hideFromView>().m_hiding = true;
        }


        // If this position targets the South side
        if(m_deactivateSouth)
        {
            // Check for all elements standing on the South side
            m_southObjects = GameObject.FindGameObjectsWithTag("South");

            // Deactivate all those selected objects
            for (int i = 0; i < m_southObjects.Length; i++)
                m_southObjects[i].GetComponent<hideFromView>().m_hiding = true;
        }
        

        // If this position targets the East side
        if(m_deactivateEast)
        {
            // Check for all elements standing on the East side
            m_eastObjects = GameObject.FindGameObjectsWithTag("East");

            // Deactivate all those selected objects
            for (int i = 0; i < m_eastObjects.Length; i++)
                m_eastObjects[i].GetComponent<hideFromView>().m_hiding = true;
        }
    }
}
