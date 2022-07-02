using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movSpeed= 1f;
    [SerializeField] float turnSmoothSpeed = 1f;
    [SerializeField] float turnSmoothTime = 0.1f;
    Vector3 direction;


    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(x, 0, y).normalized;

       if(direction.magnitude >= 0.1f)
        {
            float targetAngle= Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            transform.position += direction * movSpeed * Time.deltaTime;
        }
        
    }



}
