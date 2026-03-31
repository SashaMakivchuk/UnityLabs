using UnityEngine;

public class VecorSum : MonoBehaviour
{
    void Start()
    {
        Vector3 vectorA = new Vector3(4, 0, 7);
        Vector3 vectorB = new Vector3(7, 1, 1);
        Vector3 sumVector = vectorA + vectorB;
        float lengthOfSum = sumVector.magnitude;

        Debug.Log("Vector A: " + vectorA);
        Debug.Log("Vector B: " + vectorB);
        Debug.Log("Sum of A and B: " + sumVector);
        Debug.Log("Length of the sum vector: " + lengthOfSum);

        Debug.Log("Клас Collider");
        Debug.Log("Collider - це компонент в Unity, який визначає фізичну форму об'єкта. Без нього об'єкти будуть проходити через один одного. " +
            "Він дозволяє об'єктам взаємодіяти один з одним, реагуючи на зіткнення та тригери.");
        Debug.Log("Існують різні типи коллайдерів, такі як Box Collider, Sphere Collider, Capsule Collider та Mesh Collider. " +
            "isTrigger - робить об'єкт не твердим і дозволяє об'єктам проходити через нього");
    }
}
