using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FurnitureMenu : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject buttonTemplate;    
    public Transform buttonParent;       
    public Canvas menuCanvas;            

    [Header("Furniture Prefabs")]
    public GameObject[] furniturePrefabs;

    [Header("Spawn Settings")]
    public Transform spawnPoint;         



    private bool menuOpen = false;

    void Start()
    {
        menuCanvas.enabled = false;  

        // Build buttons at runtime
        foreach (GameObject prefab in furniturePrefabs)
        {
            GameObject btn = Instantiate(buttonTemplate, buttonParent);
            btn.SetActive(true);

            // Set label
            TMP_Text label = btn.GetComponentInChildren<TMP_Text>();
            label.text = prefab.name;

            // Add click listener
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                SpawnFurniture(prefab);
            });
        }
    }


    void ToggleMenu()
    {
        menuOpen = !menuOpen;
        menuCanvas.enabled = menuOpen;
    }

    void SpawnFurniture(GameObject prefab)
    {
        float offset = 0.5f;
        Vector3 spawnPos = spawnPoint.position + spawnPoint.forward * offset;
        Quaternion spawnRot = spawnPoint.rotation;

        GameObject obj = Instantiate(prefab, spawnPos, spawnRot);

        var grab = obj.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();

        var manager = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.XRInteractionManager>();

        if (grab != null && manager != null)
        {
            grab.interactionManager = manager;
        }

        // Instantiate(prefab, spawnPos, spawnRot);

        // Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
