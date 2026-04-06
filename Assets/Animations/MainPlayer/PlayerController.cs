using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    //sprint/run mode *OPTIONAL*
    [SerializeField]
    private float RunSpeed = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
     
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

        anim.SetBool("isWalking", isWalking);

        if (isWalking) 
        {
            anim.SetFloat("input_x", input_x);
            anim.SetFloat("input_y", input_y); 

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * RunSpeed;
            }
            else
            {
                transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
            }
        }
    }
}
