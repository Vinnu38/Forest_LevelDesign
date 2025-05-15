using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator ani;

    [SerializeField] float speed;
    float vertical;
    float horizontal;
    float Rotationspeed = 500;
    Quaternion TargetRotation;

    Camera_Movement CamController;
    CharacterController characterController;

    void Awake()
    {
        rb= GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        CamController = Camera.main.GetComponent<Camera_Movement>();
        characterController =GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
        var movingMagnitude = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movement = new Vector3(horizontal, 0, vertical).normalized;

        var MoveDir = CamController.PlanarRotation * movement;

        if (movingMagnitude > 0)
        {
            characterController.Move(MoveDir * speed * Time.deltaTime);
            TargetRotation = Quaternion.LookRotation(MoveDir);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1;
        }


        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, Rotationspeed * Time.deltaTime);

        ani.SetFloat("Run", movingMagnitude, 0.2f, Time.deltaTime);
    }
}
