using TMPro;
using UnityEngine;

public class CollisionStayColoring : MonoBehaviour
{
    public TMP_Text text;

    public Color OnCollisionStayColor = Color.red;
    
    public Color OnAloneColor = Color.green;

    private Color _currentColor;
    
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _currentColor = OnAloneColor;
    }

    private void Update()
    {
        _material.color = _currentColor;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        text.text = "Stay";
        _currentColor = OnCollisionStayColor;
    }

    private void OnCollisionExit(Collision other)
    {
        text.text = "Alone";
        _currentColor = OnAloneColor;
    }
}