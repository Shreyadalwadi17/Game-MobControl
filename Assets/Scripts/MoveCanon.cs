using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanon : MonoBehaviour
{ 
    public Rigidbody rb;
    public float speed;
    //public bool IsMove;
    public float time;
    public GameObject canon;
    public float duration;

    private void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        PlayerMove();


    }

    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            //IsMove = false;
            StartCoroutine(PlayerMovefromOnePoint());
        }
    }


    //void AngleSetTowardsNextRing()
    //{
    //    Vector3 dir = (target.transform.position - canon.transform.position).normalized;
    //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    //    canon.transform.eulerAngles = Vector3.forward * angle;
    //}

    IEnumerator PlayerMovefromOnePoint()
    {
        Vector3 startPos = canon.transform.position;
        Vector3 target = new Vector3(0.72f, 0.26f, 4.88f);
        float time = 0f;
        while (time < duration)
        {
            canon.transform.position = Vector3.Lerp(startPos, target, time );
            time += Time.deltaTime;
           // AngleSetTowardsNextRing();

            yield return null;
        }
        //IsMove = true;
        //canon.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }
}


 