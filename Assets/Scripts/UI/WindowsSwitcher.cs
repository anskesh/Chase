using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class WindowsSwitcher : MonoBehaviour
    {
        [SerializeField] private CanvasGroup[] _windows;

        public void OpenWindow(Window window)
        {
            _windows[(int)window].alpha = 1;
            _windows[(int)window].interactable = true;
            _windows[(int)window].blocksRaycasts = true;
            
        }

        public void CloseAllWindows()
        {
            for (int i = 0; i < _windows.Length; i++)
            {
                CloseWindow((Window) i);
            }
        }
        
        
        private void CloseWindow(Window window)
        {
            _windows[(int)window].alpha = 0;
            _windows[(int)window].interactable = false;
            _windows[(int)window].blocksRaycasts = false;
        }
    }

    public enum Window
    {
        Tutorial,
        Lose,
        Win
    }
}
