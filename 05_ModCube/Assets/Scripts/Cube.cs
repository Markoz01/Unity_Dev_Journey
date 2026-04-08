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

    private float verticalInput;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetRandomColor();
        }

        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            SetOpacity(verticalInput);
        }

    }

    private void SetRandomColor()
    {
        _material.color = _colors[Random.Range(0, _colors.Length)];
    }

    private void SetOpacity(float opacity)
    {
        Color color = _material.color;
        color.a = Mathf.Clamp01(color.a + opacity * Time.deltaTime);
        _material.color = color;
    }

}
