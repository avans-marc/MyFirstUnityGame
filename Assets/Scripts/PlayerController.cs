using DG.Tweening;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    void Update()
    {
        // Horizontal movement
        float moveInput = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }

        this.transform.DOMoveX(this.transform.position.x + moveInput, 1);
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.DOJump(new Vector3(this.transform.position.x + 2, this.transform.position.y), jumpForce, 1, 1);
        }
    }
    
       
}
