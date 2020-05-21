using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    [SerializeField] Collider2D damageArea;
    [SerializeField] LayerMask  damageMask;

    ContactFilter2D contactFilter;

    // Start is called before the first frame update
    void Start()
    {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(damageMask);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] results = new Collider2D[64];

        int nCollisions = Physics2D.OverlapCollider(damageArea, contactFilter, results);
    }
}
