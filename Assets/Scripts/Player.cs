using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Header("Start amount hp from 1 to 2 hp")]
    [Range(1, 2, order = 0)]
    [SerializeField] private int health = 1;

    [Header("Player Speed from 0.01 to 10f ")]
    [Range(0.01f, 10.0f)]
    [SerializeField] private float speed = 10f;

    private float step;
    Camera cam;
    Vector2 target;

    //---------------------------------------------------------------------------------------------
    private void Start()
    {
        step = speed * Time.deltaTime;
        target = transform.position;
        cam = Camera.main;
    }

    //---------------------------------------------------------------------------------------------
    private void Update()
    {
        MovePlayer();
    }

    //---------------------------------------------------------------------------------------------
    private void MovePlayer()
    {
        // Movement Player
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    //---------------------------------------------------------------------------------------------
    private void OnGUI()
    {
        // Install mouse click to point
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        // Install target for movement
        if (Input.GetMouseButtonDown(0))
        {
            target.x = point.x;
        }
    }
    //---------------------------------------------------------------------------------------------

    //TODO Player Colission System
    private void OnTriggerEnter2D(Collider2D collision)
    { 
    
    }
    //---------------------------------------------------------------------------------------------
}

