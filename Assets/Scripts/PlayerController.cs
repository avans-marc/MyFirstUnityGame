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

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isMoving = false;
    private CurrentMove currentMove = CurrentMove.None;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void Update()
    {
        // Horizontal movement
        if (Input.GetKey(KeyCode.D) && currentMove != CurrentMove.Right)
        {
            currentMove = CurrentMove.Right;
            spriteRenderer.flipX = false;

            this.transform
                .DOMoveX(this.transform.position.x + 1, 1)
                .SetEase(Ease.Linear)
                .OnStart(StartMovement)
                .OnComplete(CompleteMovement);
        }

        if (Input.GetKey(KeyCode.A) && currentMove != CurrentMove.Left)
        {
            spriteRenderer.flipX = true;
            currentMove = CurrentMove.Left;

            var transform = this.transform
               .DOMoveX(this.transform.position.x - 1, 1)
               .SetEase(Ease.Linear)
               .OnStart(StartMovement)
               .OnComplete(CompleteMovement);
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentMove != CurrentMove.Jump)
        {
            this.transform
                .DOJump(new Vector3(this.transform.position.x + 2, this.transform.position.y), jumpForce, 1, 1)
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
        currentMove = CurrentMove.None;
    }

    private enum CurrentMove
    {
        None,
        Jump,
        Left,
        Right,
    }
}