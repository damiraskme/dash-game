#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private Transform playerPos;
    private GameObject GameOverCanvas;
    private Canvas canvas;
    private Bounds background;
    private bool enemySpawn = true;
    public Transform[] backPoints;

    private float timer = 2f;
    public GameObject enemy1;
    public GameObject enemy2;
    private int[] enemyWave = {
        2, 4};
        // , 6, 8, 10};
        
    private int wave = 0;
    private int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameOverCanvas = GameObject.Find("GameOver");
        GameOverCanvas.GetComponent<Text>().text = "Game Over!";
        // timer += Time.deltaTime;
        // spawnRandomPoint(enemy1);

    }
    void Update() 
    {
        enemyTimer();
    }
    private void enemyTimer() {
        timer -= Time.deltaTime;
        if(wave == enemyWave.Length-1 && enemyCount == enemyWave[wave]) {
            Debug.Log("Last wave ended");
            gameOver();
            enemySpawn = false;
            Time.timeScale = 0;
            Application.Quit();
        }
        if(timer <= 0 && enemySpawn) {
            spawnRandomPoint(enemy1);
            timer = 2f;
            enemyCount +=1;
        }
        else if(enemyCount >= enemyWave[wave]) {
            enemyCount = 0;
            wave +=1;   
        }
        
    }
    public void gameOver() {
        GameOverCanvas.SetActive(true);
    }

    void spawnEnemy(GameObject enemyName, List<float> list)
    {
        float randomX = Random.Range(list[0], list[1]);
        float randomY = Random.Range(list[2], list[3]);
        Vector2 randomCord = new Vector2(randomX, randomY);
        Transform points = enemyName.transform;
        points.position = randomCord;
        var enemies = Instantiate(enemyName, points);
        enemies.transform.parent = transform;
        Destroy(enemies, 2);
    }
    public void spawnRandomPoint(GameObject enemyName)
    {
        int randomIndex = (int)Random.Range(0, backPoints.Length);
        Vector3 randomCord = new Vector3(backPoints[randomIndex].position.x, backPoints[randomIndex].position.y, 1);
        var enemies = Instantiate(enemyName, randomCord, transform.rotation);
        enemies.transform.parent = transform;
        // Destroy(enemies, 10);
    }

    private List<float> randomMinMax(Transform[] points)
    {
        float minX = Mathf.Min(points[0].position.x, points[1].position.x, points[2].position.x, points[3].position.x);
        float maxX = Mathf.Max(points[0].position.x, points[1].position.x, points[2].position.x, points[3].position.x);
        float minY = Mathf.Min(points[0].position.y, points[1].position.y, points[2].position.y, points[3].position.y);
        float maxY = Mathf.Max(points[0].position.y, points[1].position.y, points[2].position.y, points[3].position.y);
        List<float> randomPoints = new List<float>()
        {
            minX, maxX, minY, maxY
        };
        return randomPoints;
    }

}
#endif