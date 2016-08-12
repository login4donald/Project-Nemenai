using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gooey : MonoBehaviour {
    public Slider health;
    public void SetUI()
    {
        health.maxValue = 100;
    }
	public void UpdateUI(player p)
    {
        health.value = p.hp;
    }
}
