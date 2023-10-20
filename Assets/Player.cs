using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float destroyDelay = 0.01f;

    private float originalMoveSpeed;

    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            StartCoroutine(BoostForDuration(boostSpeed, 1f));
            Destroy(other.gameObject, destroyDelay);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(SlowDownForDuration(slowSpeed, 1f));
    }
    
    IEnumerator BoostForDuration(float newSpeed, float duration)
    {
        moveSpeed = newSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
    }
    
    IEnumerator SlowDownForDuration(float newSpeed, float duration)
    {
        moveSpeed = newSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
