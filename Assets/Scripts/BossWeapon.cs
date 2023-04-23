using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField] int attackDamage;
    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange  ;
    [SerializeField] LayerMask attackMask;
    [SerializeField] HealthBar _health;
    public bool _isBlock;
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        
        if (colInfo !=null)
        {
            _health.TakeDamage(attackDamage);
            print("oldu");
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }


}
