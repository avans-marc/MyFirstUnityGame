using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BunnyController : MonoBehaviour
{
    public event Action OnBunnyExit;

    public GameObject player;
    public Sprite idle;
    public Sprite jump;

    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;

    private bool isDragging;

    private void Start()
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] instantiated");

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = player.GetComponent<Transform>();

        spriteRenderer.sprite = idle;
    }

    public void OnBecameInvisible()
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] became invisible");
        OnBunnyExit?.Invoke();
        Destroy(this.gameObject, 5);
    }

    public void Update()
    {

        if (isDragging)
            transform.position = GetMousePosition();
        else
            this.spriteRenderer.flipX = this.playerTransform.position.x > this.transform.position.x;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] collided with {other.gameObject.name}");

        if (!this.gameObject.IsDestroyed() && other.gameObject.name == "Player")
        {
            spriteRenderer.sprite = jump;

            this.transform.DOJump(new Vector3(this.transform.position.x + (this.playerTransform.position.x > this.transform.position.x ? -2 : 2), this.transform.position.y), 1, 1, 1).OnComplete(() =>
            {
                spriteRenderer.sprite = idle;
            });
        }
    }


    public void StartDragging()
    {
        Debug.Log("Start dragging");
        isDragging = true;
    }


    public void StopDragging()
    {
        Debug.Log("Stop dragging");
        isDragging = false;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }
}
