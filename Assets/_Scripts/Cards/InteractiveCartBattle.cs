using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCartBattle : MonoBehaviour
{

    _Scripts.Character.Player playerClass;

    public void Interactive()
    {
        playerClass.Attack();
        Debug.Log("prueba interaccion");
    }

    // void Update()
    // {
        
    // }
}
