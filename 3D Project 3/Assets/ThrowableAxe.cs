using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxe : MonoBehaviour
{
    public Rigidbody axe;
    public float throwForce = 50;
    public Transform target, curve_point;
    private Vector3 old_pos;
    private bool isReturning = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ThrowAxe();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            ReturnAxe();
        }
        if(isReturning)
        {
            //returning cal
        }
    }
    //Throw axe
    void ThrowAxe()
    {
        axe.transform.parent = null;
        axe.isKinematic = false;
        axe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        axe.AddTorque(axe.transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);
    }
    //return axe
    void ReturnAxe()
    {
        old_pos = axe.position;
        isReturning = true;
        axe.velocity = Vector3.zero;
        axe.isKinematic = true;
    }
    //Reset axe

}
