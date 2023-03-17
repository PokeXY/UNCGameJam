using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Credit to SamYam, August 13th, 2020.
// https://youtu.be/YnwOoxtgZQI

public class PlayerController : MonoBehaviour
{
    // access it in the editor
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap obstacleTilemap;

    private PlayerMovement controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerMovement();
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

        if(!groundTilemap.HasTile(gridPosition) || obstacleTilemap.HasTile(gridPosition))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
