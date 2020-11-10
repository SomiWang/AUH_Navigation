using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadVFXController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5.0f;
    private readonly string shaderName = "UnityLibrary/Patterns/ScrollingFill";
    private readonly string fillProperty = "_Fill";
    private Renderer render;
    private Coroutine increaseRoadFillCoroutine;
    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        if (render?.material != null)
        {
            render.material.SetFloat(fillProperty, 0.0f);
            if (increaseRoadFillCoroutine != null) StopCoroutine(increaseRoadFillCoroutine);
            increaseRoadFillCoroutine = StartCoroutine(IncreaseFill());
        }
    }
    private IEnumerator IncreaseFill()
    {
        float time = 0.0f;
        float fill = render.material.GetFloat(fillProperty);
        while (fill != 1.0f)
        {
            time += Time.deltaTime;
            render.material.SetFloat(fillProperty, Mathf.SmoothStep(0.0f, 1.0f, time * m_Speed));
            yield return null;
        }
        increaseRoadFillCoroutine = null;
    }
}
