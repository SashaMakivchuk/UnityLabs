using UnityEngine;

public class SpiralPlate : MonoBehaviour
{
    public float growthRate = 0.5f;
    public float speed = 1f;
    public float maxRotation = 15f;

    private float lastTheta = 0f;

    void Update()
    {
        float theta = Mathf.PingPong(Time.time * speed, maxRotation);

        ApplySpiralTranslate(theta);
    }

    void ApplySpiralTranslate(float currentTheta)
    {
        float r = growthRate * currentTheta;
        Vector3 currentPos = new Vector3(r * Mathf.Cos(currentTheta), 0, r * Mathf.Sin(currentTheta));

        float prevR = growthRate * lastTheta;
        Vector3 prevPos = new Vector3(prevR * Mathf.Cos(lastTheta), 0, prevR * Mathf.Sin(lastTheta));

        transform.Translate(currentPos - prevPos, Space.World);

        lastTheta = currentTheta;
    }
}
