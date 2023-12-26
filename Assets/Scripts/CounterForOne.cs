using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterForOne : MonoBehaviour
{
    public float counter;
    public TMP_Text ShowText;
    public bool isOneDown;

    public GameObject LeftRing1;
    public GameObject LeftRing2;

    public GameObject CenterTrigger;


    private void Start()
    {
        ShowText.text = counter.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {

            if (counter <= 0)
            {
                isOneDown = true;
                LeftRing1.SetActive(false);
                LeftRing2.SetActive(true);
                CenterTrigger.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                counter--;
                ShowText.text = counter.ToString();
                other.gameObject.SetActive(false);

            }
        }
        else if (other.gameObject.CompareTag("BlueBoss"))
        {
            if (counter <= 0)
            {
                isOneDown = true;
                //GameOver.instance.over();
            }
            else
            {
                counter -= 3;
                ShowText.text = counter.ToString();
                other.gameObject.SetActive(false);
            }
        }
    }
}
