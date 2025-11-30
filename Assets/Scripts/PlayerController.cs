using DG.Tweening;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float moveSpeed = 2f;
    public float jumpForce = 2f;

    private bool isMoving = false;
    private Move currentMove = Move.None;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void Update()
    {
        // Horizontal movement
        if (Input.GetKey(KeyCode.D) && currentMove != Move.Right)
        {
            currentMove = Move.Right;
            spriteRenderer.flipX = false;

            this.transform
                .DOMoveX(this.transform.position.x + moveSpeed, 1)
                .SetEase(Ease.Linear)
                .OnStart(StartMovement)
                .OnComplete(CompleteMovement);
        }

        if (Input.GetKey(KeyCode.A) && currentMove != Move.Left)
        {
            spriteRenderer.flipX = true;
            currentMove = Move.Left;

            var transform = this.transform
               .DOMoveX(this.transform.position.x - moveSpeed, 1)
               .SetEase(Ease.Linear)
               .OnStart(StartMovement)
               .OnComplete(CompleteMovement);
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentMove != Move.Jump)
        {
            var newPositionX = this.transform.position.x + (CurrentDirection == Direction.Left ? -moveSpeed : moveSpeed);

            this.transform
                .DOJump(new Vector3(newPositionX, this.transform.position.y), jumpForce, 1, 1)
                .OnStart(StartMovement)
                .OnComplete(CompleteMovement);
        }
    }

    private void StartMovement()
    {
        animator.enabled = true;
        isMoving = true;
    }

    private void CompleteMovement()
    {
        animator.enabled = false;
        isMoving = false;
        currentMove = Move.None;
    }

    private Direction CurrentDirection
    {
        get { return spriteRenderer.flipX ? Direction.Left : Direction.Right; }
    }


    private enum Move
    {
        None,
        Jump,
        Left,
        Right,
    }

    private enum Direction
    {
        Left,
        Right
    }
}