using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum TYPE
{
    _2D,
    _3D
}

public class Player : MonoBehaviour {
    public TYPE alignment;
    bool dead, paused;
    public int health = 100;
    CharacterController player;
    public Slider healthUI;
    public float mvementSpd = 6;
    public int jumpForce = 6;
    Vector3 mvement = Vector3.zero;
    public float gravity = 10f;

    void Start()
    {
        gameObject.tag = "Player";
        if(!this.gameObject.GetComponent<CharacterController>())
        this.gameObject.AddComponent<CharacterController>();
        player = GetComponent<CharacterController>();
        if (healthUI) healthUI.maxValue = 100;
        
    }

    void Update()
    {
        if (dead) return;
        if (health <= 0) Die();
        if (healthUI) healthUI.value = health;

        if (Input.GetKeyDown("p")) Pause();
        if (paused) return;

        

        if (player.isGrounded) {
            mvement.x = Input.GetAxis("Horizontal");
            if(alignment == TYPE._3D) mvement.z = Input.GetAxis("Vertical");
            if(Input.GetButtonDown("Jump"))
            {
                mvement.y = jumpForce;
            }
        }
        else
        {
            mvement.x = Input.GetAxis("Horizontal") * .8f;
            if (alignment == TYPE._3D) mvement.z = Input.GetAxis("Vertical") * .8f;
        }
        if (Input.GetKeyDown("r"))
        {
            mvement.x *= 20f;
        }

        mvement.y -= gravity * Time.deltaTime;
        player.Move(mvement * mvementSpd * Time.deltaTime);

        Vector3 rot = transform.rotation.eulerAngles;;
        if (mvement.x > 0.1f) rot.y = 90;
        else if (mvement.x < -0.1f) rot.y = -90;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot), 0.1f);

        
    }

    void Pause()
    {
        if(!paused)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
        }
    }

    void Die()
    {
        dead = true;
        print(string.Format("Game Over: Player Died"));
    }

    public void Damage(int i)
    {
        health -= i;
    }

    public void Heal(int i)
    {
        health += i;
    }

    public void Knockback(Vector3 kb)
    {
        player.Move(kb * Time.deltaTime);
    }

    public void Knockback(Vector2 kb)
    {
        player.Move(kb * Time.deltaTime);
    }

    void OnControllerColiiderHit(ControllerColliderHit c)
    {
        print("i got hurt");
    }

}
