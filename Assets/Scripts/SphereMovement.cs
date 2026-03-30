using UnityEngine;

public class CycloidMovement : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 2f;
    public float pathLength = 10f;

    private float lastT = 0f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, pathLength);

        MoveWithTranslate(t);
    }

    void MoveWithTranslate(float currentT)
    {
        float x = radius * (currentT - Mathf.Sin(currentT));
        float y = radius * (1 - Mathf.Cos(currentT));
        Vector3 currentPos = new Vector3(x, y, 0);

        float prevX = radius * (lastT - Mathf.Sin(lastT));
        float prevY = radius * (1 - Mathf.Cos(lastT));
        Vector3 prevPos = new Vector3(prevX, prevY, 0);

        transform.Translate(currentPos - prevPos, Space.World);

        lastT = currentT;
    }
}

