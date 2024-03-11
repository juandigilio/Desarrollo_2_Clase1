using TMPro;
using UnityEngine;

public class TriggerEnterExit : MonoBehaviour
{
    public TMP_Text text;
    
    public Color onTriggerEnterColor = Color.magenta;
    
    public Color onTriggerExitColor = Color.blue;

    public AnimationCurve alphaCurve = AnimationCurve.EaseInOut(0, 1, 1, 0.1f);

    private Color _currentColor;
    
    private Material _material;

    private float lastTriggerTime;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _currentColor = onTriggerExitColor;
    }

    private void Update()
    {
        var alpha = alphaCurve.Evaluate(Time.time - lastTriggerTime);
        _currentColor.a = alpha;
        text.alpha = alpha;
        _material.color = _currentColor;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        UpdateTriggerTime();
        text.text = "Enter";
        _currentColor = onTriggerEnterColor;
    }

    private void OnTriggerExit(Collider other)
    {
        UpdateTriggerTime();
        text.text = "Exit";
        _currentColor = onTriggerExitColor;
    }

    private void UpdateTriggerTime()
    {
        lastTriggerTime = Time.time;
    }
}