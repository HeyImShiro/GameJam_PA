using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity


public class PostProcessing : MonoBehaviour
{
    public bool healthIndicator;
    private Volume vol;
    private Vignette vig;

    // Start is called before the first frame update
    void Start()
    {
        vol = gameObject.GetComponent<Volume>();
        vol.profile.TryGetSetting
    }

    // Update is called once per frame
    void Update()
    {
        if (healthIndicator)
        {
            float output;
            output = (Mathf.Sin(Time.time) - -1) / (1 - -1) * (0.3f - 0.2f) + 0.2f;
            vol.
        }
    }
    private Vignette GetVignette()
    {
        for (int i = 0; i < vol.profile.components.Count; i++)
        {
            if (vol.profile.components is Vignette)
            {
                return (Vignette)vol.profile.components;
            }
        }
        return null;
    }
}
