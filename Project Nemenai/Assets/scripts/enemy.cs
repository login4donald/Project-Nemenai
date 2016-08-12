using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int hits = 3;
    public AudioClip sfx;
    public void Dmg() { hits -= 1; AudioSource.PlayClipAtPoint(sfx, Vector3.zero); if (hits <= 0) Disable(); }
    public void Disable() { this.gameObject.SetActive(false); }
}
