using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionEnterExit : MonoBehaviour
{
    public TMP_Text text;
    
    public Color onCollisionEnterColor = Color.magenta;
    
    public Color onCollisionExitColor = Color.blue;

    public AnimationCurve alphaCurve = AnimationCurve.EaseInOut(0, 1, 1, 0.1f);

    private Color _currentColor;
    
    private Material _material;

    private float lastCollisionTime;
    
    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _currentColor = onCollisionExitColor;
    }

    private void Update()
    {
        var alpha = alphaCurve.Evaluate(Time.time - lastCollisionTime);
        _currentColor.a = alpha;
        text.alpha = alpha;
        _material.color = _currentColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        UpdateLastCollisionTime();
        text.text = "Enter";
        _currentColor = onCollisionEnterColor;
    }

    private void OnCollisionExit(Collision other)
    {
        UpdateLastCollisionTime();
        text.text = "Exit";
        _currentColor = onCollisionExitColor;
    }

    private void UpdateLastCollisionTime()
    {
        lastCollisionTime = Time.time;
    }
}