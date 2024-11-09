using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEventManager : MonoBehaviour
{
    public delegate void PlayerDiedHandler(bool isPlayer2);
    public static event PlayerDiedHandler PlayerDied;

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerDiedEvent(bool isPlayer2)
    {
        PlayerDied?.Invoke(isPlayer2);
    }
}
