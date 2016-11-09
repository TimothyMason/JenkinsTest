using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 6.0f;
    private Rigidbody playerRB;
    private float jumpHeight = 5f;
    private bool canJump = true;
    private Vector3 moveDirection;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerCharacterMovement();
        PlayerCharacterJump();
    }

    void PlayerCharacterMovement()
    {
        float moveHor = Input.GetAxisRaw("Horizontal");
        float moveVer = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveHor, 0, moveVer);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= movementSpeed;

        playerRB.AddForce(moveDirection * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    void PlayerCharacterJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump == true)
            {
                playerRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        canJump = true;
    }

    void OnCollisionExit(Collision col)
    {
        canJump = false;
    }
}
