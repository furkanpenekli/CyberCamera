using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 3f;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundLayer;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField]
    private float _animationSpeed = 0.1f;
    private bool isGrounded;

    public float horizontalSpeed = 0f;

    [SerializeField]
    private bool _facingRight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_groundCheck == null)
        {
            Debug.LogError("Ground Check Transform not assigned!");
        }
    }

    void Update()
    {
        GetComponent<Animator>().SetFloat("AnimationSpeed", _animationSpeed);
        CheckIsGrounded();
        Walk();
        Flip();
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
    }

    public void Flip()
    {
       
        if (horizontalSpeed > 0 && !_facingRight)
        {
            _facingRight = true;
            _spriteRenderer.flipX = false;
        }
        else if (horizontalSpeed > 0 && _facingRight)
        {
            _spriteRenderer.flipX = false;
        }

        else if (horizontalSpeed < 0 && !_facingRight)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontalSpeed < 0 && _facingRight)
        {
            _spriteRenderer.flipX = true;
            _facingRight = false;
        }
    }

    public void Walk()
    {
        Vector2 moveDirection = new Vector2(horizontalSpeed, 0);
        _rb.velocity = new Vector2(moveDirection.x * speed, _rb.velocity.y);
            
        //If character isn't ground walking animation disable but character can move
        if (isGrounded && horizontalSpeed != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _animator.SetTrigger("Jump");
        }
    }
}
