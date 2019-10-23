using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private float _speed = 5.0f;

    private Rigidbody2D _rigid;

    private PlayerAnimation _playerAnim;

    private SpriteRenderer _playerSprite;

    private bool _resetJump = false;

    private bool _grounded = false;

    private bool isDead = false;

    private int layerMask = 1 << 8; 

    public int coinAmount;

    public int Health { get; set; }

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to rigidboy
        _rigid = GetComponent<Rigidbody2D>();

        // assign handle to playeranimation
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        Health = 4;
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    void Update()
    {
        if (isDead == false) {
            Movement();
        }

        // if left click && IsGrounded then
        // attack
        if (/* CrossPlatformInputManager.GetButtonDown("A_Button") */ Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }
    }

    /******************************************
     * movement Method
     ******************************************/
    void Movement()
    {
        // move input for left/right
        float  move = Input.GetAxisRaw("Horizontal"); /* CrossPlatformInputManager.GetAxis("Horizontal"); */
        _grounded = IsGrounded();

        // if move is greater than 0
        // facing right
        // else if move < 0
        // facing left
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        if /* ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded() == true) */
        (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            // Debug.Log("Jump!");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());

            // tell animator to jump
            _playerAnim.Jump(true);
        }

        // current velocity = new velocity(move input, current velocity.y);
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    /******************************************
     * player isGrounded?
     ******************************************/
    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 2f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null) 
        {
            if (_resetJump == false)
            {
                // Debug.Log("Grounded");

                // set jump animator bool to false
                _playerAnim.Jump(false);

                return true;
            }
        }

        return false;
    }

    /******************************************
     * flip method
     ******************************************/
    void Flip(bool faceRight)
    {
        // if move is greater than 0
        // facing right
        // else if move < 0
        // facing left
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }

    /******************************************
     * resetjumproutine method
     ******************************************/
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    /******************************************
     * damage method
     ******************************************/
    public void Damage(int damageNum)
    {
        if (isDead == true)
        {
            return;
        }

        Debug.Log("Player::Damage()");

        // remove 1 health
        // update UI display
        // check for dead
        // play death animation
        // subtract 1 from health
        Health -= damageNum;
        _playerAnim.Hit();

        UIManager.Instance.UpdateLives(Health);

        // if health is less than 1
        // destroy the object
        if (Health < 1)
        {
            isDead = true;
            _playerAnim.Death();

            FindObjectOfType<GameManager>().EndGame();
        }
    }

    /******************************************
     * add coins method
     ******************************************/
    public void AddCoins(int amount)
    {
        coinAmount += amount;
        UIManager.Instance.UpdateCoinCount(coinAmount);
    }
}
