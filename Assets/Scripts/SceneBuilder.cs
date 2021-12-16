using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [Header("Presets")]
    public ScenePreset scenePreset;

    [Header("Tranforms")]
    [SerializeField] Transform backgroundPos;
    [SerializeField] Transform midgroundPos;
    [SerializeField] Transform windowPos;

    [Header("Waether")]
    [SerializeField] WindZone windZone;

    private void Start()
    {
        //pick right Prefab
        GetPreset(PlayerPrefs.GetString("Emotion"));

        //build scene From Prefab 
        BuildScene(scenePreset);
        UpdateWeather(scenePreset); 
    }

    void GetPreset(string name)
    {
        string searchWord = "Presets/" + name ;
        print(searchWord);
        Object presetObject = Resources.Load<ScenePreset>(searchWord);
        scenePreset = (ScenePreset)presetObject; 
    }
    void BuildScene(ScenePreset preset)
    {
        GameObject window = Instantiate(preset.frameObject,windowPos);
        GameObject background = Instantiate(preset.background, backgroundPos);
    }
    void UpdateWeather(ScenePreset preset)
    {
        if (preset.wind)
        {
            windZone.windMain = preset.windStrengh;
        }
        else
            windZone.windMain = 0; 
    }
}
