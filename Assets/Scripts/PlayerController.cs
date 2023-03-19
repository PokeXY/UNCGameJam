using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

// Credit to SamYam, August 13th, 2020.
// https://youtu.be/YnwOoxtgZQI

public class PlayerController : MonoBehaviour
{
    // access it in the editor
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap obstacleTilemap;

    Vector2 lastDirection = Vector2.zero;
    Vector2 direction = Vector2.zero;

    public Animator anim;
    private Vector2 moveInput;

    private PlayerMovement controls;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerMovement();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        
    }

    private void Move(Vector2 direction)
    {
        if(CanMove(direction))
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);



        if (!groundTilemap.HasTile(gridPosition) || obstacleTilemap.HasTile(gridPosition) || lastDirection == direction)
        {

            return false;

        }
        else
        {

            if (direction != Vector2.zero)
            {
                anim.SetFloat("MoveX", direction.x);
                anim.SetFloat("MoveY", direction.y);
                lastDirection = direction * -1;
            }
            return true;
        }

    }
}
