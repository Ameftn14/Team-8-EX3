using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointBehaviour : MonoBehaviour
{
       private int mNumHit = 0;
    private const int kHitsToDestroy = 4;
    private const float kEnemyEnergyLost = 0.25f;

    private Vector3 center = new Vector3(0,0,0);
    private float offsetRange = 15.0f;

    private Color originalColor;
    // Start is called before the first frame update

    private bool isHidden = false;

    private void Awake()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isHidden = !isHidden;
            
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = !isHidden;
            }
        }
    }

    #region Trigger into chase or die

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.name == "Egg(Clone)" && isHidden == false)
        {
            mNumHit++;
            if (mNumHit < kHitsToDestroy)
            {
                Color c = GetComponent<Renderer>().material.color;
                c.a = c.a * kEnemyEnergyLost;
                GetComponent<Renderer>().material.color = c;
            }
            else
            {
                Debug.Log(transform.name + "changed");
                mNumHit = 0;
                GetComponent<Renderer>().material.color = originalColor;
                //change position
                float randomX = Random.Range(center.x - offsetRange, center.x + offsetRange);
                float randomY = Random.Range(center.y - offsetRange, center.y + offsetRange);

                transform.position = new Vector3(randomX, randomY, center.z);
            }
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
