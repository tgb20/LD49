using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Waver : MonoBehaviour
{
    public static Waver Instance { get; set; }

    public float catchSpeed = 0.001f;

    public Light sky;
    
    public float AmplitudeX = 1f;
    public float AmplitudeY = 1f;
    public float LengthX = 2f;
    public float LengthY = 2f;
    public float SpeedX = 1f;
    public float SpeedY = 1f;
    public float SkyColor = 1f;
    private float _offsetX = 0f;
    private float _offsetY = 0f;

    private float setAmpX = 0f;
    private float setAmpY = 0f;
    private float setSpeedX = 1f;
    private float setSpeedY = 1f;
    private float setColor = 1f;
    
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(this); }
    }

    private void Start()
    {
        InvokeRepeating("GenerateNewWaves", 30, 30);
    }

    private void Update()
    {
        _offsetX += Time.deltaTime * SpeedX;
        _offsetY += Time.deltaTime * SpeedY;
        
        sky.color = new Color(SkyColor, SkyColor, SkyColor, 1);
    }

    private void FixedUpdate()
    {
        if (AmplitudeX > setAmpX)
        {
            AmplitudeX -= catchSpeed;
        } else if (AmplitudeX < setAmpX)
        {
            AmplitudeX += catchSpeed;
        }
        
        if (AmplitudeY > setAmpY)
        {
            AmplitudeY -= catchSpeed;
        } else if (AmplitudeY < setAmpY)
        {
            AmplitudeY += catchSpeed;
        }
        
        if (SpeedX > setSpeedX)
        {
            SpeedX -= catchSpeed;
        } else if (SpeedX < setSpeedX)
        {
            SpeedX += catchSpeed;
        }
        
        if (SpeedY > setSpeedY)
        {
            SpeedY -= catchSpeed;
        } else if (SpeedY < setSpeedY)
        {
            SpeedY += catchSpeed;
        }
        
        if (SkyColor > setColor)
        {
            SkyColor -= catchSpeed;
        } else if (SkyColor < setColor)
        {
            SkyColor += catchSpeed;
        }
    }

    public float GetWaveHeight(float x, float y)
    {
        
        return (AmplitudeX * Mathf.Sin(x / LengthX + _offsetX)) + (AmplitudeY * Mathf.Cos(y / LengthY + _offsetY));
    }


    private void GenerateNewWaves()
    {

        var angle = Random.Range(0f, 365f);

        var x = Mathf.Cos(angle + 90f);
        var y = Mathf.Sin(angle + 90f);

        var norm = new Vector2(x, y).normalized;
        
        var ampVec = norm * Random.Range(0f, 0.65f);
        var speedVec = norm * Random.Range(0f, 2f);

        setAmpX = ampVec.x;
        setAmpY = ampVec.y;
        setSpeedX = speedVec.x;
        setSpeedY = speedVec.y;

        StateManager.Instance.waveAngle = (int) (angle - 90);

        var stormStrength = 1 - ((Mathf.Abs(setAmpX) + Mathf.Abs(setAmpY)) / 1.3f);

        setColor = stormStrength;
    }
    
}
