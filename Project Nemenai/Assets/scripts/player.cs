using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class player : MonoBehaviour {
    [HideInInspector]public int hp = 100;
    public gooey ui;
    CharacterController cc;
    void Start()
    {
        gameObject.tag = "Player";
        ui.SetUI();
    }
    void Update()
    {
        cc = GetComponent<CharacterController>();
        Vector3 m = new Vector3();
        m.x = Input.GetAxis("Horizontal");
        cc.Move(m*6*Time.deltaTime);
        ui.UpdateUI(this);
    }
    public void InstantKill() { Die(); }
    public void Dmg(int i) { hp -= i; if (hp <= 0) { Die(); } }
    public void Heal(int i) { hp += i; if (hp >= 100) hp = 100; }
    void Die() { this.gameObject.SetActive(false); }
}
