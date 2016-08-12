using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health = 20;
    static bool dead;

    void Update()
    {
        if (dead) DestroySelf();
        if (health <= 0) Die();
        if (Input.GetKeyDown(".")) KILL_ALL();
    }

    public void Damage()
    {
        health -= (int)(health/5);
    }

    public void Damage(int d)
    {
        health -= d;
    }

    static void Die()
    {
        dead = true;
    }
    
    public static void KILL_ALL()
    {
        Enemy.Die();
    }

    void DestroySelf()
    {
        print(string.Format("Killed an enemy."));
        Destroy(this.gameObject);
    }
}
