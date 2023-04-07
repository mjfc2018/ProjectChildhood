using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
	Camera _camera = null;
    
    [SerializeField]
    PlayerInput _playerInput = null;

    [SerializeField]
    float _horizontalSpeed = 0.8f;

    [SerializeField]
    float _verticalSpeed = 0.01f;

    private float _verticalSpeedMax = 0.032f;
    private float _verticalSpeedMin = 0.003f;

    Vector3 _spriteHalfSize;
    Vector2 _cameraHalfSize;

    InputAction _steeringInput;
    InputAction _shootInput;

    [SerializeField]
    GameObject _bulletPrefab;

    public float bulletSpeed = 1.8f;
    private bool bulletFired = false;

    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        _steeringInput = _playerInput.actions["SteerFighter"];
        _shootInput = _playerInput.actions["Shoot"];

        _spriteHalfSize = GetComponent<SpriteRenderer>().sprite.bounds.extents;
		_spriteHalfSize.Scale(transform.localScale);
		_cameraHalfSize = new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 steering = _steeringInput.ReadValue<Vector2>();

        // Increase the speed of the scrooling (up key)
        if (steering.y > 0 && _verticalSpeed <= _verticalSpeedMax)
        {
            _verticalSpeed += 0.0008f;
            bulletSpeed += _verticalSpeed;
        }

        // Decrease the speed of the scrooling (down key)
        if (steering.y < 0 && _verticalSpeed >= _verticalSpeedMin)
        {
            _verticalSpeed -= 0.0008f;
            bulletSpeed -= _verticalSpeed;
        }

        // Up and Down should affect only the speed, and not compose
        // "delta" calculation.
        if ( Mathf.Abs(steering.y) != 0f)
        {
            steering.y = 0f;
        }

        Vector3 delta = _horizontalSpeed * steering * Time.deltaTime;
        Vector2 currPosition = transform.position;
        
        // Move the airplane only on the horizontal
        if ( Mathf.Abs(steering.x) > 0 && Mathf.Abs(steering.y) == 0 )
        {
            Vector2 newPosition = transform.position + delta;
            if (Mathf.Abs(newPosition.x) > (_cameraHalfSize.x - _spriteHalfSize.x / 2))
            {
                newPosition.x = transform.position.x;
            }
           
            currPosition = newPosition;
        }

        currPosition.y += _verticalSpeed;
        rb.MovePosition(currPosition);

        if ( _shootInput.ReadValue<float>() == 1.0f ) {
            if(bulletFired == false) {
                GameObject bullet = Instantiate(_bulletPrefab);
                bullet.transform.SetParent(transform.parent);
                bullet.transform.position  = transform.position;

                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                Destroy(bullet, 4f);
                bulletFired = true;
                Invoke("WaitTime", 0.3f);
            }
            
        }
    }

    void WaitTime()
    {
        bulletFired = false;
    }
}
