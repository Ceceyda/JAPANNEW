using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Vector3 targetPosition;
   public Transform dashEndTransform;



    public GameObject shuriken;
    public Transform shurikenTrans,shurikenTrans2;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource _as;
    Transform _playerTransform;
    [SerializeField] Transform _raycastTransform, attackPoint, attackpoint2;
    [SerializeField] float _runSpeed, _jumpSpeed, _raycastDistance, _attackRange, _attackRate;
    [SerializeField] bool _isRunActive, _isJumpActive, _isAttack, _isAttacking;
    [SerializeField] int _attackDamage;
    [SerializeField] LayerMask _raycastLayer, _enemyLayers;
    Animator _playerAnim;
    [SerializeField] float nextAttackTime ;
    SpriteRenderer _playerSprite;
    public bool _isSpace, _isGround, _isBlock,_isShift,_isDash,_r,_isThrow,_d;
    public float _isRun;
    MoveController _moveController;
    OnGroundCheck _onGroundCheck;
    Rigidbody2D _rigid;
    public bool isFlip;
    [SerializeField] HealthBar _hb;

    private void Awake()
    {
        
        _moveController = new MoveController();
        _onGroundCheck = new OnGroundCheck();
        _playerTransform = this.transform;
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }


    void Deneme() 
    {

          
    
    }

    void Deneme_1()
    {
    
        _isThrow=false;
    
    }

    public void Shuriken()
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            Instantiate(shuriken, shurikenTrans2.position, Quaternion.identity);

        }
        else
        {
            Instantiate(shuriken, shurikenTrans.position, Quaternion.identity);

        }
    }

    public void OnDashAnimationEnd() 
    {
        _isDash = false;

        transform.position = targetPosition + new Vector3(transform.position.x+3.95f, -2.787308f, 0);

        transform.position += targetPosition;


        if (_d)
        {
            _isRunActive = true;
            _playerAnim.SetFloat("__isRun", 4);
            _d= false;
        }
        else
        {
            _playerAnim.SetFloat("__isRun", 0);

        }




    }

   
   
    void Throw()
    {
        if (_r)
        {
            _isThrow = true;
            _playerAnim.SetBool("__isThrow", true);
            _r = false;
        }
        if (_isThrow==false)
        {
            _playerAnim.SetBool("__isThrow", false);
            Invoke("Deneme_1", 1f);

        }
        


    }
    void OnGroundCheck()
    {
        _onGroundCheck.Raycast(_raycastTransform, _raycastDistance, _raycastLayer, _isGround);

        _isGround = _onGroundCheck.isGround ? true : false;
        _playerAnim.SetBool("__isJump", !_isGround ? true : false);
        //if (_onGroundCheck.isGround)
        //{
        //    _isGround = true;
        //}
        //else
        //{
        //    _isGround = false;
        //}
    }
    void HorizontalMove()
    {
        _moveController.HorizontalMove(_playerTransform, _runSpeed, _playerAnim, _playerSprite, _isRunActive,isFlip);
    }

    void SpaceandAttackControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           _isSpace = true;
        }

        if (Input.GetMouseButtonDown(0)&& _isGround)
        {
           _isAttack = true;
        }
        
    }
    void Jump()
    {
        if (_isSpace && _isGround && !_isDash)
        {
           _moveController.Jump(_rigid, _jumpSpeed, _playerAnim,_isJumpActive);
        }
        _isSpace = false;
    }
    private void FixedUpdate()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            
        }
        HorizontalMove();
        Jump();
        
        Throw();
        
    }

    private void Update()
    {
        
        OnGroundCheck();
        SpaceandAttackControl();
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _isBlock = true;
        }


        if (Input.GetKeyDown(KeyCode.R) )
        {
            _r = true;
            _isThrow = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) )
        {
            _isShift = true;
            _isDash = true;
        }



        if (Input.GetKeyDown(KeyCode.D))
        {
            _d = true;
            _isRunActive = true;
        }





    }
    //buuuuuuuuuuuuuuuuuuuuuuu
    void EndAttack()
    {
        
        _isAttacking = false;
        _isAttack = false;
        _playerAnim.SetBool("__isAttack",false);

    }

    void Attack()
    {
        if (!_isAttacking&&_isAttack)
        {
            _as.PlayOneShot(audioClip);
            _isAttacking = true;
            _playerAnim.SetTrigger("__isAttack");

           Collider2D[] hitEnemies=  Physics2D.OverlapCircleAll(attackPoint.position,_attackRange,_enemyLayers);
           Collider2D[] hitEnemies1=  Physics2D.OverlapCircleAll(attackpoint2.position,_attackRange,_enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                
                enemy.GetComponent<EnemyController>().TakeDamage(_attackDamage);
            }
            foreach (Collider2D enemy in hitEnemies1)
            {
                enemy.GetComponent<EnemyController>().TakeDamage(_attackDamage);
            }
            nextAttackTime = Time.time + 1f / _attackRate;
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
        Gizmos.DrawWireSphere(attackpoint2.position, _attackRange);
    }
}
