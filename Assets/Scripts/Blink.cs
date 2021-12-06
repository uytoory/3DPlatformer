using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer[] _renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                for (int m = 0; m < _renderers[i].materials.Length; m++)
                {
                    _renderers[i].materials[m].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f) * 0.5f + 0.5f, 0, 0, 0));
                }
                
            }    
            yield return null;
        }
        
    }
}
