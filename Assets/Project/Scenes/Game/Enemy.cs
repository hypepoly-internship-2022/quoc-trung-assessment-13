using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    Rigidbody enemyRb;

    float speed = 5f;
    float amplitude = 0.1f;
    string currentPos;

    public enum EnemyState
    {
        Idle,
        Danger,
    }
    EnemyState state;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        currentPos = "Start Point";

    }
    void Start()
    {
        state = EnemyState.Idle;
    }


    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                EnemyIdleState();
                break;
            case EnemyState.Danger:
                EnemyDangerState(currentPos);
                break;
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("EndPoint"))
        {
            state = EnemyState.Idle;
            currentPos = "End Point";
        }
        if (collider.gameObject.CompareTag("StartPoint"))
        {
            state = EnemyState.Idle;
            currentPos = "Start Point";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.Loose();
        }
    }


    void ChangeEnemyColor(EnemyState state)
    {
        if (state == EnemyState.Idle)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (state == EnemyState.Danger)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void EnemyIdleState()
    {
        enemyRb.velocity = Vector3.zero;
        ChangeEnemyColor(EnemyState.Idle);
        Invoke("PlayShakeAnimation", 1f);
    }
    void EnemyDangerState(string currentPos)
    {
        if (currentPos == "Start Point")
        {
            ChangeEnemyColor(EnemyState.Danger);
            enemyRb.velocity = Vector3.right.normalized * speed;
        }
        else if (currentPos == "End Point")
        {
            ChangeEnemyColor(EnemyState.Danger);
            enemyRb.velocity = -Vector3.right.normalized * speed;
        }

    }
    void PlayShakeAnimation()
    {
        float y = amplitude * Mathf.Sin(Time.time * 10);
        transform.position = new Vector3(transform.position.x, y + 0.7f, transform.position.z);
        Invoke("ChangeToDangerState", 1f);

    }
    void ChangeToDangerState()
    {
        state = EnemyState.Danger;
    }
}
