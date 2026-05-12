using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Boost Settings")]
    public float boostMultiplier = 2f;
    public float maxBoostDuration = 3f;
    private bool isBoosting = false;
    private float boostTimer = 0f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleInput();
        HandleBoost();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame && boostTimer < maxBoostDuration)
        {
            isBoosting = true;
        }

        if (Keyboard.current.leftShiftKey.wasReleasedThisFrame || boostTimer >= maxBoostDuration)
        {
            isBoosting = false;
        }
    }

    void HandleBoost()
    {
        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
        }
        else if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime * 0.5f;
        }
        boostTimer = Mathf.Clamp(boostTimer, 0, maxBoostDuration);
    }

    void MovePlayer()
    {
        float currentForwardSpeed = isBoosting ? forwardSpeed * boostMultiplier : forwardSpeed;

        float moveHorizontal = 0;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveHorizontal = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveHorizontal = 1;

        Vector3 movement = new Vector3(moveHorizontal * sideSpeed, rb.linearVelocity.y, currentForwardSpeed);
        rb.linearVelocity = movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartLevel();
        }
    }

    private void OnTriggerEnter(Collider foreign)
    {
        if (foreign.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Level Complete!");
            forwardSpeed = 0;
        }

        if (foreign.gameObject.CompareTag("DeathZone"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        transform.position = startPosition;
        boostTimer = 0;
        rb.linearVelocity = Vector3.zero;
    }
}