using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class DestroyOnCollision : MonoBehaviour
{
    [Tag]
    new public string       tag;
    [Tag]
    new public string       walltag;
    [SerializeField] float  damage;
    [SerializeField] float  Adamage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((tag == collision.tag) || (walltag == collision.tag))
        {
            Destroy(gameObject);

            HP hp = collision.GetComponent<HP>();

            if (hp)
            {
                hp.DealDamage(damage, Adamage);
            }
        }
    }
}