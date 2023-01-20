using System;
using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class Chase : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Worker _worker;
        [SerializeField] private ObstacleSpawner _spawner;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private WindowsSwitcher _windowsSwitcher;
        [SerializeField] private BackController _backController;
        
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
            
            _playerMovement.Moved += _progressBar.Move;
            _progressBar.EnemyStopped += ActivateFinalScene;
            _player.AppliedDamage += _healthBar.AppliedDamage;
            
            _healthBar.AllHeartsLost += GameLose;
            _player.GameWon += GameWin;
            
            _windowsSwitcher.NextClicked += FinishGame;
            _windowsSwitcher.RetryClicked += RestartGame;

            // disable all
            _player.DisableMovement();
            _worker.enabled = false;
            _spawner.enabled = false;
            _windowsSwitcher.OpenWindow(Window.Tutorial);
        }

        private void OnDestroy()
        {
            _playerMovement.Moved -= _progressBar.Move;
            _player.AppliedDamage -= _healthBar.AppliedDamage;
            _progressBar.EnemyStopped -= ActivateFinalScene;
            
            _healthBar.AllHeartsLost -= GameLose;
            _player.GameWon -= GameWin;
            
            _windowsSwitcher.NextClicked -= FinishGame;
            _windowsSwitcher.RetryClicked -= RestartGame;
        }

        private void GameLose()
        {
            _player.DisableMovement();
            _spawner.enabled = false;
            _worker.enabled = false;
            _windowsSwitcher.OpenWindow(Window.Lose);
        }

        private void GameWin()
        {
            _player.DisableMovement();
            _spawner.enabled = false;
            _worker.enabled = false;
            _windowsSwitcher.OpenWindow(Window.Win);
        }

        public void StartGame()
        {
            _windowsSwitcher.CloseWindow(Window.Tutorial);
            _healthBar.FillAllHearts();
            _player.EnableMovement();
            _spawner.ResetTime();
            _worker.enabled = true;
            _spawner.enabled = true;
        }
        
        private void FinishGame()
        {
            Debug.Log("FinishGame");
            // отдать результат нани
        }
        
        private void RestartGame()
        {
            _windowsSwitcher.OpenWindow(Window.Tutorial);
            _backController.ResetBackground();
            _player.transform.position = new Vector2(-1.34f, -3.88f);
            _worker.transform.position = new Vector2(1.16f, -3.88f);
        }

        private void ActivateFinalScene()
        {
            _worker.enabled = false;
            _spawner.enabled = false;
        }
    }
}
