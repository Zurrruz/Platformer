using UnityEngine;

public class RotateHealthBarPanel : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private InputReader _inputParameters;

    private Vector3 _lookRight;
    private Vector3 _lookLeft;

    private void Awake()
    {
        _lookRight = _canvas.transform.localScale;
        _lookLeft = _lookRight * - 1;
    }

    void Update()
    {
        if (_inputParameters.Moving != 0)
        {
            if (_inputParameters.Moving < 0)
                _canvas.transform.localScale = _lookLeft;
            else
                _canvas. transform.localScale = _lookRight;
        }
    }
}
