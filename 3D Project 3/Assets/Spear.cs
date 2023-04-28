using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Transform Hand;
    public Rigidbody rb;

    public bool isHeld;
    public bool isRetracting;

    public float throwPower;
    public float retractPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Catcth();
    }

    // Update is called once per frame
    void Update()
    {
        if( isHeld && Input.GetMouseButtonDown(0))
        {
            Throw();
            
        }
        else if(!isHeld && Input.GetMouseButton(1))
        {
            isRetracting = true;
        }
        else if (!isHeld && Input.GetMouseButton(1))
        {
            isRetracting = false;
        }
        
    }
    private void FixedUpdate()
    {
        if (isRetracting)
        {
            Retract();
        }
    }

    void Throw()
    {
        rb.isKinematic = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        transform.parent = null;

        rb.AddForce(transform.forward * throwPower, ForceMode.Impulse);
        isHeld = false;
        transform.Rotate(100 * Time.deltaTime, 0f, 0f, Space.Self);

    }
    void Retract()
    {
if( Vector3.Distance(Hand.position,transform.position) < 1)
        {
            Catcth();
        }
        Vector3 directoinToHand = Hand.position - transform.position;
        rb.velocity = (directoinToHand.normalized * retractPower);
    }
    void Catcth()
    {
        isRetracting = false;
        isHeld = true;

        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.None;
        transform.position = Hand.position;
        transform.parent = Hand;
        transform.rotation = Hand.rotation;
    }
}
