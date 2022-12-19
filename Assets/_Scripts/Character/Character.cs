using System.Collections.Generic;
using System.Linq;
using _Scripts.Battle;
using _Scripts.Cards;
using _Scripts.Effects;
using UnityEngine;

namespace _Scripts.Character
{
    public abstract class Character : MonoBehaviour
    {
        
        [SerializeField] private CharacterBase _characterBase;
        [SerializeField] private int _MaxHealth;
        [SerializeField] private int _MaxMana;
        [SerializeField] private List<CardsBase> _cards;
        [SerializeField] private int _level;
        [SerializeField] private BattleEvents _battleEvents;
        [SerializeField] private bool _isTurn;

        // Getters and Setters
        public CharacterBase CharacterBase => _characterBase;
        protected bool IsTurn
        {
            get => _isTurn;
            set => _isTurn = value;
        }

        // Unity Events
        protected virtual void OnEnable()
        {
            _battleEvents.OnBattleStart.AddListener(OnBattleStart);
            _battleEvents.OnBattleEnd.AddListener(OnBattleEnd);
            _battleEvents.OnTurnEnd.AddListener(OnTurnEnd);
            _battleEvents.OnAttack.AddListener(OnAttack);
        }

        protected virtual void OnDisable()
        {
            _battleEvents.OnBattleStart.RemoveListener(OnBattleStart);
            _battleEvents.OnBattleEnd.RemoveListener(OnBattleEnd);
            _battleEvents.OnTurnEnd.RemoveListener(OnTurnEnd);
            _battleEvents.OnAttack.RemoveListener(OnAttack);
        }
        
        protected virtual void Start()
        {
            _characterBase = new CharacterBase(_MaxHealth, _MaxMana, _level);
            _characterBase.SetCards(_cards);
        }
        
        // Methods
        protected void EndTurn()
        {
            _battleEvents.OnTurnEnd.Invoke(gameObject);
        }
        
        protected void Attack(CharacterBase from, CardsBase card)
        {
            _characterBase.Mana -= card.Cost;
            Debug.Log($"{_characterBase.Mana}");
            _battleEvents.OnAttack.Invoke(from, card);
        }
        
        protected void CharacterDead()
        {
            _battleEvents.OnBattleEnd.Invoke(gameObject);
        }

        protected void ApplyEffects()
        {
            foreach (var effect in _characterBase.Effects.ToList())
            {
                effect.UseEffect(_characterBase);
            }
        }
        
        // Battle Events
        protected virtual void OnBattleStart()
        {
            BattleEvents.GameOver = false;
        }

        protected virtual void OnBattleEnd(GameObject caller)
        {
            BattleEvents.GameOver = true;
            _isTurn = false;
            Debug.Log($"{caller.name} is Dead!");
        }

        protected virtual void OnTurnEnd(GameObject character)
        {
            if (_isTurn) ApplyEffects();
            if (BattleEvents.GameOver) return;
            IsTurn = !(character == gameObject);
        }

        protected virtual void OnAttack(CharacterBase from, CardsBase card)
        {
            if (from == CharacterBase)
            {
                foreach (var effect in card.Effects)
                {
                    var newEffect = new Effect(
                        effect.Name,
                        effect.Description,
                        effect.Uses,
                        effect.Value,
                        effect.EffectType
                    );
                    if (effect.EffectType == EffectType.Heal)
                    {
                        from.Effects.Add(newEffect);
                    }
                    else
                    {
                        CharacterBase.Effects.Add(newEffect);
                    }
                }
            }
            else
            {
                CharacterBase.Health -= card.Damage;
                if (CharacterBase.Health <= 0)
                {
                    CharacterDead();
                }
            }
        }
        
    }
}