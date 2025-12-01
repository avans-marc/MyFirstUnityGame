using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BunnyController : MonoBehaviour
{
    
    
    public GameObject player;

    public event Action OnBunnyExit;

    public Sprite Idle;
    public Sprite Jump;

    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private PlayerController playerController;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Idle;

        playerTransform = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();

        Debug.Log($"Bunny [{this.GetInstanceID()}] instantiated");
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] clicked");
    }

    public void OnBecameInvisible()
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] became invisible");
        OnBunnyExit?.Invoke();
        Destroy(this.gameObject, 5);
    }

    

    public void Update()
    {
        this.spriteRenderer.flipX = this.playerTransform.position.x > this.transform.position.x;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] collided with {other.gameObject.name}");

        if (!this.gameObject.IsDestroyed() && other.gameObject.name == "Player")
        {
            spriteRenderer.sprite = Jump;

            this.transform.DOJump(new Vector3(this.transform.position.x + (this.playerTransform.position.x > this.transform.position.x ? -2 : 2), this.transform.position.y), 1, 1, 1).OnComplete(() =>
            {
                spriteRenderer.sprite = Idle;
            });
        }
    }
}
