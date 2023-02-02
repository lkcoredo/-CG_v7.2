using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class DialogueSystem : MonoBehaviour
{

    //DialogueManager
    public string username;
    public int maxMessages = 4;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    //DialogueSystem
    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;

    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;
    public bool phraseproximite = false;

    public AudioClip audioClip;
    AudioSource audioSource;

    public string MessageEnCours;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogueText.text = "";
    }

    //DialogueManager

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            chatBox.Select();
        }

        if (chatBox.text != "")
        {

            

            if (Input.GetKeyDown(KeyCode.Return))
            {
                MessageEnCours = chatBox.text;
                SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);

                for (int i = 10; i < 40; i++)
                {
                    string i_str = "" + i;
                    var input = i_str.ToCharArray();
                    var isolate = input[1];
                    float randomNumber = Random.Range(0, 9);
                    string dialogue_line = isolate + "" + randomNumber.ToString();
                    int dialogue_line_int = Int32.Parse(dialogue_line);



                        if (chatBox.text.Contains(i_str))
                    {
                        SendMessageToChat("[" + Names + "] " + dialogueLines[dialogue_line_int], Message.MessageType.info);

                        if (chatBox.text.Contains("?"))
                        {
                            if (chatBox.text.Contains("rumeur"))
                            {
                                SendMessageToChat("[" + Names + "] " + dialogueLines[1], Message.MessageType.info);
                            }

                            // RelationAvecJoueur

                            /* if (chatBox.text.Contains("quete"))
                            {
                                SendMessageToChat("[" + Names + "] " + dialogueLines[2], Message.MessageType.info);
                            }

                                                      if (chatBox.text.Contains("quand"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[3], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("quoi"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[4], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("comment"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[5], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("où"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[6], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("pourquoi"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[7], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("rejoindre"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[8], Message.MessageType.info);
                                                       }

                                                       if (chatBox.text.Contains("battre"))
                                                       {
                                                           SendMessageToChat("[" + Names + "] " + dialogueLines[9], Message.MessageType.info);
                                                       }*/
                        }
                    }

                    

                    

                }
                
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SendMessageToChat("You pressed the space key !", Message.MessageType.info);
        }

    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;

        }

        return color;
    }

    //DialogueSystem

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);

        

        if (dialogueActive == true)
        {
            
            dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
        nameText.text = Names;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                /*Cursor.lockState = CursorLockMode.None;
                Screen.lockCursor = true;
                Cursor.visible = true;*/
                chatBox.Select();
                StartCoroutine(StartDialogue());
            }
        }
        StartDialogue();
    }

    public void Proximite()
    {
        if (phraseproximite == false)
        {
            SendMessageToChat("[" + Names + "] " + dialogueLines[2], Message.MessageType.info);
            phraseproximite = true;
        }
    }

    private IEnumerator StartDialogue()
    {
        /*        SendMessageToChat("[" + Names + "] " + dialogueLines[0] + "", Message.MessageType.info);
                print("0 :" + dialogueLines[0]);
                print("1 :" + dialogueLines[1]);
                print("2 :" + dialogueLines[2]);*/

        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;

                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));


                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }

            while (true)
            {
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
        }


    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(DialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);

                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);

                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);
                    }
                }
                else
                {
                    dialogueEnded = false;
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
        phraseproximite = false;
        /*Cursor.lockState = CursorLockMode.Locked;
        Screen.lockCursor = false;
        Cursor.visible = false;*/

    }

    public void OutOfRange()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            dialogueGUI.SetActive(false);
            dialogueBoxGUI.gameObject.SetActive(false);
            phraseproximite = false;
            /*Cursor.lockState = CursorLockMode.Locked;
            Screen.lockCursor = false;
            Cursor.visible = false;*/
        }
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }
}