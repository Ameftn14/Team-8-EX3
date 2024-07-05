using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour
{
    private const float myEggSpeed = 40f;
    public EggManager myEggManager = null;
    // Start is called before the first frame update
    void Start()
    {
        myEggManager = GameObject.Find("Manager").GetComponent<EggManager>();
        Debug.Assert(myEggManager != null);
        // eggCount is increased here
        myEggManager.increaseEggCount();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.up * myEggSpeed * Time.smoothDeltaTime;
        Vector3 leftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        if (transform.localPosition.x < leftBottom.x || transform.localPosition.x > rightTop.x ||
            transform.localPosition.y < leftBottom.y || transform.localPosition.y > rightTop.y)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.tag == "WayPoint"
        if (collision.gameObject.tag == "Plane")
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // eggCount is decreased here
        myEggManager.decreaseEggCount();
    }
}
