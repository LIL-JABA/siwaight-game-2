using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] float sensX = 1.0f;

    float rotationY = 0f;

    private void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensX;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}
