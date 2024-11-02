#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    private GameObject player;
    private Slider levelBar;

    public Dictionary<int, int> maxLevel = new Dictionary<int, int>
    {
        {1, 100},
        {2, 200},
        {3, 300},
        {4, 400},
        {5, 500},
        {6, 600},
        {7, 700},
        {8, 800},
        {9, 900},
        {10, 1000}
    };
    private int maxPoints;
    private int level;
    private int levelPoints;
    // Start is called before the first frame update
    void Start()
    {
        levelBar = GetComponent<Slider>();
        level = player.GetComponent<PlayerLogic>().playerStats["Level"];
        levelPoints = player.GetComponent<PlayerLogic>().playerStats["Level Points"];
        returnLevelPoints();
    }

    // Update is called once per frame
    void Update()
    {
        levelChange();
    }
    private void Awake() 
    {
        player = GameObject.Find("Player");
    }
    private void returnLevelPoints() 
    {
        levelBar.maxValue = maxLevel[level];
        levelBar.value = levelPoints;
    }
    private void levelChange() 
    {
        levelPoints = player.GetComponent<PlayerLogic>().playerStats["Level Points"];
        if (levelPoints >= maxLevel[level])
        {
            Debug.Log("Level up");
 
            Time.timeScale = 0;
            level += 1;
            player.GetComponent<PlayerLogic>().playerStats["Level"] = level;
            levelPoints = 0;
            player.GetComponent<PlayerLogic>().playerStats["Level Points"] = levelPoints;
            levelBar.maxValue = maxLevel[level];
            levelBar.value = 0;
            GameObject.Find("Level Menu").GetComponent<LevelUpScript>().MakeActive();
            // Time.timeScale = 1;
        }
        levelBar.value = levelPoints;
    }

}
#endif