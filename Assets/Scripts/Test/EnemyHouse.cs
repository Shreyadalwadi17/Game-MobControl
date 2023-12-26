using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHouse : MonoBehaviour
{
    [SerializeField] Vector3 minPos,maxPos;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnenemyContinue(Random.Range(1, 5));
        }
    }

    //private void SpawnenemyContinue(int value)
    //{
    //    for (int i = 0; i < value; i++)
    //    {
    //        GameObject clone = ObjectPool.instance.PoolObject(1);
    //        if (clone != null)
    //        {
    //            clone.transform.position = SpawnPos[i].position;
    //            clone.SetActive(true);
    //            print("clone Done");
    //        }
    //    }
    //}

    private void SpawnenemyContinue(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Vector3 Randpos = new Vector3(Random.Range(minPos.x, maxPos.x), minPos.y, Random.Range(minPos.z, maxPos.z));
            

            GameObject clone = ObjectPool.instance.PoolObject(1);
            if (clone != null)
            {
                clone.transform.position = Randpos;
                clone.SetActive(true);
            }
        }
    }
}
