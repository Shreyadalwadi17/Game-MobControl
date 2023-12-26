using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;
    [SerializeField] Character character;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] Enemy enemy;
    [SerializeField] List<Transform> enemySpawnPosition;

    private void Awake()
    {
        instance = this;
    }

    public void characterSpawn(int value)
    {
        GameObject character = ObjectPool.instance.PoolObject(value);
        if (character != null)
        {
            character.transform.position = SpawnPosition.position;
            character.SetActive(true);
        }
    }


}