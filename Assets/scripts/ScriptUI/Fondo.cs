using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _startposition;

    public float speed;
    private int xdirection = -1;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _startposition = transform.position;
    }
    void Update()
    {
        EscenaMove();
    }
    void EscenaMove()
    {
        _transform.position = new Vector2(
            _transform.position.x + xdirection * speed * Time.deltaTime,
            _transform.position.y
            );

        if (_transform.position.x < -17.8)
        {
            _transform.position = _startposition;
        }
    }
}
