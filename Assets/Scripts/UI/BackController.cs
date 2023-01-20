using UnityEngine;

public class BackController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _back1;
    [SerializeField] private Transform _back2;
    
    private float _distance;

    private void Awake()
    {
        _distance = _back1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        CheckBackgroundPosition();
    }

    public void ResetBackground()
    {
        _back1.localPosition = new Vector2(_distance, 0f);
        _back2.localPosition = new Vector2(0f, 0f);
    }
    
    private void CheckBackgroundPosition()
    {
        var distance = _camera.transform.position.x - _distance;
        
        if (_back1.transform.position.x <= distance)
            _back1.localPosition = new Vector3(_back2.transform.position.x + _distance, 0);
        
        if (_back2.transform.position.x <= distance)
            _back2.localPosition = new Vector3(_back1.transform.position.x + _distance, 0);
    }
}
