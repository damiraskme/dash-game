#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject enemy;
    private GameObject playerObj;
    public Dictionary<string, int> enemyStats = new Dictionary<string, int>
    {
        {"Health", 100},
        {"Max Health", 100},
        {"Damage", 1},
        {"Speed", 1},
        {"Level", 50}
    };
    private float enemySpeed = 0.05f;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = playerObj.GetComponent<Transform>();
        enemy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStats["Health"] <= 0)
        {
            Destroy(enemy);
            playerObj.GetComponent<PlayerLogic>().playerStats["Level Points"] += enemyStats["Level"];
        }
    }
    private void FixedUpdate() {
        followPlayer();
    }

    private void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, enemySpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.name.Equals("Triangle"))
        {
            enemyStats["Health"] -= playerObj.GetComponent<PlayerLogic>().playerStats["Damage"] * 10;
            Debug.Log("Touched: " + other.collider.name);
            Debug.Log(this.gameObject.name + enemyStats["Health"]);
            
        }
        
    }
    private void Awake() 
    {
        playerObj = GameObject.Find("Player");
    }
}
#endif