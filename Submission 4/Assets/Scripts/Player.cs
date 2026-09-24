using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    public Vector2 moveInput; // Variable to store the player's movement input
    public Rigidbody2D rb; // Reference to the player's Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Read the movement input from the Input System and store it in the moveInput variable

    }

    void Movement()
    {
        rb.linearVelocity = moveInput.normalized * speed; // Set the player's Rigidbody linear velocity to move the player in the desired direction at the specified speed

        // Clamp the player's position within the screen limits
        float clampedX = Mathf.Clamp(rb.position.x, -horizontalScreenLimit, horizontalScreenLimit); // Clamp the player's position within the horizontal screen limits
        float clampedY = Mathf.Clamp(rb.position.y, -verticalScreenLimit, verticalScreenLimit); // Clamp the player's position within the vertical screen limits
        rb.position = new Vector2(clampedX, clampedY); // Update the player's position to the clamped values to ensure they stay within the screen limits

    }



    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
