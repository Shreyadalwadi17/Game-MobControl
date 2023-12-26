using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public List<GameObject> PooledObj = new List<GameObject>();
    public List<GameObject> CharacterPooledObj = new List<GameObject>();
    public List<GameObject> EnemyPooledObj = new List<GameObject>();
    [SerializeField] private float PoolAmount;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        for (int i = 0; i < PoolAmount; i++)
        {
            GameObject characterobj = Instantiate(character);
            characterobj.SetActive(false);
            CharacterPooledObj.Add(characterobj);

            GameObject enemyobj = Instantiate(enemy);
            enemyobj.SetActive(false);
            EnemyPooledObj.Add(enemyobj);
        }
    }

    public GameObject GetCharacterObjectPooled()
    {
        for (int i = 0; i < CharacterPooledObj.Count; i++)
        {
            if (!CharacterPooledObj[i].activeInHierarchy)
            {
                return CharacterPooledObj[i];
            }
        }
        return null;
    }

    public GameObject MultiplyPool(int value)
    {
        for (int i = 1; i <= value; i++)
        {
            if (!PooledObj[i].activeInHierarchy)
            {
                return PooledObj[i];
            }
        }
        return null;
    }

    public GameObject GetEnemyObjectPooled()
    {
        for (int i = 0; i < CharacterPooledObj.Count; i++)
        {
            if (!CharacterPooledObj[i].activeInHierarchy)
            {
                return CharacterPooledObj[i];
            }
        }
        return null;
    }
}
