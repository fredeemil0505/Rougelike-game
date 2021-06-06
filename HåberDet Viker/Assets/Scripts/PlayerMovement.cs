using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashRange;
    public float speed;
    private Vector2 targetPosition;
    private Vector2 direction;
    private Animator animator;
    private enum Facing {UP, DOWN, LEFT, RIGHT};
    private Facing facingDirection = Facing.DOWN;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (direction != new Vector2(0, 0))
        {
            SetAnimatorMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void TakeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            facingDirection = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            facingDirection = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            facingDirection = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            facingDirection = Facing.RIGHT;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 curreentPosition = transform.position;
            targetPosition = Vector2.zero;
            if (facingDirection == Facing.UP)
            {
                targetPosition.y = 1;
            }
            else if (facingDirection == Facing.DOWN)
            {
                targetPosition.y = -1;
            }
            else if (facingDirection == Facing.LEFT)
            {
                targetPosition.x = -1;
            }
            else if (facingDirection == Facing.RIGHT)
            {
                targetPosition.x = 1;
            }
            transform.Translate(targetPosition * dashRange);

        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("yDirection", direction.y);
        animator.SetFloat("xDirection", direction.x);
    }

}
