using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private Animator ani;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        var move = new Vector3(x * speed, 0, z * speed);

        rb.velocity = move ;
        
        if(x == 1)
        {
            ani.Play("Run");
        }
    }
}
