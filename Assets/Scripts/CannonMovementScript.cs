using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CannonMovementScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static CannonMovementScript instance;

    //for Cannon
    [SerializeField] Rigidbody Cannon;
    [SerializeField] float MoveSpeed;
    private Vector2 MoveVector = Vector2.zero;

    //For Position
    Vector3 currentPos;
    public bool isMoveingHorizontal;
    public float time;
    public GameObject panel;
    public IEnumerable StopObject;
    //for Input
    private CustomControl input = null;

    private void Awake()
    {
        instance = this;
        input = new CustomControl();
        
    }

    public void OnEnable()
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
        //StartCoroutine("CallCoroutine");
    }

    private void FixedUpdate()
    {
        Cannon.velocity = MoveVector * MoveSpeed * Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData a)
    {
        StartCoroutine("CallCoroutine");
    }

    public void OnPointerUp(PointerEventData a)
    {
        StopCoroutine("CallCoroutine");
    }

    private void OnMouseDown()
    {
        StartCoroutine("CallCoroutine");
    }

    private void OnMouseUp()
    {
        StopCoroutine("CallCoroutine");
    }

    IEnumerator CallCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(.7f);
            SpawnController.instance.characterSpawn(0);
            FillSlider.instance.slide();

        }
    }

    public IEnumerator Player()
    {
        if (isMoveingHorizontal)
        {
            float counter = 0;
            while (counter < time)
            {
                counter += Time.deltaTime;
                currentPos = transform.position;
                float times = Vector3.Distance(currentPos, GameOver.instance.MoveTowards.position) / (time - counter) * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, GameOver.instance.MoveTowards.position, times);
                yield return null;
            }
            isMoveingHorizontal = false;
        }
    }
}