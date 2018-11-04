﻿using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private Vector3 currentLookTarget = Vector3.zero;
    public LayerMask layerMask;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
        if (Input.GetButton("Fire1"))
        {
            AnimatingShoot();
        }
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(camRay.origin, camRay.direction * 1000, Color.green);

        // RaycastHit floorHit;

        // if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        // {
        //     Vector3 playerToMouse = floorHit.point - transform.position;
        //     playerToMouse.y = 0f;
        //     Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
        //     playerRigidbody.MoveRotation(newRotatation);
        // }

        // Vector3 turnDir = new Vector3(Input.GetAxis("Mouse X"), 0f, Input.GetAxis("Mouse Y"));

        // if (turnDir != Vector3.zero)
        // {
        //     Vector3 playerToMouse = (transform.position + turnDir) - transform.position;
        //     playerToMouse.y = 0f;
        //     Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
        //     playerRigidbody.MoveRotation(newRotatation);
        // }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            // 2
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            // 3
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
        anim.SetBool("IsShooting", false);
    }

    void AnimatingShoot()
    {
        anim.SetBool("IsShooting", true);
    }
}