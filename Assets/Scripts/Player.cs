using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Header("Start amount hp from 1 to 2 hp")]
    [Range(1, 2, order = 0)]
    [SerializeField] private int _health = 1;

    [Header("Player Speed from 0.01 to 10f ")]
    [Range(0.01f, 10.0f)]
    [SerializeField] private float _speed = 10f;
    
    private float _step;
    private Camera _cam;
    private Vector2 _target;
    
    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        _step = _speed * Time.deltaTime;
        _target = gameObject.transform.position;
        _cam = Camera.main;
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
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _target, _step);
    }

    //---------------------------------------------------------------------------------------------

    private void OnGUI()
    {
        // Get coordinate
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = _cam.pixelHeight - currentEvent.mousePosition.y;
        point = _cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            _target.x = point.x;
        }

    }
    //---------------------------------------------------------------------------------------------

    // Destroy Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.tag == "Enemy")
        {
            _health -= 1;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    //---------------------------------------------------------------------------------------------
}

