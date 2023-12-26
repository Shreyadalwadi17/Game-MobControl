using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAttract : MonoBehaviour
{
    public List<GameObject> Door = new List<GameObject>();
    public static HouseAttract inst;

    private void Start()
    {
        inst = this;
    }
}
