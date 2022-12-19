using System;
using _Scripts.Battle;
using _Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class CharacterUIController : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _manaSlider;
        [SerializeField] private Character.Character _characterBase;

        private void Update()
        {
            _healthSlider.value = _characterBase.CharacterBase.Health;
            _manaSlider.value = _characterBase.CharacterBase.Health;  
        }

    }
}