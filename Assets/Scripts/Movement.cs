 using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{

}



/*
 * 
 * old one
 * 
 * 
 *  //for Cannon
    [SerializeField] Rigidbody Cannon;
    [SerializeField] float MoveSpeed;
    private Vector2 MoveVector = Vector2.zero;

    //for Input 
    private CustomControl input = null;

    //for Slider
    [SerializeField] const float slidermaxval = 0.1f;
    [SerializeField] Slider slider;
    public static CannonMovementScript instance;
    private float val;

    private void Awake()
    {
        instance = this;
        input = new CustomControl();
        val = slidermaxval;
    }
   
    private void OnEnable()
    {
        input.Enable();
        input.Cannon.Movement.performed += OnMovementPerformed;
        input.Cannon.Movement.canceled += OnMovementPerformed;
    }

    public void OnDisable()
    {
        input.Disable();
        input.Cannon.Movement.performed -= OnMovementPerformed;
        input.Cannon.Movement.canceled -= OnMovementPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext Value)
    {
        MoveVector = Value.ReadValue<Vector2>();

        slide();
        SpawnController.instance.characterSpawn();
    }

    private void FixedUpdate()
    {
        Cannon.velocity = MoveVector * MoveSpeed;
    }

    private void slide()
    {
        slider.value = val;
        if (val <= 0)
        {
            val = 0;
        }
        else
        {
            val += Time.deltaTime;
        }
    }
}
*/