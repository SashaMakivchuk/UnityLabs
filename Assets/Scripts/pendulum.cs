using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float angle = 45f;
    public float speed = 2f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float currentAngle = angle * Mathf.Sin((Time.time - startTime) * speed);

        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
    }
}
