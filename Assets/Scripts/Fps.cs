using System.Collections;
using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    private float count;
    [SerializeField] TextMeshProUGUI fpsText;
    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5, 40, 100, 25), "FPS: " + Mathf.Round(count));
        fpsText.text = "Fps :"+count.ToString("#");
    }
}
