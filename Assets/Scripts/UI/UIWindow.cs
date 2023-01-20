using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIWindow : MonoBehaviour
{
    public event UnityAction RetryClicked;
    public event UnityAction NextClicked;
    
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _nextButton;
    
    private CanvasGroup _canvasGroup;
    
    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_retryButton != null)
            _retryButton.onClick.AddListener(OnRetryClicked);
        if (_nextButton != null)
            _nextButton.onClick.AddListener(OnNextClicked);
    }

    private void OnDestroy()
    {
        if (_retryButton != null)
            _retryButton.onClick.RemoveListener(OnRetryClicked);
        if (_nextButton != null)
            _nextButton.onClick.RemoveListener(OnNextClicked);
    }

    private void OnRetryClicked()
    {
        RetryClicked?.Invoke();
    }

    private void OnNextClicked()
    {
        NextClicked?.Invoke();
    }
}
