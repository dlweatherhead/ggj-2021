using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TMP_Text dialogueText;

    public float textTime = 3f;
    
    public void SetText(string text)
    {
        dialogueText.text = text;
        Invoke("ClearText", textTime);
    }

    // Update is called once per frame
    void ClearText()
    {
        dialogueText.text = "";
    }
}
