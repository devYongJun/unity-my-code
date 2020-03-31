using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform from;
    public Transform to;

    public Gradient color;

    private LineRenderer _lineRender;

    private void Start()
    {
        _lineRender = GetComponent<LineRenderer>();
        _lineRender.colorGradient = color;
    }

    private void Update()
    {
        _lineRender.SetPosition(0, from.position);
        _lineRender.SetPosition(1, to.position);
    }
}
