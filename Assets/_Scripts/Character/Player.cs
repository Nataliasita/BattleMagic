using _Scripts.Cards;
using UnityEngine;

namespace _Scripts.Character
{
    public class Player : Character
    {

        protected override void Start()
        {
            base.Start();
            CharacterBase.Level = 1;
        }

        // Events
        protected override void OnBattleStart()
        {
            base.OnBattleStart();
            IsTurn = true;
            Debug.Log($"{gameObject.name} join the battle");
        }

        protected override void OnBattleEnd(GameObject caller)
        {
            base.OnBattleEnd(caller);
        }

        protected override void OnTurnEnd(GameObject character)
        {
            base.OnTurnEnd(character);
        }

        protected override void OnAttack(CharacterBase from, CardsBase card)
        {
            base.OnAttack(from, card);
            if (from == CharacterBase)
            {
                Debug.Log($"Player attack with {card.Name}");
            }
            else
            {
                Debug.Log($"Enemy Life: {from.Health}");
            }
        }

        // Methods
        [ContextMenu("Attack")]
        public void Attack()
        {
            if (!IsTurn) return;
            var card =  CharacterBase.GetCards(0);
            Attack(CharacterBase, card);
            EndTurn();
        }

        [ContextMenu("Supp")]
        public void Supp()
        {
            if (!IsTurn) return;
            var card =  CharacterBase.GetCards(1);
            Attack(CharacterBase, card);
            EndTurn();
        }
        
    }
}