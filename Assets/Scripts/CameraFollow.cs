using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float Value;
    public static CameraFollow inst;

    public static Action OnFollowPlayer;

    private void OnEnable()
    {
        OnFollowPlayer += FollowPlayer;
    }

    private void OnDisable()
    {
        OnFollowPlayer -= FollowPlayer;
    }

    private void Start()
    {
        inst = this;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + Value);
    }

    public void FollowPlayer()
    {
        StartCoroutine(FollowPlayerCorutine());
    }

    IEnumerator FollowPlayerCorutine()
    {
        while (true)
        {
            Debug.LogWarning("FOLLOW PLAYER");

            transform.LookAt(player.transform);
            yield return null;
        }
    }
}
