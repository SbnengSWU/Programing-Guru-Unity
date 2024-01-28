using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage;
    private AudioSource chatSound;

    [System.Serializable]
    public struct ConversationLine
    {
        public string speaker;
        [TextArea(3, 10)]
        public string text;
        public Sprite characterSprite;
        public AudioClip soundEffect;
        public float volume; // ȿ������ ����
    }

    public ConversationLine[] conversationLines;
    private int currentIndex = 0;
    private bool isTyping = false;
    private bool canProceed = false;

    void Start()
    {
        chatSound = GetComponent<AudioSource>();
        if (chatSound == null)
        {
            chatSound = gameObject.AddComponent<AudioSource>();
        }

        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        canProceed = false;

        string currentText = "";
        string fullText = conversationLines[currentIndex].text;

        // ȿ���� ����
        if (conversationLines[currentIndex].soundEffect != null)
        {
            chatSound.clip = conversationLines[currentIndex].soundEffect;
            chatSound.volume = conversationLines[currentIndex].volume;
            chatSound.Play();
        }

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
        canProceed = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Ÿ���� �߿� �����̽��ٸ� ������ ��ü �ؽ�Ʈ�� �� ���� ǥ��
                StopAllCoroutines();
                dialogueText.text = conversationLines[currentIndex].text;
                isTyping = false;
                canProceed = true;
            }
            else if (canProceed)
            {
                canProceed = false;

                if (currentIndex < conversationLines.Length - 1)
                {
                    currentIndex++;
                    StartCoroutine(TypeText());
                    nameText.text = conversationLines[currentIndex].speaker;
                    characterImage.sprite = conversationLines[currentIndex].characterSprite;
                }
                else
                {
                    StartCoroutine(TransitionToNextScene());
                }
            }
        }
    }

    IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(1.0f);

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "EventScene1")
        {
            SceneManager.LoadScene("EventScene2");
        }
        else if (currentSceneName == "EventScene2")
        {
            SceneManager.LoadScene("PlayerRoom");
        }
    }
}
