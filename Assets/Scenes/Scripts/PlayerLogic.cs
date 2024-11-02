#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public Dictionary<string, int> playerStats = new Dictionary<string, int>
    {
        {"Health", 100},
        {"Max Health", 100},
        {"Fire Rate", 3},
        {"Damage", 10},
        {"Speed", 1},
        {"Bullet Speed", 5},
        {"Level", 1},
        {"Level Points", 0}
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.name + " is touched");
        if (!other.collider.tag.Equals("Background"))
        {
            playerStats["Health"] -= 10;
            Debug.Log("Touched: " + other.collider.name);
            Debug.Log(playerStats["Health"]);
        }
        
    }
    private void deathTrigger() {
        if(playerStats["Health"] <= 0) {
            
        }
    }
}
#endif