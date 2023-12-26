using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private int _numberOfEachObject;
    [SerializeField] Characters characterSO;

    public List<PooledCharacters> pooledData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CreateObjects();
    }

    public void CreateObjects()
    {
        pooledData = new List<PooledCharacters>();

        GameObject tmp;

        for (int i = 0; i < characterSO.characterList.Count; i++)
        {
            PooledCharacters newPooledCharacter = new PooledCharacters();

            for (int j = 0; j < characterSO.characterList[i].numberOfTimes; j++)
            {
                tmp = Instantiate(characterSO.characterList[i].prefab);
                tmp.SetActive(false);

                newPooledCharacter.pooledObjects.Add(tmp);
            }

            pooledData.Add(newPooledCharacter);
        }
    }

    public GameObject PoolObject(int i)
    {
        for (int j = 0; j < pooledData[i].pooledObjects.Count; j++)
        {
            if (!pooledData[i].pooledObjects[j].activeInHierarchy)
            {
                return pooledData[i].pooledObjects[j];
            }
        }
        return null;
    }
}

[System.Serializable]
public class PooledCharacters
{
    public List<GameObject> pooledObjects = new();
}
