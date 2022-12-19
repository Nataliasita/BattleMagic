using System.Collections;
using _Scripts.Battle;
using _Scripts.Cards;
using UnityEngine;

namespace _Scripts.Character
{
    public class Enemy : Character
    {
        [SerializeField] private EnemyType enemyType;
        
        // Unity Events
        protected override void Start()
        {
            base.Start();
            CharacterBase.Level = enemyType switch
            {
                EnemyType.CrazyCat => 1,
                EnemyType.MagicalCat => 2,
                _ => CharacterBase.Level
            };
        }

        // Events
        protected override void OnBattleStart()
        {
            base.OnBattleStart();
            Debug.Log($"Enemy {enemyType} is ready to fight!");
        }

        protected override void OnBattleEnd(GameObject caller)
        {
            base.OnBattleEnd(caller);
        }

        protected override void OnTurnEnd(GameObject character)
        {
            base.OnTurnEnd(character);
            // Random Choice
            if (!IsTurn) return;
            int randomCard = Random.Range(0, CharacterBase.GetCards().Count);
            var card = CharacterBase.GetCards(randomCard);
            if (IsTurn)
            {
                Attack(CharacterBase, card);
                EndTurn();
            }
        }

        protected override void OnAttack(CharacterBase from, CardsBase card)
        {
            base.OnAttack(from, card);
            if (from == CharacterBase)
            {
                Debug.Log($"Enemy attack with {card.Name}");
            }
            else
            {
                Debug.Log($"Player Life: {from.Health}");
            }
        }
    }
}