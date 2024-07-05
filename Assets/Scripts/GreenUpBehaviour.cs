using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUpBehaviour : MonoBehaviour
{
    public bool myHeroControlByMouse = true;
    public float myHeroSpeed = 20f;
    public float myHeroRotationSpeed = 45f;
    public EggManager myEggManager = null;

    private int touchedEnemyCount = 0;

    public int getTouchedEnemyCount()
    {
        return touchedEnemyCount;
    }

    public string driveBy()
    {
        if (myHeroControlByMouse)
            return "Mouse";
        else
            return "Keyboard";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (myEggManager == null)
            myEggManager = GameObject.Find("Manager").GetComponent<EggManager>();
        Debug.Assert(myEggManager != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.M))
            myHeroControlByMouse = !myHeroControlByMouse;

        if (myHeroControlByMouse)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                myHeroSpeed += 0.5f;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                myHeroSpeed -= 0.5f;
            transform.localPosition += transform.up * myHeroSpeed * Time.smoothDeltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(transform.forward, myHeroRotationSpeed * Time.smoothDeltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(transform.forward, -myHeroRotationSpeed * Time.smoothDeltaTime);

        if (Input.GetKey(KeyCode.Space))
            myEggManager.createEgg(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            // prevent the same enemy to be counted as touched multiple times
            Destroy(collision.gameObject);
            // actually, this can be done in EnemyManager and use a function to increase the count
            // but for convenience, we do it here
            touchedEnemyCount++;
        }
    }
}
