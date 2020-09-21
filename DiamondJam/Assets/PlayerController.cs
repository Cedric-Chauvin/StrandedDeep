using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity = 0.1f;
    public bool isCrouched = false;
    public float normalHeight = 0.5f;
    public float crouchedHeight = 0f;
    public float globalHeight = 2.0f;
    public GameObject topCollider;
    void Update()
    {
        Move();
        Actions();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);
    }

    public void Actions()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouched)
        {
            isCrouched = true;
            topCollider.SetActive(!isCrouched);
            Camera.main.transform.localPosition = new Vector3(0, crouchedHeight, 0);
        }
        if (!Input.GetKey(KeyCode.LeftControl) && isCrouched && StandCheck())
        {
            isCrouched = false;
            topCollider.SetActive(!isCrouched);
            Camera.main.transform.localPosition = new Vector3(0, normalHeight, 0);
        }
    }

    public bool StandCheck()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Vector3.up, out hit, globalHeight - Camera.main.transform.position.y, layerMask))
        {
            return false;
        }
        else
            return true;
    }
}
