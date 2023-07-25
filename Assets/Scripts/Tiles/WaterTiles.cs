using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTiles : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.GetComponent<PlayerMoveController>().Direction == Vector3.up)
        {
            InputEvents.moveForwardEvent.Invoke();
        }
        if (collision.gameObject.GetComponent<PlayerMoveController>().Direction == Vector3.down)
        {
            InputEvents.moveBackwardEvent.Invoke();
        }
        if (collision.gameObject.GetComponent<PlayerMoveController>().Direction == Vector3.left)
        {
            InputEvents.moveLeftEvent.Invoke();
        }
        if (collision.gameObject.GetComponent<PlayerMoveController>().Direction == Vector3.right)
        {
            InputEvents.moveRightEvent.Invoke();
        }

    }
}
