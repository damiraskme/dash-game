#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//ACTIVE
public class PlayerMovement : MonoBehaviour
{ 
    private Transform playerPos;
    private GameObject parentObj;
    private Transform camPos;  
    private Vector2 movementInput;
    private Rigidbody2D playerRigidBody;
    private int playerSpeed;
    private Vector2 smoothMovement;
    private Vector2 movementInputSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>();
        playerSpeed = playerPos.GetComponent<PlayerLogic>().playerStats["Speed"] + 4;
        Debug.Log("Speed: " + playerSpeed);
        playerRigidBody = GetComponent<Rigidbody2D>();
        camPos = transform.parent.GetComponentInChildren<Camera>().transform;
        // camPos = GetComponentInParent<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        playerMovement();
        gunFollowPlayer();
    }
    void gunFollowPlayer()
    {
        camPos.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);

    }

    private void OnMove(InputValue input) 
    {
        movementInput = input.Get<Vector2>();
    }
    void playerMovement()
    {
        smoothMovement = Vector2.SmoothDamp(
            smoothMovement,
            movementInput,
            ref movementInputSmoothVelocity,
            0.1f);
        playerRigidBody.velocity = smoothMovement * playerSpeed;
    }
    


}
#endif