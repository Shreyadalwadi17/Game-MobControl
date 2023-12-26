using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    private float val = 0;
    public static FillSlider instance;
    public bool canBossCAll;

    private void Awake()
    {
        slider.value = val;
        instance = this;
    }

    public void slide()
    {
        if (slider.value < 1)
        {
            slider.value += 0.05f;
        }
        else if (slider.value >= 1)
        {
            canBossCAll = true;
            SpawnController.instance.characterSpawn(2);
            Resetvalue();
        }
    }

    void Resetvalue()
    {
        slider.value = 0;
    }
}
