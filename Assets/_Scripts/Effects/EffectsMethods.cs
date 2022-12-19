using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Effects
{
    public static class EffectsMethods
    {
        private static Exception EffectErrorType(Effect effectBase, EffectType type)
        {
            return !effectBase.EffectType.Equals(type) ? new Exception("Effect type is not " + type) : null;
        }
        
        public static void HealEffect(this Effect effectBase, CharacterBase character)
        {
            Debug.Log(effectBase.Uses);
            if (EffectErrorType(effectBase, EffectType.Heal) != null) return;
            effectBase.Uses -= 1;
            if (effectBase.Uses <= 0)
            {
                Debug.Log("Effect has run out of uses");
                character.Effects.Remove(effectBase);
                return;
            }
            character.Health += effectBase.Value;
            Debug.Log($"Used {effectBase.Name} on This and healed {effectBase.Value} health and left {effectBase.Uses} uses");
        }

        public static void PoisonEffect(this Effect effectBase, CharacterBase target)
        {
            if (EffectErrorType(effectBase, EffectType.Poison) != null) return;
            effectBase.Uses -= 1;
            if (effectBase.Uses <= 0)
            {
                Debug.Log("Effect has run out of uses");
                target.Effects.Remove(effectBase);
                return;
            }
            target.Health -= effectBase.Value;
            Debug.Log($"Used {effectBase.Name} on This and poisoned {effectBase.Value} health and left {effectBase.Uses} uses");
        }
        
        public static void FireEffect(this Effect effectBase, CharacterBase target)
        {
            if (EffectErrorType(effectBase, EffectType.Fire) != null) return;
            Debug.Log($"{target} is on fire");
        }
        
        public static void IceEffect(this Effect effectBase, CharacterBase target)
        {
            if (EffectErrorType(effectBase, EffectType.Ice) != null) return;
            Debug.Log($"{target} is frozen");
        }
        
        public static void WeaknessEffect(this Effect effectBase, CharacterBase target)
        {
            if (EffectErrorType(effectBase, EffectType.Weakness) != null) return;
            Debug.Log($"{target} is weak");
        }
        
        public static void UseEffect(this Effect effectBase, CharacterBase target)
        {
            switch (effectBase.EffectType)
            {
                case EffectType.Heal:
                    effectBase.HealEffect(target);
                    break;
                case EffectType.Poison:
                    effectBase.PoisonEffect(target);
                    break;
                case EffectType.Fire:
                    effectBase.FireEffect(target);
                    break;
                case EffectType.Ice:
                    effectBase.IceEffect(target);
                    break;
                case EffectType.Weakness:
                    effectBase.WeaknessEffect(target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}