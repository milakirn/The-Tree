using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private float _moveX;
    private float _moveY;
    public float speed;
    public float gravity;

    private bool _isGround = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _movement.x = _moveX * speed;

    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement;
        if (_isGround)
        {
            _rb.AddForce(transform.up * gravity);
            _isGround = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log($"Collide with {other.gameObject.name}");
            _isGround = true;
        }

    }
}