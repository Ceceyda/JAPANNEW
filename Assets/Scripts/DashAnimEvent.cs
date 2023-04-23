using UnityEngine;

public class DashAnimEvent : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 1f;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
