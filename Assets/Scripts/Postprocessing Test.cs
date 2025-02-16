using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostprocessingTest : MonoBehaviour
{
    public Volume globalVolume;
    private Bloom bloom;
    private ColorAdjustments colorAdjustments;

    //default values

    #region Default Color
    float defaultBloomIntensity;
    Color defaultTintColor;

    float defaultColorAdjustmentsPost_;
    float defaultColAdjustCont_;
    Color defaultColAdjustFilter;
    float defaulColAdjustHue_;
    float defaultColAdjustSat_;
    float defaultColorAdjustmentsSat_;
    #endregion
    void Start()
    {
        globalVolume.profile.TryGet(out bloom);
        globalVolume.profile.TryGet(out colorAdjustments);

        //saving default settings in memory
        defaultBloomIntensity = bloom.intensity.value;
        defaultTintColor = bloom.tint.value;

        defaultColorAdjustmentsSat_ = colorAdjustments.saturation.value;
        defaultColAdjustCont_ = colorAdjustments.contrast.value;
        defaultColAdjustFilter = colorAdjustments.colorFilter.value;
        defaulColAdjustHue_ = colorAdjustments.hueShift.value;
        defaultColAdjustSat_ = colorAdjustments.saturation.value;
        defaultColorAdjustmentsSat_ = colorAdjustments.saturation.value;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Gray();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Ocean();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Default();
        }
    }
    void Gray()
    {
        bloom.intensity.value = 10f;
        bloom.tint.value = Color.red;
        colorAdjustments.saturation.value = -100f;
    }
    void Red()
    {

    }
    void Ocean()
    {
        bloom.intensity.value = 0.5f;
        bloom.scatter.value = 0.75f;
        bloom.tint.value = new Color(58, 56, 79);

        colorAdjustments.postExposure.value = -1f;
        colorAdjustments.contrast.value = 41f;
        colorAdjustments.colorFilter.value = new Color(148, 228, 243);
        colorAdjustments.hueShift.value = -4f;
        colorAdjustments.saturation.value = 25f;
    }

    void Default()
    {
        bloom.intensity.value = default;
        bloom.scatter.value = default;
        bloom.tint.value = default;

        colorAdjustments.postExposure.value = default;
        colorAdjustments.contrast.value = default;
        colorAdjustments.colorFilter.value = default;
        colorAdjustments.hueShift.value = default;
        colorAdjustments.saturation.value = default;
    }
}
