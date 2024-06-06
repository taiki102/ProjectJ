using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    [SerializeField]
    Joystick joy;

    [SerializeField]
    Animator animator;

    public float speed = 50.0f;

    private void Update()
    {
        //moveSpeed = 5.0f * joy.INPUT.normalized * Time.deltaTime;
        Vector3 pos = transform.position;

        Vector3 direction = new Vector3(joy.INPUT.x, 0f, joy.INPUT.y);

        Vector3 movement = Vector3.zero;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            movement = transform.forward * speed * Time.deltaTime;
            movement.y = 0f;
            transform.position = pos + movement;

        }

        Debug.Log(movement.magnitude);

        animator.SetFloat("Move", movement.magnitude);

        transform.position = new Vector3(transform.position.x,0f, transform.position.z);
    }
}
