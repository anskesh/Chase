using UnityEngine;
using UnityEngine.Events;

namespace Jungle.Minigames.Chase
{
    public class WindowsSwitcher : MonoBehaviour
    {
        public event UnityAction RetryClicked;
        public event UnityAction NextClicked;
            
        [SerializeField] private UIWindow[] _windows;

        private void Awake()
        {
            _windows[(int) Window.Lose].RetryClicked += OnRetryClicked;
            _windows[(int) Window.Lose].NextClicked += OnNextClicked;
            _windows[(int) Window.Win].RetryClicked += OnRetryClicked;
            _windows[(int) Window.Win].NextClicked += OnNextClicked;
        }

        private void OnRetryClicked()
        {
            RetryClicked?.Invoke();
        }

        private void OnNextClicked()
        {
            NextClicked?.Invoke();
        }

        public void OpenWindow(Window window)
        {
            CloseAllWindows();
            _windows[(int) window].Open();
        }

        private void CloseAllWindows()
        {
            for (int i = 0; i < _windows.Length; i++)
                CloseWindow((Window) i);
        }
        
        public void CloseWindow(Window window)
        {
            _windows[(int) window].Close();
        }
    }

    public enum Window
    {
        Tutorial,
        Lose,
        Win
    }
}
