using System;

namespace _Scripts.Effects
{
    [Serializable]
    public class Effect
    {
        private string _name;
        private string _description;
        private int _uses;
        private int _value;
        private EffectType _effectType;

        public Effect(string name, string description, int uses, int value, EffectType effectType)
        {
            _name = name;
            _description = description;
            _uses = uses;
            _value = value;
            _effectType = effectType;
        }

        // Getters and Setters
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public int Uses
        {
            get { return _uses; }
            set { _uses = value; }
        }
        
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        public EffectType EffectType
        {
            get { return _effectType; }
            set { _effectType = value; }
        }
        
        
    }
}