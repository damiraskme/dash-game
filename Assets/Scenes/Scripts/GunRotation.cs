#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ACTIVE
public class GunRotation : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Transform playerPos;
    public float offSet = 0.6f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    // TODO: 
    void Update()
    {
        rotateGun();
    }

    void rotateGun()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 direction = mousePos - playerPos.position;
        direction.z = 0f;
        direction.Normalize();
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = playerPos.position + direction * offSet;

        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
    
}
#endif