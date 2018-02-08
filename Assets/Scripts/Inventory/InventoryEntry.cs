using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class InventoryEntry : MonoBehaviour
{

    public Image icon;
    public Text itemName;
    public Text description;
    public Text itemLevel;
    private Vector3 positionInScene;
    private Button button;

    // Use this for initialization
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // Emit event
        Debug.Log("Click");
    }

    public void SetItem(InventoryItem item)
    {
        itemName.text = item.name;
        description.text = item.description;
        itemLevel.text = item.level.ToString();
    }




}

