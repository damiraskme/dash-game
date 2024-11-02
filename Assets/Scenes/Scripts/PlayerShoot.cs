#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ACTIVE
public class PlayerShoot : MonoBehaviour
{
    private GameObject playerObj;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    private bool canShoot = true;
    private float timer;
    public float fireRate = 3;
    private float fireRateCap = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // fireRate = playerObj.GetComponent<PlayerLogic>().playerStats["Fire Rate"];
        Shoot();
    }

    private void Awake() 
    {
        playerObj = GameObject.Find("Player");
    }
    void Shoot()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= (fireRateCap - fireRate))
            {
                canShoot = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canShoot)
        {
            Vector3 spawnPos = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);
            GameObject bullet = Instantiate(bulletPrefab, spawnPos, spawnPoint.rotation);
            Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.velocity = spawnPoint.transform.up * 5f;
            if (Vector3.Distance(playerObj.transform.position, bullet.transform.position) > 1)
            {
                Destroy(bullet);
                Debug.Log("Out of range");
            }
            else
            {
                Destroy(bullet, 6);
            }
            canShoot = false;
        }
    }

}
#endif