using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PCInputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeftKey;
    [SerializeField] private KeyCode _moveRightKey;
    [SerializeField] private KeyCode _moveForwardKey;
    [SerializeField] private KeyCode _moveBackwardKey;

    [SerializeField] private KeyCode _exitKey;

    private void Update()
    {
        if (Input.GetKeyDown(_moveLeftKey))
        {
            InputEvents.moveLeftEvent.Invoke();
        }
        if (Input.GetKeyDown(_moveRightKey))
        {
            InputEvents.moveRightEvent.Invoke();
        }
        if (Input.GetKeyDown(_moveForwardKey))
        {
            InputEvents.moveForwardEvent.Invoke();
        }
        if (Input.GetKeyDown(_moveBackwardKey))
        {
            InputEvents.moveBackwardEvent.Invoke();
        }

        if (Input.GetKeyDown(_exitKey))
        {
            InputEvents.exitEvent.Invoke();
        }
    }
}

