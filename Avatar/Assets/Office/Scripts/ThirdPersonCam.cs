using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThirdPersonCam : MonoBehaviour
{
    public float rotationSpeed;
    public Transform player;
    private Vector2 input;
    private Quaternion freeRotation;
    private Vector3 targetDirection;
    public Transform orientation;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector3 offset = new Vector3(transform.position.x, player.position.y, transform.position.z);
        Vector3 view = player.position - offset;
        orientation.forward = view.normalized;

        UpdateTargetDirection();

        if (targetDirection != Vector3.zero)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, freeRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void UpdateTargetDirection()
    {
        var forward = cameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0;

        var right = cameraTransform.TransformDirection(Vector3.right);

        targetDirection = input.x * right + input.y * forward;
    }
}
