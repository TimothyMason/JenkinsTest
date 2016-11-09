using UnityEngine;
using System.Collections;

public class AIPathFinding : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;

    // Rotation not currently working
    private Quaternion targetRotation;

    private float movementSpeed = 4.0f;

    void Update()
    {
        trackPlayer();
    }

    void trackPlayer()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        /*targetRotation = new Quaternion(target.transform.rotation.x, target.transform.rotation.y, target.transform.rotation.z,
            target.transform.rotation.w);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, movementSpeed * Time.deltaTime);*/
    }
}
