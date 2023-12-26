using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody rb;
    public Animator animator;
    public bool ismovingForward;
    public float actionspeed;

    void Start()
    {
        rb.velocity = (Vector3.forward * -speed);
        animator.Play(0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("enemyout"))
           {
               Time.timeScale = 0;
               CannonMovementScript.instance.panel.SetActive(true);
           }
    }
}
