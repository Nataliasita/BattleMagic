using System;
using UnityEngine;

namespace _Scripts.Effects
{
    [CreateAssetMenu(
        fileName = "New Effect",
        menuName = "Battle/Effect"
        )]
    public class EffectBase : ScriptableObject
    {
        [SerializeField] private String _name;
        [SerializeField][TextArea] private String _description;
        [SerializeField] private EffectType _effectType;
        [SerializeField] private int _value;
        [SerializeField] private int _uses;
        
        public string Name => _name;
        public string Description => _description;
        public EffectType EffectType => _effectType;
        public int Value => _value;
        public int Uses
        {
            get => _uses;
            set => _uses = value;
        }
    }
}