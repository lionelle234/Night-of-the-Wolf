using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject noteBox;
    [SerializeField] private TextMeshProUGUI noteText;
    [SerializeField] private DialogueObject[] noteAssets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoteRead(int noteIndex)
    {
        noteText.text = noteAssets[noteIndex].dialogueAsset;
        noteBox.SetActive(true);    
    }

    public void NoteClose()
    {
        noteBox.SetActive(false);
    }
}
