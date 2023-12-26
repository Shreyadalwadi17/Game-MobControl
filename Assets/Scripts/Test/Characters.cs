using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Characters : ScriptableObject
{
    public List<CharacterList> characterList = new();
}

[System.Serializable]
public class CharacterList
{
    public string CharacterName;
    public int numberOfTimes;
    public GameObject prefab;
}