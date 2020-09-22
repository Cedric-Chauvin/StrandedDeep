using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float crouchSpeed = 0f;
    public float gravity = -9.81f;
    public bool isCrouched = false;
    public KeyCode CrouchKey;

    Vector3 fall;

    private CharacterController controller;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Move();
        Actions();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = (transform.right * x + transform.forward * z).normalized;
        controller.Move(dir * speed * Time.deltaTime);
        fall.y += gravity * Time.deltaTime;
        if (GroundCheck() && fall.y < 0)
            fall.y = -3f;
        controller.Move(fall * Time.deltaTime);
    }

    public void Actions()
    {
        if (Input.GetKey(CrouchKey) && !isCrouched)
        {
            controller.height = 1.0f;
            controller.center = new Vector3(0f, -0.5f, 0f);
            Camera.main.transform.localPosition = new Vector3(0f, Mathf.Lerp(Camera.main.transform.localPosition.y,-0.25f,crouchSpeed), 0f);
            if (Camera.main.transform.localPosition.y < -0.24f)
            {
                Camera.main.transform.localPosition = new Vector3(0f, -0.25f, 0f);
                isCrouched = true;
            }
        }
        if (!Input.GetKey(CrouchKey) && isCrouched && StandCheck())
        {
            controller.height = 2.0f;
            controller.center = new Vector3(0f, 0f, 0f);
            Camera.main.transform.localPosition = new Vector3(0f, Mathf.Lerp(Camera.main.transform.localPosition.y, 0.5f, crouchSpeed), 0f);
            if(Camera.main.transform.localPosition.y > 0.4f)
            {
                Camera.main.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                isCrouched = false;
            }
        }
    }

    public bool StandCheck()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Vector3.up, out hit, 0.75f, layerMask))
        {
            return false;
        }
        else
            return true;
    }

    public bool GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height/2 + 0.2f))
        {
            return true;
        }
        else
            return false;
    }
}
