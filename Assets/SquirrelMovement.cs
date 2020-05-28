using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMovement : MonoBehaviour
{

    public float moveSpeed = 0.1f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector3 min, max;
    Vector3 mousePosition;
    Vector2 position = new Vector2(0f, 0f);

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        max.x = 8f;
        max.y = 3.45f;
        min.x = 8f;
        min.y = 3.45f;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();

        if (isMoving)
        {
            float distance = Vector2.Distance(transform.position, mousePosition);

            if (distance >= 0)
            {
                position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed);
                animator.SetFloat("Horizontal", position.x - transform.position.x);
                animator.SetFloat("Vertical", position.y - transform.position.y);
                animator.SetFloat("Speed", position.sqrMagnitude);
            }
            else
                isMoving = false;
                animator.SetFloat("Speed", position.sqrMagnitude);

        }
    }


    void GetMousePosition()
    {
        if (Input.GetMouseButtonDown(0) && PositionIsInRange())
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            isMoving = true;
        }
        else if(!Input.GetMouseButton(0))
            isMoving = false;
    }

    private bool PositionIsInRange()
    {
        return true;
        //mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //if (mousePosition.x > min.x && mousePosition.y > min.y && mousePosition.x < max.x && mousePosition.y < max.y)
        //    return true;
        //return false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}

