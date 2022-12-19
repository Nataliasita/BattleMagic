using System;
using System.Collections.Generic;
using _Scripts.Cards;
using _Scripts.Effects;
using UnityEngine;

namespace _Scripts.Character
{
    [Serializable]
    public class CharacterBase
    {
        [SerializeField] private List<Effect> _effects;
        private List<CardsBase> _cards;
        private int _level;
        private int _maxHealth;
        private int _health;
        private int _maxMana;
        private int _mana;

        public CharacterBase(int maxHealth, int maxMana, int level)
        {
            _effects = new List<Effect>();
            _cards = new List<CardsBase>();
            _level = level;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _maxMana = maxMana;
            _mana = maxMana;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }
        
        public List<Effect> Effects => _effects;

        public void AddEffect(Effect effectBase)
        {
            _effects.Add(effectBase);
        }
        
        public void RemoveEffect(Effect effectBase)
        {
            _effects.Remove(effectBase);
        }

        public void AddCard(CardsBase card)
        {
            _cards.Add(card);
        }
        
        public void SetCards(List<CardsBase> cards)
        {
            _cards = cards;
        }
        
        public void RemoveCard(CardsBase card)
        {
            _cards.Remove(card);
        }
        
        public List<CardsBase> GetCards()
        {
            return _cards;
        }

        public CardsBase GetCards(int idx)
        {
            return _cards[idx];
        }

        public int MaxHealth  => _maxHealth;

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int MaxMana => _maxMana;
        
        public int Mana
        {
            get => _mana;
            set => _mana = value;
        }
        
    }
}