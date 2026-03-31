using UnityEngine;
using UnityEngine.InputSystem;

public class SpearThrower : MonoBehaviour
{
    public float throwForce = 1500f;
    private Rigidbody rb;
    private bool isThrown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !isThrown)
        {
            ThrowSpear();
        }
    }

    void ThrowSpear()
    {
        isThrown = true;
        rb.useGravity = true;
        rb.AddForce(transform.up * throwForce);
        rb.AddTorque(transform.right * 15f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isThrown)
        {
            rb.isKinematic = true;
        }
    }
}