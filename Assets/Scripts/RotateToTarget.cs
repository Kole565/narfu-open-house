using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public Transform targetTransform;
    public float rotationSpeed = 5f;
    public float verticalOffset = 0.5f;
    private Camera mainCamera;
    private Vector3 targetPosition;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            targetPosition = targetTransform.position + Vector3.up * verticalOffset;

            transform.position = targetPosition;

            if (mainCamera != null)
            {
                Vector3 directionToCamera = transform.position - mainCamera.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
