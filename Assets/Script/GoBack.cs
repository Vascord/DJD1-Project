using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GoBack : MonoBehaviour
{
    [Tag]
    new public string       tag;
    [Tag]
    new public string       walltag;
    [Tag]
    new public string       enemytag;
    [SerializeField] float  damage;
    [SerializeField] float  Adamage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((tag == collision.tag) || (walltag == collision.tag))
        {
            HP hp = collision.GetComponent<HP>();

            if (hp)
            {
                hp.DealDamage(damage, Adamage);
            }

            MoveForward returning = gameObject.GetComponent<MoveForward>();

            if(returning)
            {
                returning.Return();
            }
        }

        if(enemytag == collision.tag)
        {
            Destroy(gameObject);
        }
    }
}
