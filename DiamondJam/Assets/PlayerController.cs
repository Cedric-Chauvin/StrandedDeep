using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity = 0.1f;
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);
    }
}
