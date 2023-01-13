using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class Chase : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private WindowsSwitcher _windowsSwitcher;

        private void Awake()
        {
            _player.AppliedDamage += _healthBar.AppliedDamage;
            _healthBar.AllHeartsLost += GameLose;
        }

        private void OnDestroy()
        {
            _player.AppliedDamage -= _healthBar.AppliedDamage;
            _healthBar.AllHeartsLost -= GameLose;
        }

        private void GameLose()
        {
            _player.DisableMovement();
            _windowsSwitcher.OpenWindow(Window.Lose);
        }

        private void RestartGame()
        {
            _windowsSwitcher.CloseAllWindows();
            _player.EnableMovement();
        }
    }
}
