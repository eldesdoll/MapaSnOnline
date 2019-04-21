using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CharacterCSS : MonoBehaviour
{
    public List<Character> characters = new List<Character>();
    public GameObject charCellPrefab;

    void Start()
    {
        foreach (Character character in characters)
        {
            SpawnCharacterCell(character);
        }
    }

    private void SpawnCharacterCell(Character character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        charCell.name = character.characterName;

        Image artwork = charCell.transform.Find("artwork").GetComponent<Image>();
        TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.characterSprite;
        name.text = character.characterName;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        artwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
    }

    public Vector2 uiPivot(Sprite sprite)
    {
        Vector2 pixelSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 pixelPivot = sprite.pivot;
        return new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);
    }
}
