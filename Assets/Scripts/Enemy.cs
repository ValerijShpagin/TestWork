using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Current speed")]
    [SerializeField] private float _normalSpeed = 0.5f;
    [Header("Modified speed")]
    [SerializeField] private float _increaseSpeed = 2.0f;

    private MeshCollider _quad;
    private float _borderMin;
    private SpawnerEnemy _spawnerEnemy;

    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        _quad = GameObject.FindGameObjectWithTag("Quad").GetComponent<MeshCollider>();
        _spawnerEnemy = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnerEnemy>();
        _borderMin = _quad.bounds.min.y;
        InvokeRepeating("ChangeSpeed", 5.0f, 5.0f);
    }

    //---------------------------------------------------------------------------------------------

    private void Update()
    {
        // Check distance for destroy gameObjects
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), 
            new Vector2(transform.position.x, _borderMin )) < 0.01f)
        {
            _spawnerEnemy.DestroyObjects();
            _spawnerEnemy.SpawnObjects();
        }

        else
        {
            Move();
        }
    }

    //---------------------------------------------------------------------------------------------

    private void ChangeSpeed()
    {
         _normalSpeed = _increaseSpeed;
    }

    //---------------------------------------------------------------------------------------------

    private void Move()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _normalSpeed, Space.World);
    }

    //---------------------------------------------------------------------------------------------
}
