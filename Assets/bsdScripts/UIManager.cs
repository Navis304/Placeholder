using UnityEngine;
using System.Collections;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] public string[] npcNormalTalk;
    [SerializeField] public string[][] specialNpcTalk;
    [SerializeField] private GameObject menuObj;
    [SerializeField] public int textSpeedOption = 2;
    [SerializeField] public TMP_Text chatbox;
    [SerializeField] private float timeToWait;
    [SerializeField] public bool fSkip = false;
    [SerializeField] public bool eneded = false;
    [SerializeField] public int dayCounter = 0;
    private void Start()
    {
        //TextWriter("Siema ja robert sie nazywam :3");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            fSkip = true;
        }
        if(fSkip && Input.GetKeyDown(KeyCode.Return))
        {
            chatbox.text = "";
            //fSkip = false;
        }
        if (!menuObj.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            menuObj.SetActive(true);
        }
        else if(menuObj.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            menuObj.SetActive(false);
        }
    }
    public void TextWriter(string textToWrite)
    {
        if(chatbox.text == "" && !eneded)
        {
            StartCoroutine(TextWriterCore(0, textToWrite));
        }
    }
    public IEnumerator TextWriterCore(int i, string text)
    {
        if (fSkip)
        {
            StopAllCoroutines();
            chatbox.text = text;
            eneded = true;
        }
        else
        {
            switch (textSpeedOption)
            {
                case 1:
                    timeToWait = 0.05f;
                    break;
                case 2:
                    timeToWait = 0.1f;
                    break;
                case 3:
                    timeToWait = 0.2f;
                    break;
                case 4:
                    timeToWait = 0.5f;
                    break;
            }
            if (i < text.Length)
            {
                chatbox.text += text[i];
                yield return new WaitForSeconds(timeToWait);
                StartCoroutine(TextWriterCore(i + 1, text));
            }
        }
    }
    public void NextInTalkFunction()
    {
        eneded = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
