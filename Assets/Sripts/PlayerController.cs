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

    private Animator _animator;

    private InputAction _attackAction;

    [SerializeField] private int _attackDamage = 10;
    [SerializeField] private Transform _attackHitBox;
    [SerializeField] private float _hitBoxRadius = 1f;

    private InputAction _pauseAction;


    


    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
        _animator = GetComponent<Animator>();
        _pauseAction = InputSystem.actions["Pause"];
    }

    
    void Start()
    {
        
    }


    void Update()
    {
        if (_pauseAction.WasPressedThisFrame())
        {
            GameManager.Instance.Pause();
        }

        if (GameManager.Instance.IsPaused())
        {
           return; 
        }
        _moveInput = _moveAction.ReadValue<Vector2>();

        if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
         _animator.SetBool("IsRunning", false);   
        }

        if (_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
        _animator.SetBool("IsJumping", !IsGrounded());

         if (_attackAction.WasPressedThisFrame() && IsGrounded())
        {
            Attack();
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

        Gizmos.color = Color.pink;
        Gizmos.DrawWireSphere(_attackHitBox.position, _hitBoxRadius);
    }
    void Attack()
    {
        _animator.SetTrigger("IsAttacking");

        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(_attackHitBox.position, _hitBoxRadius);

        foreach (Collider2D enemy in colliders2D)
        {
            if (enemy.gameObject.layer == 7)
            {
                Mimik enemyScript = enemy.GetComponent<Mimik>();

                enemyScript.TakeDamage(_attackDamage);
            }
        }

    }
}
