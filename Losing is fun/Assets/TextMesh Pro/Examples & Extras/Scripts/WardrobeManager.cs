using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;



public class WardrobeManager : MonoBehaviour
{
    public TMP_Dropdown outfitTopDropdown;
    public TMP_Dropdown outfitBottomDropdown;
    public TMP_Dropdown outfitShoesDropdown;
    public Image playerTop;
    public Image playerBottom;
    public Image playerShoes;

    public Sprite[] topSprites;
    public Sprite[] bottomSprites;
    public Sprite[] shoeSprites;

    public TMP_Dropdown scentDropdown;
    public Toggle[] itemToggles;
    public Image playerPreview;

    private string selectedTop;
    private string selectedBottom;
    private string selectedShoes;
    private string selectedScent;
    private List<string> selectedItems = new List<string>();


    void Start()
    {
        OnOutfitChanged();
        outfitTopDropdown.onValueChanged.AddListener(delegate { OnOutfitChanged(); });
        outfitBottomDropdown.onValueChanged.AddListener(delegate { OnOutfitChanged(); });
        outfitShoesDropdown.onValueChanged.AddListener(delegate { OnOutfitChanged(); });
    }

    public void OnOutfitChanged()
    {
        selectedTop = outfitTopDropdown.options[outfitTopDropdown.value].text;
        selectedBottom = outfitBottomDropdown.options[outfitBottomDropdown.value].text;
        selectedShoes = outfitShoesDropdown.options[outfitShoesDropdown.value].text;

        string outfitSummary = $"{selectedTop} + {selectedBottom} + {selectedShoes}";
        Debug.Log("Current outfit: " + outfitSummary);

         //Update layered preview sprites
        playerTop.sprite = topSprites[outfitTopDropdown.value];
        playerBottom.sprite = bottomSprites[outfitBottomDropdown.value];
        playerShoes.sprite = shoeSprites[outfitShoesDropdown.value];
    }


    public void ConfirmSelections()
    {
        selectedScent = scentDropdown.options[scentDropdown.value].text;
        selectedItems.Clear();

        foreach (Toggle toggle in itemToggles)
        {
            if (toggle != null && toggle.isOn)
            selectedItems.Add(toggle.name);
        }


        if (selectedItems.Count > 2)
        {
            Debug.LogWarning("Only 2 items allowed!");
            return;
        }

        string outfitSummary = $"{selectedTop} + {selectedBottom} + {selectedShoes}";
        Debug.Log($"Outfit: {outfitSummary}, Scent: {selectedScent}, Items: {string.Join(", ", selectedItems)}");

Debug.Log("Attempting to load RestaurantScene...");
SceneManager.LoadScene("RestaurantScene");

    }
}

