using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Material currentMaterial;

    private float _currentValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentValue += Time.deltaTime * speed;
        currentMaterial.mainTextureOffset = new Vector2(_currentValue, 0f);
    }
}
