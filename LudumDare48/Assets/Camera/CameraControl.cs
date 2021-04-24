using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform = null;
    [SerializeField] private float maxY = 0;
    [SerializeField] private float speed = .1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
            Move(Vector3.up);
        if (Input.GetKey("a"))
            Move(Vector3.left);
        if (Input.GetKey("s"))
            Move(Vector3.down);
        if (Input.GetKey("d"))
            Move(Vector3.right);
    }

    void Move(Vector3 direction)
    {
        cameraTransform.transform.position = yTest(cameraTransform.position + (direction * (speed * Time.deltaTime)) );
    }

    Vector3 yTest(Vector3 input)
    {
        if (input.y > maxY)
            input = new Vector3(input.x, maxY, input.z);
        return input;
    }
}
