using UnityEngine;

public class PanelSelect : MonoBehaviour
{
    public GameObject startPanel;               //The panel the app should open with
    public GameObject optionsPanel;             //The panel for settings selection

    private GameObject _selectedPanel = null;   //The currently selected and visible panel
    public GameObject SelectedPanel
    {
        get { return _selectedPanel; }
        set
        {
            //Don't set the selected panel to the same panel or a null panel
            if (_selectedPanel == value || value == null) return;

            //Switch panels
            _selectedPanel.SetActive(false);
            value.SetActive(true);

            _selectedPanel = value;
        }
    }

    void Start()
    {
        startPanel.SetActive(true);
        _selectedPanel = startPanel;
    }
}