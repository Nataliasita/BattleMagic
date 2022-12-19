using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Battle;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.UI
{
    public class CardSelector : MonoBehaviour
    {
        [SerializeField] private BattleController battleController;
        [SerializeField] private BattleEvents battleEvents;
        [SerializeField] private List<CardDisplay> cardSelectors;
        private Player _player;
        private Enemy _enemy;

        private void Awake()
        {
            _player = battleController.Player;
            _enemy = battleController.Enemy;
        }

        private void Start()
        {
            foreach (var card in cardSelectors)
            {
                card.gameObject.SetActive(false);
            }

            StartCoroutine(SetCads());
        }

        IEnumerator SetCads()
        {
            yield return new WaitForSeconds(0.8f);
            for (int i = 0; i < _player.CharacterBase.GetCards().Count; i++)
            {
                cardSelectors[i].gameObject.SetActive(true);
                cardSelectors[i].SetCard(_player.CharacterBase.GetCards(i));
            }
        }

    }
}