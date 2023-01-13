using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Jungle.Minigames.Chase
{
    public class HealthBar : MonoBehaviour
    {
        public event UnityAction AllHeartsLost;
        
        [SerializeField] private Heart _heartTemplate;
        [SerializeField] private int _countOfHearts;
        [SerializeField] private Transform _container;
        
        private List<Heart> _hearts = new List<Heart>();
        private int _currentHeartsCount;

        private void Awake()
        {
            RenderHearts();
        }

        public void AppliedDamage()
        {
            if (_currentHeartsCount > 0)
                DestroyHeart();
        }

        private void DestroyHeart()
        {
            _hearts.Last(x => x.IsFull).EmptyHeart();
            _currentHeartsCount--;
            
            if (_currentHeartsCount == 0)
                AllHeartsLost?.Invoke();
                
        }

        private void DestroyAllHearts()
        {
            foreach (var heart in _hearts)
            {
                heart.EmptyHeart();
            }

            _currentHeartsCount = 0;
        }

        private void FillAllHearts()
        {
            foreach (var heart in _hearts)
            {
                heart.FillHeart();
            }

            _currentHeartsCount = _countOfHearts;
        }

        private void RenderHearts()
        {
            for (int i = 0; i < _countOfHearts; i++)
            {
                var heart = Instantiate(_heartTemplate, _container.transform.position, _container.transform.rotation, _container);
                heart.FillHeart();
                _hearts.Add(heart);
            }
        }
    }
}
