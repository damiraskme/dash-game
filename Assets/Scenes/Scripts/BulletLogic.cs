#if UNITY_EDITOR
using System.Collections;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.collider.name.Equals("Player"))
        {
            Destroy(bullet);
        }
    }
}
#endif