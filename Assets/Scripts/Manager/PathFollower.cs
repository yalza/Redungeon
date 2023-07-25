using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] float delay = 0f;
    [SerializeField] float speed = 0f;
    int cnt = 0;

    private Vector3 startPos;
    private Vector3 nextPos;
    private Vector3 direction;
    private bool canMove = true;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPos = points[cnt];
        transform.position = startPos;
        nextPos = points[cnt + 1];
    }


    private void Update()
    {
        Move();
    }


    private void Move()
    {
        if (!canMove)
        {
            rb.velocity = Vector3.zero;

        }
        else
        {
            direction = (nextPos - startPos).normalized;
            rb.velocity = direction * speed;
            if (Vector3.Distance(transform.position, nextPos) <= 0.1f)
            {
                transform.position = nextPos;
                if (cnt == points.Length - 2)
                {
                    startPos = points[points.Length - 1];
                    nextPos = points[0];
                    cnt++;
                }
                else if (cnt == points.Length - 1)
                {
                    startPos = points[0];
                    nextPos = points[1];
                    cnt = 0;
                }
                else
                {
                    cnt++;
                    startPos = points[cnt];
                    nextPos = points[cnt + 1];
                }
                StartCoroutine(Delay());
            }
        }
    }


    private IEnumerator Delay()
    {
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
