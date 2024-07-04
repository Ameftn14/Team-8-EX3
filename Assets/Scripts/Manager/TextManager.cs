using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text text = null;
    public GreenUpBehaviour myHeroBehaviour = null;
    public EnemyManager myEnemyManager = null;
    public EggManager myEggManager = null;
    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
            text = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>();
        if (myHeroBehaviour == null)
            myHeroBehaviour = GameObject.Find("GreenUp").GetComponent<GreenUpBehaviour>();
        if (myEnemyManager == null)
            myEnemyManager = GameObject.Find("Manager").GetComponent<EnemyManager>();
        if (myEggManager == null)
            myEggManager = GameObject.Find("Manager").GetComponent<EggManager>();
        Debug.Assert(text != null);
        Debug.Assert(myHeroBehaviour != null);
        Debug.Assert(myEnemyManager != null);
        Debug.Assert(myEggManager != null);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "\tHERO: Drive(" + myHeroBehaviour.driveBy() + ") TouchedEnemy(" + myHeroBehaviour.getTouchedEnemyCount() + ")" +
                    "\tEGG: OnScreen(" + myEggManager.getEggCount() + ")" +
                    "\tENEMY: Count(" + myEnemyManager.getEnemyCount() + ") Destroyed(" + myEnemyManager.getEnemyDestroyed() + ")";
    }
}
