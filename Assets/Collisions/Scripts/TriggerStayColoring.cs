using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerStayColoring : MonoBehaviour
{
    public TMP_Text text;

    public Color OnTriggerStayColor = Color.red;
    
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

    private void OnTriggerStay(Collider other)
    {
        text.text = "Stay";
        _currentColor = OnTriggerStayColor;
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "Alone";
        _currentColor = OnAloneColor;
    }
}