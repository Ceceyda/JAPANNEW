using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck 
{
    public bool isGround { get; set; }
    public void Raycast(Transform _transform,float distance,LayerMask _layerMask,bool _isGround)
    {
        RaycastHit2D _hit = Physics2D.Raycast(_transform.position, Vector2.down, distance, _layerMask);
        Debug.DrawRay(_transform.position, Vector2.down * distance, Color.red);
        _isGround = this.isGround;

        //_isGround = _hit.collider==null ? true : false;// aþaðýdakinin kýsa hali
        //Debug.Log(_hit.collider);

        this.isGround = _hit.collider != null ? true : false;
        

        //if (_hit.collider != null)
        //{
        //    this.isGround =true;
        //}
        //else
        //{
        //    this.isGround = false;
        //}
        //Debug.Log(_isGround);

    }
}
