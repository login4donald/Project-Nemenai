using UnityEngine;
using System.Collections;
public enum iType
{
    hp, item
}
public class item : MonoBehaviour {
    public iType type;
    public AudioClip sfx;
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            print("item gots");
            switch(type)
            {
                case iType.hp:
                    break;
                case iType.item:
                    break;
            }
        }
        AudioSource.PlayClipAtPoint(sfx, Vector3.zero);
        this.gameObject.SetActive(false);
    }
}
