using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{   
    public float speed;    
    public Rigidbody rb;
    public Animator animator;
    public float totalTime;
    public bool ismovingForward;
    public float actionspeed;

    void Start()
    {
        animator.Play(0);
        ismovingForward = true;
    }

    private void Update()
    {
        if (ismovingForward)
        {
         rb.velocity = Vector3.forward * speed;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RaycastHit leftHit;
            RaycastHit rightHit;           

            bool MoveLeft = !Physics.Raycast(transform.position, -transform.right, out leftHit, .2f);
            bool MoveRight = !Physics.Raycast(transform.position, transform.right, out rightHit, .2f);

            if (MoveLeft)
            {
                ismovingForward = false;               
                rb.velocity = Vector3.left * actionspeed;
            }

           else if (MoveRight)
            {
                ismovingForward = false;               
                rb.velocity = Vector3.right * actionspeed;                
            }               
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ismovingForward = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ring"))
        {
            StartCoroutine("MoveToHome");
        }

        if (other.gameObject.CompareTag("ring1"))
        {
            StartCoroutine("MoveToHome2");
        }      
    }

    private IEnumerator MoveToHome()
    {
        Vector3 start = transform.position;
        Vector3 target = GameHandler.instance.Doors[0].transform.position;
        float startTime = Time.time;

        while (transform.position != target )
        {
            float distance = (Time.time - startTime) *speed;
            float Length =  Vector3.Distance(start, target);
            float fractionOfJourney = distance / Length;

            transform.position = Vector3.Lerp(start, target, fractionOfJourney);

            if (!GameHandler.instance.Doors[0].gameObject.activeInHierarchy)
                break;
            yield return null;
        }
    }

    private IEnumerator MoveToHome2()
    {
        Vector3 start = transform.position;
        Vector3 target = GameHandler.instance.Doors[1].transform.position;
        float startTime = Time.time;

        while (transform.position != target)
        {
            float distance = (Time.time - startTime) * speed;
            float Length = Vector3.Distance(start, target);
            float fractionOfJourney = distance / Length;

            transform.position = Vector3.Lerp(start, target, fractionOfJourney);
            if (!GameHandler.instance.Doors[1].gameObject.activeInHierarchy)
                break;
            yield return null;
        }
    }
    //IEnumerator MoveTowardsEnemyHouse()
    //{
    //    float time = 0;       
    //    while (time < totalTime)
    //    {
    //       time += Time.deltaTime;
    //       Vector3 currentPos = transform.position;
    //       float Clock = Vector3.Distance(currentPos, GameOver.instance.Door.transform.position) / (totalTime - time) * Time.deltaTime;
    //       transform.position = Vector3.MoveTowards(transform.position, GameOver.instance.Door.transform.position, Clock);
    //       yield return null;
    //    }
    //}



    //IEnumerator MoveTowardsEnemyHouse1()
    //{
    //    float time = 0;
    //    while (time < totalTime)
    //    {
    //        time += Time.deltaTime;
    //        Vector3 currentPos = transform.position;
    //        float Clock = Vector3.Distance(currentPos, GameOver.instance.Door1.transform.position) / (totalTime - time) * Time.deltaTime;
    //        transform.position = Vector3.MoveTowards(transform.position, GameOver.instance.Door1.transform.position, Clock);
    //        yield return null;
    //    }
    //}
}