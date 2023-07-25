using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BubbleGum : MonoBehaviour
{
    [SerializeField] GameObject fence;
    [SerializeField] GameObject arrow;
    Tilemap tilemap;

    Queue<KeyCode> keyCodes = new Queue<KeyCode>();

    private int countTrigger = 0;


    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Start()
    {
        countTrigger = 0;
    }


    private void Update()
    {
        UpdateArrowDirection();
    }

    private void UpdateArrowDirection()
    {
        if (keyCodes.Count == 0)
        {
            fence.SetActive(false);
            arrow.SetActive(false);
        }
        else
        {

            KeyCode x = keyCodes.Peek();
            if (x == KeyCode.A)
            {
                arrow.SetActive(true);
                arrow.transform.position = fence.transform.position + new Vector3(0, 1, 0);
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            if (x == KeyCode.D)
            {
                arrow.SetActive(true);
                arrow.transform.position = fence.transform.position + new Vector3(0, 1, 0);
                arrow.transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
            if (x == KeyCode.W)
            {
                arrow.SetActive(true);
                arrow.transform.position = fence.transform.position + new Vector3(0, 1, 0);
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (x == KeyCode.S)
            {
                arrow.SetActive(true);
                arrow.transform.position = fence.transform.position + new Vector3(0, 1, 0);
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
            if (Input.GetKeyDown(x) || x == APKInputHandler.moveKeyCode)
            {
                
                keyCodes.Dequeue();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        countTrigger++;
        if (countTrigger > 1) return;

        int numIterations = Random.Range(1, 5);
        while (numIterations-- > 0)
        {
            int keyInt = Random.Range(0, 4);
            if (keyInt == 0)
            {
                keyCodes.Enqueue(KeyCode.A);
            }
            else if (keyInt == 1)
            {
                keyCodes.Enqueue(KeyCode.D);
            }
            else if (keyInt == 2)
            {
                keyCodes.Enqueue(KeyCode.S);
            }
            else if (keyInt == 3)
            {
                keyCodes.Enqueue(KeyCode.W);
            }
        }
        fence.transform.position = PlayerMoveController.Instant.TargetPositon;
        fence.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        countTrigger = 0;
    }
}