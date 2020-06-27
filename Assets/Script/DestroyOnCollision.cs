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
    [SerializeField] GameObject weapon;
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

            Player_Mouvement player = collision.GetComponent<Player_Mouvement>();

            if ((player) && (gameObject.tag == "MacDo"))
            {
                Shoot gun= weapon.GetComponent<Shoot>();
                gun.NewWeapon(2);
            }

            else if ((player) && (gameObject.tag == "Shootgun"))
            {
                Shoot gun= weapon.GetComponent<Shoot>();
                gun.NewWeapon(1);
            }

            BossCinematic cinematic = gameObject.GetComponent<BossCinematic>();

            if(cinematic)
            {
                cinematic.Cutscene();
            }

            BossFightStarts fight = gameObject.GetComponent<BossFightStarts>();

            if(fight)
            {
                fight.Cutscene();
            }
        }
    }
}