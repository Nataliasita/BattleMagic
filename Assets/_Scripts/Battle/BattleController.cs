using System;
using System.Collections;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Battle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Enemy enemy;
        [SerializeField] private BattleEvents _battleEvents;
        [SerializeField] private BattleState _state = BattleState.Start;

        public Player Player => player;
        public Enemy Enemy => enemy;

        public GameObject ViewWin;
        public GameObject ViewLost;

        public GameObject ViewBattle;

        private void Awake()
        {
            _battleEvents.OnTurnEnd.AddListener(OnTurnEnd);
            _battleEvents.OnBattleEnd.AddListener(OnBattleEnd);
        }

        private void Start()
        {
            _battleEvents.OnBattleStart.Invoke();
            Invoke("ActiveViewBattle", 0.5f);
        }

        private void ActiveViewBattle(){
            ViewBattle.SetActive(true);
        }

        private void OnTurnEnd(GameObject obj)
        {
            if (obj == player.gameObject)
            {
                _state = BattleState.EnemyTurn;
            }
            else if (obj == enemy.gameObject)
            {
                _state = BattleState.PlayerTurn;
            }
        }

        
        private void OnBattleEnd(GameObject obj)
        {
            if (obj == player.gameObject)
            {
                Debug.Log("Enemy Win");
                _state = BattleState.Won;
                ViewBattle.SetActive(false);
                Invoke("stateActiveLost",4f);

            }
            else if (obj == enemy.gameObject)
            {
                Debug.Log("Player Win");
                _state = BattleState.Lost;
                ViewBattle.SetActive(false);
                Invoke("stateActiveWin",4f);
            }
            
        }

            private void stateActiveWin()
            {
                ViewWin.SetActive(true);
            }

            private void stateActiveLost()
            {
                ViewLost.SetActive(true);
            }

    }
}