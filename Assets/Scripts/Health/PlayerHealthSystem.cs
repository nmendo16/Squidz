using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float hp = 100f;
    [SerializeField] 
    private NewPlayerMovement player;

    public void Start()
    {

    }

    public void OnHit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            HealthEventManager.PlayerDiedEvent(player.GetPlayerNumber());
            Debug.Log("HP = " + hp);
        }
    }
}
