#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private GameObject player;
    private GameObject healthObj;
    private Slider healthBar;
    private GameLogic gameLog;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        health = player.GetComponent<PlayerLogic>().playerStats["Health"];
        MaxHealth(health);
        gameLog = FindAnyObjectByType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthChange();
    }
    private void Awake() 
    {
        player = GameObject.Find("Player");
    }
    private void MaxHealth(int maxhp) 
    {
        healthBar.maxValue = maxhp;
        healthBar.value = maxhp;
    }
    private void HealthChange() 
    {
        health = player.GetComponent<PlayerLogic>().playerStats["Health"];
        if(health <= 0) {
            Time.timeScale = 0;
            gameLog.gameOver();
        }
        healthBar.value = health;
    }
}
#endif