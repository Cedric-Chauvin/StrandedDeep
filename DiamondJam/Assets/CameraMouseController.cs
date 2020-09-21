using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseController : MonoBehaviour
{

    public float sensitivity = 100f;
    private Transform _player;
    private float _xRotation = 0;
    private void Awake()
    {
    }
    private void Start()
    {
        _player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        Vector3 pRotation = Vector3.up * mouseX;
        _player.Rotate(Vector3.up * mouseX);
    }
}
