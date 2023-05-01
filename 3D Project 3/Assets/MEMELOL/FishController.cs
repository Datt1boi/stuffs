using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float speed = 5f;        // movement speed
    public float turnSpeed = 50f;   // turning speed
    public float gravity = 9.81f;   // gravity
    public float ascentSpeed = 5f;  // ascend speed
    public float descentSpeed = 2f; // descent speed

    public float mouseSensitivity = 100f; // mouse sensitivity

    public Transform cameraTransform; // camera transform

    private Rigidbody rb; // rigidbody component
    private Vector3 moveDirection = Vector3.zero; // movement direction
    private float verticalLookRotation; // vertical look rotation

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the rigidbody component
        Cursor.lockState = CursorLockMode.Locked; // lock the cursor to the center of the screen

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void FixedUpdate()
    {
        // apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // apply movement inputs
        moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        moveDirection.Normalize();
        moveDirection *= speed;

        // handle ascend and descend inputs
        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection += Vector3.up * ascentSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveDirection += Vector3.down * descentSpeed;
        }

        // move the rigidbody
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

        // calculate horizontal rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, horizontalRotation, 0f);

        // calculate vertical rotation
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(-verticalLookRotation, 0f, 0f);

        // check if any input is being pressed
        bool isMoving = moveDirection.magnitude > 0.1f;

        // calculate the target rotation
        Vector3 targetDirection = isMoving ? moveDirection.normalized : transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // smoothly rotate towards the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // move the camera with the fish
        cameraTransform.position = transform.position - transform.forward * 3f + Vector3.up * 1f;
    }
}
