using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FishMovement : MonoBehaviour
{
    public event Action<Vector3> OnFishMoved;

    [SerializeField] private float swimSpeed = 5f;
    [SerializeField] private float maxVelocityChange = 10f;
    [SerializeField] private float verticalSpeed = 2f;
    [SerializeField] private float descentSpeed = 2f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 1f;
        rb.angularDrag = 1f;
    }

    private void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float upInput = Input.GetAxis("Jump");
        float downInput = Input.GetKey(KeyCode.LeftControl) ? 1f : 0f;

        // Calculate the direction the fish should swim in
        Vector3 swimDirection = new Vector3(hInput, upInput - downInput, vInput).normalized;
        swimDirection = transform.TransformDirection(swimDirection);

        // Calculate the desired velocity based on the swim direction and speed
        Vector3 targetVelocity = swimDirection * swimSpeed;

        // Calculate the velocity change needed to reach the target velocity
        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxVelocityChange);

        // Apply the velocity change to the rigidbody
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Apply vertical movement
        Vector3 verticalMovement = Vector3.up * (upInput - downInput) * verticalSpeed;
        rb.AddForce(verticalMovement, ForceMode.Impulse);

        // Raise the OnFishMoved event with the fish's position
        OnFishMoved?.Invoke(transform.position);
    }

}
