using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

    [SerializeField] bool destroyOnTriggerOrCollision;
    [SerializeField] bool reactWithPlayerTagOnly;
    [SerializeField] [Tooltip("If value less than 0, autokill.")] int damageAmount = 1;
    [SerializeField] Vector3 knockbackVector = Vector3.up;

    void OnTriggerEnter(Collider C)
    {
        if(C.gameObject.tag == "Player")
        {
            if(C.gameObject.GetComponent<Player>())
            {
                Player player = C.gameObject.GetComponent<Player>();
                print("Player Collision");
                player.Damage(damageAmount);
                player.Knockback(knockbackVector);
            }
        }
        else
        {
            print("Object Collision");
            if (reactWithPlayerTagOnly) return;
            Destroy(C.gameObject);
        }
        if (destroyOnTriggerOrCollision) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision C)
    {
        print(string.Format("Hit {0}.", C.gameObject.name));
        if (C.gameObject.tag == "Player")
        {
            print("Player Collision 1");
            if (C.gameObject.GetComponent<Player>())
            {
                Player player = C.gameObject.GetComponent<Player>();
                print("Player Collision");
                player.Damage(damageAmount);
                player.Knockback(knockbackVector);
            }
        }
        else
        {
            print("Object Collision");
            if (reactWithPlayerTagOnly) return;
            Destroy(C.gameObject);
        }
        if (destroyOnTriggerOrCollision) Destroy(this.gameObject);
    }

    //void OnCharacterColliderOnHit(CharacterController c)
    //{
    //    print("it got hurt");
    //}

    
}
