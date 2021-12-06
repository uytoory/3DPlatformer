using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] int _segments = 10;

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        _lineRenderer.enabled = true;
        
        float interpolant = Vector3.Distance(a, b) / length;
        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        _lineRenderer.positionCount = _segments +1;
        for (int i = 0; i < _segments + 1; i++)
        {
            _lineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float) i / _segments));

        }
    }

    public void Hide()
    {
        _lineRenderer.enabled = false;
    }    
}
