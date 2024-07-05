using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    public EnemyManager myEnemyManager = null;
    private int myHealth = 4;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (myEnemyManager == null)
            myEnemyManager = GameObject.Find("Manager").GetComponent<EnemyManager>();
        Debug.Assert(myEnemyManager != null);
        // enemyCount is increased here
        myEnemyManager.increaseEnemyCount();
        state = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("WayPoint" + state);
        Debug.Assert(target != null);
        Vector3 targetPos = target.transform.position;
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis < 10f)
            if (myEnemyManager.isRandomMode)
                state = Random.Range(0, 6);
            else
                state = (state + 1) % 6;
        target = GameObject.Find("WayPoint" + state);
        targetPos = target.transform.position;
        // Vector3 dir = targetPos - transform.position;
        // dir.Normalize();
        // transform.position += dir * 10f * Time.smoothDeltaTime;
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
