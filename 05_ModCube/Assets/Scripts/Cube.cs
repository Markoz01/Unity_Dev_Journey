using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField] private float _rotationX = 0.0f;
    [SerializeField] private float _rotationY = 0.0f;
    [SerializeField] private float _rotationZ = 0.0f;

    private Material _material;

    // Array of colors to choose from
    private Color[] _colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan
    };

    void Start()
    {
        _material = Renderer.material;
        
        SetRandomColor();
    }
    
    void Update()
    {
        transform.Rotate(_rotationX * Time.deltaTime, _rotationY * Time.deltaTime, _rotationZ * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetRandomColor();
        }

    }

    private void SetRandomColor()
    {
        _material.color = _colors[Random.Range(0, _colors.Length)];
    }

}
