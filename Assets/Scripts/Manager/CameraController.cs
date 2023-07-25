using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<CinemachineVirtualCamera>().Follow = PlayerMoveController.Instant.transform;
    }
}
