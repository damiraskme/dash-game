#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INACTIVE
public class PlayerMove : MonoBehaviour
{
    public Transform playerPos;
    public Rigidbody2D playerRigid;
    private float horizontal;
    private float vertical;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6f;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }
    void FixedUpdate()
    {
       playerRigid.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
       
    }
}
#endif