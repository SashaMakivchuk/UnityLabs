using UnityEngine;

public class HouseLogic : MonoBehaviour
{
    private bool hasReceivedPension = false;

    private void OnTriggerEnter(Collider other)
    {
        PostmanControler postman = other.GetComponent<PostmanControler>();

        if (postman != null && !hasReceivedPension)
        {
            postman.DeliverPension();
            hasReceivedPension = true;
            Debug.Log("Pension delivered to this house!");
        }
    }
}