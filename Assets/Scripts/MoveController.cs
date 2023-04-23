using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController 
{
    public bool isJumping { get; set; }
    public void HorizontalMove(Transform _transform, float _hspeed, Animator _anim,SpriteRenderer _playerSprite, bool _isActive ,bool isFlip)
    {
        
        if (_isActive)
        {
           _transform.position += new Vector3(Input.GetAxis("Horizontal") * _hspeed * Time.deltaTime, 0);
           _anim.SetFloat("__isRun",Mathf.Abs(Input.GetAxis("Horizontal")));

            if (Input.GetAxis("Horizontal") == 0)
            {
                return;
            }
            _playerSprite.flipX = Input.GetAxis("Horizontal") < 0; // horizontal 0 dan küçükse flip true, deðilse flip false
            isFlip = _playerSprite.flipX;
        }
    }

    //public void VerticalMove(Transform _transform, float _vspeed)
    //{
    //   _transform.position += new Vector3(0,Input.GetAxis("Vertical") * _vspeed * Time.deltaTime, 0);
    //}

    public void Jump(Rigidbody2D _rigid,float _jumpSpeed, Animator _anim, bool _isActive)
    {
        if (_isActive)
        {
            _rigid.AddForce(Vector2.up * Input.GetAxis("Jump") * _jumpSpeed);
        }
    }
}
