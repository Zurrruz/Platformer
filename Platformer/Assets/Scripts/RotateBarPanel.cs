using UnityEngine;

public class RotateBarPanel : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private InputReader _inputParameters;

    private Vector3 _lookRight;
    private Vector3 _lookLeft;

    private void Awake()
    {
        _lookRight = _canvas.transform.localScale;
        _lookLeft = new Vector3( _lookRight.x * - 1, _lookRight.y , _lookRight.z);        
    }

    void Update()
    {
        if (_inputParameters.Moving != 0)
            _canvas.transform.localScale = _inputParameters.Moving < 0 ? _lookLeft : _lookRight;
    }
}
