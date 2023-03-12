using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int id;

    private SoundPlayerManager _soundPlayerManager;

    public void OnDrop(PointerEventData _eventData)
    {
        Debug.Log("Item dropped");
        if (_eventData.pointerDrag != null)
        {
            _soundPlayerManager.EligeAudioP(0, 0.2f);
            if (_eventData.pointerDrag.GetComponent<DragAndDrop>().getId() == id)
            {
                Debug.Log("correct");
            }
            else
            {
                Debug.Log("incorrect");
            }
            _eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _soundPlayerManager = GetComponent<SoundPlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getId()
    {
        return id;
    }
}
