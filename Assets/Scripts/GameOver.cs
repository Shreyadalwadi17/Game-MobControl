using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public List<GameObject> ToSetFalse = new List<GameObject>();
    public Transform MoveTowards;    
    //public Transform Door;
    //public Transform Door1;
    public int count;
    private int Counter = 2;

    //try
   // public Transform[] homes;

    private void Awake()
    {
        instance = this;
    }

    private void MultiplyCharacterDisable()
    {
        DisableCall(0);
        DisableCall(1);
        DisableCall(2);
    }

    void DisableCall(int value)
    {
        for (int i = 0; i < ObjectPool.instance.pooledData[value].pooledObjects.Count; i++)
        {
            GameObject clone = ObjectPool.instance.pooledData[value].pooledObjects[i];
            if (clone != null)
            {
                clone.SetActive(false);
            }
        }
    }



    public async void over()
    {
        MultiplyCharacterDisable();
        CannonMovementScript.instance.StopAllCoroutines();
        await MyFunction();       
        StartCoroutine(levelload());        
        CannonMovementScript.instance.isMoveingHorizontal = true;
        CannonMovementScript.instance.StartCoroutine(CannonMovementScript.instance.Player());
       
    }

    async Task MyFunction()
    {       
        await Task.Delay(250);
        MultiplyCharacterDisable();
        await Task.Delay(250);
        CannonMovementScript.instance.OnDisable();
        MultiplyCharacterDisable();
        await Task.Delay(250);
        foreach (var item in ToSetFalse)
        {
            item.SetActive(false);
        }
        MultiplyCharacterDisable();
        await Task.Delay(500);     
    }

    IEnumerator levelload()
    {
        yield return new WaitForSeconds(Counter);      
        GameStar.instance.Number++;
        GameStar.instance.counterplus();
        CannonMovementScript.instance.OnEnable();
        MultiplyCharacterDisable();
        GameHandler.instance.RemoveElemnt();
    }
}   