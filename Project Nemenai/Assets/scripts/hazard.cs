using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
    public bool instantKill;
    public int knockbackForce = 100;
    public int damage = 10;
	void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            if (instantKill)
            {
                c.gameObject.GetComponent<player>().InstantKill();
            }
            else
            {
                c.gameObject.GetComponent<player>().Dmg(damage);
            }
        }
    }
}
