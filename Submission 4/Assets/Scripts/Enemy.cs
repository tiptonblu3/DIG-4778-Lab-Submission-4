using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5f; // Adjust the speed of rotation
    public float orbitSpeed = 50f; // Adjust the speed of orbiting
    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        OrbitAroundPlayer();
        AvoidPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 targetDirection = (player.position - transform.position).normalized; // Get the direction to the player
        Vector3 currentDirection = transform.forward; // Get the current forward direction of the enemy

        float dot = Vector3.Dot(currentDirection, targetDirection); // Dot product returns a value between -1 and 1 representing how closely aligned they are
        float angle = Mathf.Acos(Mathf.Clamp(dot, -1f, 1f)) * Mathf.Rad2Deg; // ensures the dot value stays strictly between -1 and 1 and converts from radians to degrees

        Vector3 axis = Vector3.Cross(currentDirection, targetDirection); // The axis around which to rotate

        if (axis.sqrMagnitude > 0.0001f && angle > 0.1f)
        {
            float stepAngle = Mathf.Min(angle, rotationSpeed * 60f * Time.deltaTime); // Rotate the enemy around the axis by the step angle
            transform.Rotate(axis.normalized, stepAngle, Space.World); // Rotate the enemy around the axis by the step angle
        }
    }

    private void OrbitAroundPlayer()
    {
        Vector3 offset = transform.position - player.position; // Calculate the offset from the player to the enemy
        Quaternion rotationStep = Quaternion.Euler(0f, 0f, orbitSpeed * Time.deltaTime); // Creates a small rotation increment
        offset = rotationStep * offset; // Rotate the offset vector
        transform.position = player.position + offset; // Update the enemy's position to orbit around the player
    }

    private void AvoidPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < 3f) // If the enemy is too close to the player
        {
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized; // Calculate the direction away from the player
            transform.position += directionAwayFromPlayer * (Time.deltaTime * 5); // Move the enemy away from the player
        }
        
    }
}
