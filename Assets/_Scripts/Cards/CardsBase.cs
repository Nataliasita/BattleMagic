using System;
using System.Collections.Generic;
using _Scripts.Effects;
using UnityEngine;

namespace _Scripts.Cards
{
    
    [CreateAssetMenu(
        fileName = "New Card",
        menuName = "Battle/Card"
        )]
    public class CardsBase : ScriptableObject
    {
        public int Id;
        [SerializeField] private String _name;
        [SerializeField][TextArea] private String _description;
        [SerializeField] private int _cost;
        [SerializeField] private int _damage;
        [SerializeField] private List<EffectBase> _effects;
        [SerializeField] public Sprite _sprite;
        
        public String Name
        {
            get => _name;
            set => _name = value;
        }
        
        public String Description
        {
            get => _description;
            set => _description = value;
        }

        public int Cost
        {
            get => _cost;
            set => _cost = value;
        }
        
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public List<EffectBase> Effects => _effects;
    }
}
