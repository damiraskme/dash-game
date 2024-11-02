#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogic : MonoBehaviour
{
    public int spawnTime = 10;
    public bool enemySpawn = false;

    private GameObject gameObj;
    private GameLogic gameLog;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake() {
        gameObj = GameObject.Find("Game Logic");
        gameLog = gameObj.GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemyKey();
        // waiter();
    }
    public void spawnEnemy() {
        gameLog.spawnRandomPoint(gameLog.enemy1);
    }
    private void spawnEnemyKey() {
        if (Input.GetKeyDown(KeyCode.H)) {
            gameLog.spawnRandomPoint(gameLog.enemy1);
        }
    }
    IEnumerator waiter() {
        while (enemySpawn) {

            gameLog.spawnRandomPoint(gameLog.enemy1);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}


#endif