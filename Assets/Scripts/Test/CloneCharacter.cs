using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CloneCharacter : MonoBehaviour
{
    [SerializeField] List<Transform> Spawnpos = new List<Transform>();
    public GameObject centerObject;
    public float cloneDistance;
    
    //try
    
    public async void MultiplyCharacter(int value, int index)
    {
        Debug.Log("Called From Multiplier OBject");
        for (int i = 0; i < value; i++)
        {
            await Task.Delay(250);
            GameObject clone = ObjectPool.instance.PoolObject(index);
            if (clone != null)
            {
                Debug.Log("Cloning Done");
                // Calculate positions for left and right clones
                Vector3 leftPosition = centerObject.transform.position - centerObject.transform.right * cloneDistance * (i + 1); 
                Vector3 rightPosition = centerObject.transform.position + centerObject.transform.right * cloneDistance * (i + 1);

                // Alternate between left and right positions
                Vector3 spawnPosition = i % 2 == 0 ? leftPosition : rightPosition;

                clone.transform.position = spawnPosition;
                clone.SetActive(true);
            }
        }
    }
}
