using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public event UnityAction EnemyStopped;
    
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private Transform _handleWorker;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void Move(float playerPosition)
    {
        _slider.value = playerPosition / _finishPoint.position.x;

        if (_slider.value >= 0.763f)
        {
            EnemyStopped?.Invoke();
            _handleWorker.SetParent(transform);
        }
            
    }
}
