#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScript : MonoBehaviour
{
    private Dictionary<string, string> stats = new Dictionary<string, string>
    {
        {"HPButton","Max Health"},
        {"FireRateButton","Fire Rate"},
        {"DamageButton","Damage"},
        {"SpeedButton", "Speed"}
    };
    private Dictionary<string, int> statsAdd = new Dictionary<string, int>
    {
        {"HPButton", 100},
        {"FireRateButton", 2},
        {"DamageButton", 5},
        {"SpeedButton", 1}
    };

    private Transform parentMenu;
    
    private Button[] buttonsList;
    private List<GameObject> buttons = new List<GameObject>();
    private GameObject player;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        parentMenu = transform;
        player = GameObject.Find("Player");
        CheckName(parentMenu);
        MakeInactive();
        buttonList();
        // MakeActive(buttons);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CheckName(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                Debug.Log(child.name);
                buttons.Add(child.gameObject);
            }

            // Recursive call to check further down the hierarchy
            CheckName(child);
        }
    }
    private void buttonList() {
        foreach (GameObject button in buttons) {
            Button btn = button.GetComponent<Button>();
            string buttonName = btn.name;
            btn.onClick.AddListener(delegate {LevelUp(buttonName);});
        }
    }
    private void LevelUp(string buttonName) {
        Debug.Log(player.GetComponent<PlayerLogic>().playerStats[stats[buttonName]] + " " + statsAdd[buttonName]);
        player.GetComponent<PlayerLogic>().playerStats[stats[buttonName]] += statsAdd[buttonName];
        MakeInactive();
        Time.timeScale = 1;
    }
    private void MakeInactive()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }
    public void MakeActive()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }
    
    private void statsUp(string buttonName, List<GameObject> list) {
        foreach (GameObject button in list) {
            if (button.name.Equals(buttonName)) {

            }
        }
    }
}
#endif