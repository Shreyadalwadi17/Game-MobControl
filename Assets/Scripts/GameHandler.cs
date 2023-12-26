using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    //refrence
    public CounterForOne cOfOne;
    public CounterForTwo cOfTwo;

    public List<GameObject> Doors = new List<GameObject>();


    private void Awake()
    {
        instance = this;
    }

    public void RemoveElemnt()
    {
        GameObject currentRocket = Doors[0];
        Doors.Remove(currentRocket);
    }

    private void Update()
    {
        if(cOfOne.isOneDown && cOfTwo.isBothDown)
        {
            GameOver.instance.over();
            Debug.Log("Game Over Called");
        }
    }

}
