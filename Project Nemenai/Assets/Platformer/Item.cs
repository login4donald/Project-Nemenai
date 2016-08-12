using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public AudioClip sfx;
	public enum ITEM
    {
        Health,
        Powerup,
        Collectable
    }
    public ITEM type;
    public Vector3 rotVector;

    void Start()
    {
        if (!this.gameObject.GetComponent<Collider>())
        {
            Debug.LogError(string.Format("{0} (ITEM) does not have a Collider component.", this.gameObject.name));
        }
    }

    void Update()
    {
        transform.Rotate(rotVector * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            if (sfx) AudioSource.PlayClipAtPoint(sfx, transform.position);
            #region SWITCH  
            switch (type)
            {
                case ITEM.Collectable:
                    print(string.Format("You collected a(n) collectible."));
                    break;
                case ITEM.Health:
                    print(string.Format("You collected a(n) health item."));
                    break;
                case ITEM.Powerup:
                    print(string.Format("You collected a(n) powerup item."));
                    break;
            }
            #endregion
            Destroy(this.gameObject);
        }
    }
}
