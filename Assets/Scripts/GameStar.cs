using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStar : MonoBehaviour
{
    public List<GameObject> Gamelevel = new List<GameObject>();
    public int Number;

     
    public static GameStar instance;

    private void Awake()
    {
        instance = this;
    }

    public void counterplus()
    {
        Gamelevel[Number].gameObject.SetActive(true);
        Gamelevel[Number-1].gameObject.SetActive(false);

    }
   
}
