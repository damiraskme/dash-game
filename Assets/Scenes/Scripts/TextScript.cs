#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    private GameObject player;

    private string healthText;
    private string maxHealthText;
    private string damageText;
    private string fireRateText;
    private string speedText;
    private string levelText;
    private string xpMaxText;
    private string xpText;

    private GameObject StatsCanvas;
    private GameObject ExpCanvas;
    private GameObject HpCanvas;
    private Text StatsTextCan;
    private Text ExpTextCan;
    private Text HpTextCan;

    private PlayerLogic stats;
    private LevelScript statsLevel;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        StatsCanvas = GameObject.Find("Stats (Legacy)");
        StatsTextCan = StatsCanvas.GetComponent<Text>();
        ExpCanvas = GameObject.Find("XP");
        ExpTextCan = ExpCanvas.GetComponent<Text>();
        HpCanvas = GameObject.Find("HP");
        HpTextCan = HpCanvas.GetComponent<Text>();
        stats = player.GetComponent<PlayerLogic>();
        statsLevel = GameObject.Find("Level Fill").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        getStats();
    }
    private void Awake() 
    {
        player = GameObject.Find("Player");
    }
    void getStats()
    {
        healthText = player.GetComponent<PlayerLogic>().playerStats["Health"].ToString();
        maxHealthText = player.GetComponent<PlayerLogic>().playerStats["Max Health"].ToString();
        damageText = player.GetComponent<PlayerLogic>().playerStats["Damage"].ToString();
        fireRateText = player.GetComponent<PlayerLogic>().playerStats["Fire Rate"].ToString();
        speedText = player.GetComponent<PlayerLogic>().playerStats["Speed"].ToString();
        xpText = player.GetComponent<PlayerLogic>().playerStats["Level Points"].ToString();
        level = player.GetComponent<PlayerLogic>().playerStats["Level"];
        xpMaxText = statsLevel.maxLevel[level].ToString();
        levelText = player.GetComponent<PlayerLogic>().playerStats["Level"].ToString();
        ExpTextCan.text = $"XP: {xpText}/{xpMaxText}\n\n Level: {levelText}";
        HpTextCan.text = $"Health: {healthText}/{maxHealthText}";
        string textStats = $"Damage: {damageText} \nFire Rate: {fireRateText} \nSpeed: {speedText}";
        StatsTextCan.text = textStats;
    }

}
#endif