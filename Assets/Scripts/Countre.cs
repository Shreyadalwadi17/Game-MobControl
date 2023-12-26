using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countre : MonoBehaviour
{
    public int Count;
    public TMP_Text ShowNumber;

    private void Start()
    {
        ShowNumber.text = Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {

            if (Count <= 1)
            {
                GameOver.instance.over();
                
            }
            else
            {
            Count--; 
            ShowNumber.text = Count.ToString();
            other.gameObject.SetActive(false);

            }
        }
        else if (other.gameObject.CompareTag("BlueBoss"))
        {
            if (Count <= 1)
            {
                GameOver.instance.over();
            }
            else
            {
                Count -= 3;
                ShowNumber.text = Count.ToString();
                other.gameObject.SetActive(false);
            }
        }
        
       

    }    
}