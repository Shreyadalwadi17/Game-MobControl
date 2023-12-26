using TMPro;
using UnityEngine;

public class CounterForTwo : MonoBehaviour
{
    public float counter;
    public TMP_Text ShowText;
    public bool isBothDown;

    public GameObject RightRing1;
    public GameObject RightRing2;

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
                isBothDown = true;
                RightRing1.SetActive(false);
                RightRing2.SetActive(true);
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
                isBothDown = true;
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
