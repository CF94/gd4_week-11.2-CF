using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class WeatherSystem : MonoBehaviour
{
    public Button summerButton;
    public Button autumnButton;
    public Button rainButton;
    public Button winterButton;

    public Material snow;

    Color Orange = new Color(1.0f, 0.64f, 0.0f);

    [Header("Global")]
    public Material globalMaterial;
    public Light sunLight;
    public Material skyboxMaterial;
    public TMP_Text weatherText;

    [Header("Winter Assets")]
    public ParticleSystem winterParticleSystem;
    public Volume winterVolume;

    [Header("Rain Assets")]
    public ParticleSystem rainParticleSystem;
    public Volume rainVolume;

    [Header("Autumn Assets")]
    public ParticleSystem autumnParticleSystem;
    public Volume autumnVolume;

    [Header("Summer Assets")]
    public ParticleSystem summerParticleSystem;
    public Volume summerVolume;

    private void Start()
    {       
        Summer();

        Material snow = GetComponent<Material>();

        summerButton = GetComponent<Button>();
        summerButton.onClick.AddListener(Summer);

        autumnButton = GetComponent<Button>();
        autumnButton.onClick.AddListener(Autumn);

        rainButton = GetComponent<Button>();
        rainButton.onClick.AddListener(Rain);

        winterButton = GetComponent<Button>();
        winterButton.onClick.AddListener(Rain);

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Update()
    {
        
    }

    public void Winter()
    {
        Debug.Log("Winter.");
        summerVolume.enabled = false;
        winterVolume.enabled = true;
        autumnVolume.enabled = false;
        rainVolume.enabled = false;


        snow.SetColor("_SnowColor", Color.white);
        snow.SetFloat("_SnowFade", 1);
        snow.SetFloat("_Smoothness", 0f);
    }

    public void Rain()
    {
        Debug.Log("Rain.");
        summerVolume.enabled = false;
        winterVolume.enabled = false;
        autumnVolume.enabled = false;
        rainVolume.enabled = true;

        snow.SetFloat("_Smoothness", 0.75f);
        snow.SetFloat("_SnowFade", 0f);
    }

    public void Autumn()
    {
        Debug.Log("Autumn.");
        summerVolume.enabled = false;
        winterVolume.enabled = false;
        autumnVolume.enabled = true;
        rainVolume.enabled = false;

        snow.SetFloat("_SnowFade", 0.25f);
        snow.SetColor("_SnowColor", Orange);
        snow.SetFloat("_Smoothness", 0f);
    }

    public void Summer()
    {
        summerVolume.enabled = true;
        winterVolume.enabled = false;
        autumnVolume.enabled = false;
        rainVolume.enabled = false;
        Debug.Log("Summer.");

        snow.SetFloat("_Smoothness", 0f);
        snow.SetFloat("_SnowFade", 0f);
    }
}
