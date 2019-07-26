using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideFromView : MonoBehaviour
{
    // public variables -------------------------
    [HideInInspector]public bool m_hiding = false;      // Bool to check if this objects is currently hidden

    // private variables ------------------------
    private MeshRenderer m_render;                      // Instance of the mesh renderer attached to this object

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the mesh renderer of this object
        m_render = GetComponent<MeshRenderer>();
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Check is the object is currently hidden or not
        if(m_hiding)
            m_render.enabled = false;
        else
            m_render.enabled = true;
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
}
