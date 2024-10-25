using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMaterialManager : MonoBehaviour
{
    [Tooltip("List of skybox materials to switch between")]
    public List<Material> skyMaterials = new List<Material>();  // A list of skybox materials

    [Tooltip("Time (in seconds) between switching skybox materials")]
    public float switchInterval = 10.0f;  // Time in seconds between switching materials

    private int currentMaterialIndex = 0;  // Tracks the current material in the list

    void Start()
    {
        // Set the initial skybox material if the list has materials
        if (skyMaterials.Count > 0)
        {
            RenderSettings.skybox = skyMaterials[currentMaterialIndex];
        }

        // Start the coroutine to switch skybox materials at intervals
        StartCoroutine(SwitchSkyboxMaterial());
    }

    IEnumerator SwitchSkyboxMaterial()
    {
        while (true)
        {
            // Wait for the specified switch interval
            yield return new WaitForSeconds(switchInterval);

            // Switch to the next skybox material in the list
            currentMaterialIndex = (currentMaterialIndex + 1) % skyMaterials.Count;  // Loop back to the first material
            RenderSettings.skybox = skyMaterials[currentMaterialIndex];
        }
    }

    // Optional method to manually set a skybox material by index
    public void SetSkyMaterial(int index)
    {
        if (index >= 0 && index < skyMaterials.Count)
        {
            RenderSettings.skybox = skyMaterials[index];
            currentMaterialIndex = index;
        }
    }
}
