using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movSpeed= 1f;
    [SerializeField] float turnSmoothSpeed = 1f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Camera cam;
    Animator animator;
    Vector3 direction;
    Vector3 moveDir;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(x, 0, y).normalized;

       if(direction.magnitude >= 0.1f)
        {
            animator.SetBool("Walk", true);
            float targetAngle= Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.position += moveDir * movSpeed * Time.fixedDeltaTime;
        }
       else
        {
            animator.SetBool("Walk", false);
        }
        
    }



}
