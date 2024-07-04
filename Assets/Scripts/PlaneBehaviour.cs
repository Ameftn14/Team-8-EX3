using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    public EnemyManager myEnemyManager = null;
    private int myHealth = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (myEnemyManager == null)
            myEnemyManager = GameObject.Find("Manager").GetComponent<EnemyManager>();
        Debug.Assert(myEnemyManager != null);
        // enemyCount is increased here
        myEnemyManager.increaseEnemyCount();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            // change the color of the plane
            Color color = GetComponent<SpriteRenderer>().color;
            color.a -= 0.25f;
            GetComponent<SpriteRenderer>().color = color;

            myHealth--;
            if (myHealth <= 0)
                Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "GreenUp")
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // enemyCount is decreased here
        myEnemyManager.decreaseEnemyCount();
    }
}
