#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    private RectTransform healthBar;
    private Transform enemyPos;
    private Vector3 offSet = new Vector3(0, 1, 0);
    private Image healthImage;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        enemyPos = this.gameObject.transform.parent.parent;
        Debug.Log(enemyPos.name);
        healthBar = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarFollow();
    }
    private void healthBarFollow()
    {
        healthBar.position = enemyPos.position;
        
    }

}
#endif