using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] Es para hacelo "publico" sin serlo, para poder modificarlo desde el inspector en unity.
    [SerializeField] private int _maxHealth = 10; //int para guardar la vida maxima
    

    private Rigidbody2D _rbody;
    [SerializeField] private float _movementSpeed = 5f;

    private InputAction _moveAction;
    private Vector2 _moveInput;

    private InputAction _jumpAction;
    [SerializeField] private float _jumpHeight = 5f;

    [SerializeField] private float _sensorSize = 1f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundSensor;

    


    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }

    
    void Start()
    {
        
    }


    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump(); 
        }
    }
    void FixedUpdate()
    {
       _rbody.linearVelocity = new Vector2(_movementSpeed * _moveInput.x, _rbody.linearVelocity.y);
    }
    void Jump()
    {
        _rbody.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
    }
    bool IsGrounded()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorSize);

        foreach (Collider2D item in colliders2D)
        {
            if (item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundSensor.position, _sensorSize);
    }
}
