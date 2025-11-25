using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class BunnyController : MonoBehaviour
{
    private float jumpForce = 5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Bunny [{this.GetInstanceID()}] collided with {other.gameObject.name}");

        if (other.gameObject.name == "Player")
        {
            this.transform.DOJump(new Vector3(this.transform.position.x + 2, this.transform.position.y), 1, 1, 1);
        }
    }
}
