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
            if(gameObject.tag == "SavePoint")
            {
                gameObject.transform.position = new Vector3(-10000,-10000,-100);
            }
            else
            {
                Destroy(gameObject);
            }

            HP hp = collision.GetComponent<HP>();

            if (hp)
            {
                hp.DealDamage(damage, Adamage);
            }
        }
    }
}