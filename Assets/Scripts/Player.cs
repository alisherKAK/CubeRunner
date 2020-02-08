using UnityEngine;
using UnityEngine.UI;

public enum Directions
{
    Left,
    Right,
    Forward,
    Backward
}

public class Player : MonoBehaviour
{
    private Directions _currentDirection;

    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed, _sideSpeed, _speedBoostByCoins;

    [SerializeField]
    private int _coins;

    [SerializeField]
    private GameManager _gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        _coins = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey("a"))
        {
            _rb.AddForce(-_sideSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
            _currentDirection = Directions.Left;
        }
        else if(Input.GetKey("d"))
        {
            _rb.AddForce(_sideSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
            _currentDirection = Directions.Right;
        }
        else if(Input.GetKey("w"))
        {
            _rb.AddForce(0, 0, _speed * Time.deltaTime, ForceMode.Impulse);
            _currentDirection = Directions.Forward;
        }
        else if(Input.GetKey("s"))
        {
            _rb.AddForce(0, 0, -_speed * Time.deltaTime, ForceMode.Impulse);
            _currentDirection = Directions.Backward;
        }
 
        if(transform.position.y < -10)
        {
            _gameManager.GameOver(_coins);
        }
        else if(transform.position.z > 90)
        {
            _gameManager.WinGame(_coins);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger hit" + other.tag);

        if(other.tag == "Coin")
        {
            _coins++;
            Destroy(other.gameObject);

            if(_coins % 3 == 0)
            {
                _speed += _speedBoostByCoins;
            }
        }

        if(other.gameObject.tag == "AcceleratingPlane")
        {
            var acceleratingPanel = other.gameObject.GetComponent<AcceleratingPanel>();
            int accelerationCount = (int)(acceleratingPanel.GetAccelerationTime() / Time.deltaTime);
            float acceleration = acceleratingPanel.GetAcceleration();
            
            for(int i = 0; i < accelerationCount; i++)
            {
                if(_currentDirection == Directions.Left)
                {
                    _rb.AddForce(-(_speed + acceleration) * Time.deltaTime, 0, 0, ForceMode.Impulse);
                }
                else if(_currentDirection == Directions.Right)
                {
                    _rb.AddForce((_speed + acceleration) * Time.deltaTime, 0, 0, ForceMode.Impulse);
                }
                else if(_currentDirection == Directions.Forward)
                {
                    _rb.AddForce(0, 0, (_speed + acceleration) * Time.deltaTime, ForceMode.Impulse);
                }
                else if(_currentDirection == Directions.Backward)
                {
                    _rb.AddForce(0, 0, -(_speed + acceleration) * Time.deltaTime, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Collision hit" + other.gameObject.name);

        if(other.gameObject.tag == "Wall")
        {
            this.enabled = false;
            _gameManager.GameOver(_coins);
        }
    }
}
