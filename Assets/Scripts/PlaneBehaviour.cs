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
    Vector3 getTargetWaypointPosition(string waypointName) {
        GameObject waypoint = GameObject.Find(waypointName);
        return waypoint.transform.localPosition;
    }

    void flyTowardsWaypoint(Vector3 targetPosition) {
        // configs: {
        float speed = 20.0f;
        float rotationSpeed = 0.5f;
        // }

        // lerp towards the target position
        Vector3 direction = targetPosition - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, direction, rotationSpeed * Time.smoothDeltaTime);

        // move the plane towards the target position
        transform.localPosition += transform.up * speed * Time.smoothDeltaTime;
    }

    void Update()
    {
        
        string waypointName = "Waypoint1"; // TODO get name based on the state machine
        Vector3 targetPosition = getTargetWaypointPosition(waypointName);
        // TODO state machine updates

        flyTowardsWaypoint(targetPosition);
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
