using System;
using _Scripts.Cards;
using _Scripts.Character;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Battle
{
    public class BattleEvents : MonoBehaviour
    {
        public static bool GameOver;
        
        public UnityEvent OnBattleStart;
        public UnityEvent<GameObject> OnTurnEnd;
        public UnityEvent<CharacterBase, CardsBase> OnAttack;
        public UnityEvent<GameObject> OnBattleEnd;

    }
}