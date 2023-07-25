using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

public class PlayerMoveController : Singleton<PlayerMoveController>
{
    [SerializeField] private float _moveDuration = 0.07f;
    [SerializeField] Tilemap normal, falling; 

    public ContactFilter2D castFilter;

    Rigidbody2D rb;
    CapsuleCollider2D capsuleCol;

    RaycastHit2D[] wallHits = new RaycastHit2D[5];

    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }

        private set
        {
            _isMoving = value;
        }
    }

    private Vector3 _direction;
    public Vector3 Direction
    {
        get
        {
            return _direction;
        }

        private set
        {
            _direction = value;
        }
    }

    private Vector3 _StartPosition;
    public Vector3 StartPositon
    {
        get
        {
            return _targetPosition;
        }

        private set
        {
            _targetPosition = value;

        }
    }

    private Vector3 _targetPosition;
    public Vector3 TargetPositon
    {
        get
        {
            return _targetPosition;
        }

        private set
        {
            _targetPosition = value;

        }
    }

    private bool _isAlive = true;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        private set
        {
            _isAlive = value;
            if (value == false)
            {
                GameEvents.gameOverEvent.Invoke();
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();
    }


    private void Start()
    {
        InputEvents.moveRightEvent.AddListener(OnMoveRightEvent);
        InputEvents.moveLeftEvent.AddListener(OnMoveLeftEvent);
        InputEvents.moveForwardEvent.AddListener(OnMoveForwardEvent);
        InputEvents.moveBackwardEvent.AddListener(OnMoveBackwardEvent);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        InputEvents.moveRightEvent.RemoveListener(OnMoveRightEvent);
        InputEvents.moveLeftEvent.RemoveListener(OnMoveLeftEvent);
        InputEvents.moveForwardEvent.RemoveListener(OnMoveForwardEvent);
        InputEvents.moveBackwardEvent.RemoveListener(OnMoveBackwardEvent);
    }

    private void OnMoveRightEvent()
    {
        if (!IsMoving && CanMoveInDirection(Vector2.right))
        {
            Move(transform.position, transform.position + Vector3.right);
        }
    }

    private void OnMoveLeftEvent()
    {
        if (!IsMoving && CanMoveInDirection(Vector2.left))
        {
            Move(transform.position, transform.position + Vector3.left);
        }
    }

    private void OnMoveForwardEvent()
    {
        if (!IsMoving && CanMoveInDirection(Vector2.up))
        {
           Move(transform.position, transform.position + Vector3.up);
        }
    }

    private void OnMoveBackwardEvent()
    {
        if (!IsMoving && CanMoveInDirection(Vector2.down))
        {
            Move(transform.position, transform.position + Vector3.down);
        }
    }

    private void Move(Vector3 startPosition, Vector3 targetPosition)
    {
        Direction = targetPosition - startPosition;
        StartPositon = startPosition;
        TargetPositon = targetPosition;
        IsMoving = true;
        Tween a = transform.DOMove(targetPosition, _moveDuration);
        a.OnComplete(OnComplete);
        HasPlayerDied();
    }

    private void OnComplete()
    {
        IsMoving = false;
    }

    private bool CanMoveInDirection(Vector2 direction)
    {
        bool canMove = capsuleCol.Cast(direction, castFilter, wallHits, 0.2f) > 0;
        return !canMove;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            IsAlive = false;
        }
    }

    public void HasPlayerDied()
    {
        Vector3Int nomalCellPosition = normal.WorldToCell(TargetPositon);
        Vector3Int fallingCellPosition = falling.WorldToCell(TargetPositon);

        TileBase normalTile = normal.GetTile(nomalCellPosition);
        TileBase fallingTile = falling.GetTile(fallingCellPosition);
        if (normalTile == null && fallingTile == null)
        {
            IsAlive = false;
        }
    } 

}
