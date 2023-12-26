using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class MultiplyObjs : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] TextMeshPro multiply;
    public static MultiplyObjs instance;

    public GameObject centerObject;
    private float cloneDistance = 0.039f;

   
    private void Awake()
    {
        instance = this;
        multiply.text = "X" + number;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            
            MultiplyCharacter(number, 0);
        }

        if (other.CompareTag("BlueBoss"))
        {
            MultiplyCharacter(number, 2);
        }
    }

    public async void MultiplyCharacter(int value, int index)
    {
        for (int i = 0; i < value; i++)
        {
            await Task.Delay(250);
            GameObject clone = ObjectPool.instance.PoolObject(index);
            if (clone != null)
            {
                Vector3 leftPosition = centerObject.transform.position - centerObject.transform.right * cloneDistance * (i + 1);
                Vector3 rightPosition = centerObject.transform.position + centerObject.transform.right * cloneDistance * (i + 1);

                Vector3 spawnPosition = i % 2 == 0 ? leftPosition : rightPosition;

                clone.transform.position = spawnPosition;
                clone.SetActive(true);
            }
        }
    }
}
    
 /*   [SerializeField] int number;
    [SerializeField] TextMeshPro multiply;
    [SerializeField] List<Transform> Spawnpos = new List<Transform>();
    public static MultiplyObjs instance;

    private void Awake()
    {
        instance = this;
        multiply.text = "X" + number;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            MultiplyCharacter(number, 0);
        }

        if(other.CompareTag("BlueBoss"))
        {
            MultiplyCharacter(number, 2);
        }
      
    }

    public async void MultiplyCharacter(int value, int index)
    {
        for (int i = 0; i < value; i++)
        {
            await Task.Delay(250);
            GameObject clone = ObjectPool.instance.PoolObject(index);
            if (clone != null)
            {
                clone.transform.position = Spawnpos[i].position;
                clone.SetActive(true);
            }
        }
    }
}
*/