using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public float ColdDownTime = 0.2f;
    private int eggCount = 0;
    private float currentColdDownTime = 0.0f;
    public void increaseEggCount()
    {
        eggCount++;
    }

    public void decreaseEggCount()
    {
        eggCount--;
    }

    public int getEggCount()
    {
        return eggCount;
    }

    public bool isColdDown()
    {
        return currentColdDownTime <= 0.0f;
    }

    // Create an egg at the hero's position
    public void createEgg(GreenUpBehaviour hero)
    {
        if (isColdDown())
        {
            currentColdDownTime = ColdDownTime;
            GameObject egg = Instantiate(Resources.Load("Prefabs/Egg")) as GameObject;
            // eggCount is increased by EggBehaviour.Start()
            egg.transform.position = hero.transform.position;
            egg.transform.rotation = hero.transform.rotation;
        }
        else
            Debug.Log("Ask for egg when it is not ready");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentColdDownTime > 0.0f)
            currentColdDownTime -= Time.deltaTime;
    }
}
