using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyExistMax = 10;
    private int enemyCount = 0;
    private int enemyDestroyed = 0;
    public bool isRandomMode = false;
    public void increaseEnemyCount()
    {
        enemyCount++;
    }
    public void decreaseEnemyCount()
    {
        enemyCount--;
        enemyDestroyed++;
    }
    public int getEnemyCount()
    {
        return enemyCount;
    }

    public int getEnemyDestroyed()
    {
        return enemyDestroyed;
    }

    public void createEnemy()
    {
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Plane")) as GameObject;
        Vector3 pos = new Vector3(
            Screen.width * Random.Range(0.05f, 0.95f),
            Screen.height * Random.Range(0.05f, 0.95f),
            0f
        );
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0f;
        enemy.transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < enemyExistMax)
            createEnemy();
        if (Input.GetKeyDown(KeyCode.J))
            isRandomMode = !isRandomMode;
    }
}
