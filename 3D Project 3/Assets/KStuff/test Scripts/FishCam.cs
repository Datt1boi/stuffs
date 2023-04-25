using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float distance = 5.0f; // The distance between the camera and the target
    public float height = 2.0f; // The height of the camera above the target
    public float rotationDamping = 3.0f; // The speed at which the camera rotates around the target
    public float verticalAngleLimit = 80.0f; // The maximum vertical angle the camera can look up or down

    private float currentRotation = 0.0f; // The current horizontal rotation angle of the camera
    private float currentVerticalAngle = 0.0f; // The current vertical rotation angle of the camera

    void LateUpdate()
    {
        // Calculate the desired horizontal rotation angle based on mouse input
        currentRotation += Input.GetAxis("Mouse X") * rotationDamping;

        // Calculate the desired vertical rotation angle based on mouse input
        currentVerticalAngle -= Input.GetAxis("Mouse Y") * rotationDamping;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -verticalAngleLimit, verticalAngleLimit);

        // Set the rotation of the target object to match the camera rotation
        target.rotation = Quaternion.Euler(currentVerticalAngle, currentRotation, 0);

        // Calculate the desired position of the camera
        Vector3 targetPosition = target.position - (target.forward * distance);
        targetPosition.y = target.position.y + height;

        // Set the position and rotation of the camera
        transform.position = targetPosition;
        transform.LookAt(target);
    }
}