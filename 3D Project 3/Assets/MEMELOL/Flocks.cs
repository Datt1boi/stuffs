using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flocks : MonoBehaviour
{
    public float swimSpeed = 1.0f; // The speed at which the fish swims
    public float turnSpeed = 2.0f; // The speed at which the fish turns
    public float swimTime = 2.0f; // The time for which the fish swims in one direction before turning
    public float turnTime = 1.0f; // The time for which the fish turns in a new direction before swimming again

    private Vector3 swimDirection; // The current direction in which the fish is swimming
    private float swimTimer; // A timer to keep track of how long the fish has been swimming in one direction
    private float turnTimer; // A timer to keep track of how long the fish has been turning in a new direction

    void Start()
    {
        swimDirection = Random.insideUnitSphere.normalized; // Set a random initial swim direction
        swimDirection.y = 0; // Make sure the fish doesn't swim up or down
    }

    void Update()
    {
        swimTimer += Time.deltaTime;
        turnTimer += Time.deltaTime;

        if (swimTimer > swimTime) // If it's time to turn
        {
            swimDirection = Random.insideUnitSphere.normalized; // Pick a new random swim direction
            swimDirection.y = 0; // Make sure the fish doesn't swim up or down
            swimTimer = 0; // Reset the swim timer
            turnTimer = 0; // Reset the turn timer
        }

        if (turnTimer < turnTime) // If still turning in new direction
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, swimDirection, turnSpeed * Time.deltaTime, 0.0f); // Calculate a new direction to turn towards
            transform.rotation = Quaternion.LookRotation(newDirection); // Turn the fish in the new direction
        }
        else // If done turning and it's time to swim
        {
            transform.Translate(0, 0, swimSpeed * Time.deltaTime); // Swim forward in the current direction
        }
    }
}