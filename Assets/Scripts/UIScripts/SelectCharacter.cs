using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class SelectCharacter : MonoBehaviour
{

    public Sprite[] CharacterSprites;
    public  Dictionary<int, bool> mSpriteEnabledTable;
    private Image image;
    public static SelectCharacter instance = null;
    int currentImage = 0;
    public Button SelectButton;
    // Use this for initialization
    void Start ()
    {
        instance = this;
        image = GetComponent<Image>();
        image.sprite = CharacterSprites[currentImage];
        mSpriteEnabledTable = new Dictionary<int, bool>();
        for(int i = 0; i < CharacterSprites.Length; i++)
        {
            mSpriteEnabledTable.Add(i, false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(InputManager.CurrentDirection == InputManager.SwipeDirection.RIGHT)
        {
            MoveToNextCharacter();
            //Debug.Log("CharacterMovedRight");
        }
        else if(InputManager.CurrentDirection == InputManager.SwipeDirection.LEFT)
        {
            MoveToPreviousCharacter();
            //Debug.Log("CharacterMovedLeft");
        }
	}

    IEnumerator SwapCharacter()
    {
        yield return new WaitForSeconds(1);
    }

    void MoveToNextCharacter()
    {
       
        if (currentImage + 1 < CharacterSprites.Length)
        {
            currentImage++;
        }
        else
        {
            currentImage = 0;
        }

        image.sprite = CharacterSprites[currentImage];
        DisableImage();
    }

    void MoveToPreviousCharacter()
    {
        if(currentImage > 0)
        {
            currentImage--;
            image.sprite = CharacterSprites[currentImage];
        }
        else
        {
            currentImage = CharacterSprites.Length - 1;
        }

        image.sprite = CharacterSprites[currentImage];
        DisableImage();
    }
    void DisableImage()
    {
        if (mSpriteEnabledTable[currentImage])
        {
            Debug.Log("Character has been selected");
            image.color = new Color(1, 1, 1, 0.25f);
            SelectButton.interactable = false;
        }
        else
        {
            image.color = new Color(1, 1, 1, 1);
            SelectButton.interactable = true;
        }
    }
    public void ClientSelectedACharacter(CharacterChosenMessage msg)
    {
        int index = msg.mCharacterID;
        string id = msg.mClientID;
      
        if(id != Client.GetClient().GetID() && mSpriteEnabledTable.ContainsKey(index))
        {
            mSpriteEnabledTable[index] = true;
            DisableImage();
        }
      
    }
    public void SelectedACharacter()
    {
        if (!mSpriteEnabledTable[currentImage])
        {
            CharacterType type = (CharacterType)(currentImage + 1);
            Client.GetClient().AssignID(type.ToString());
            CharacterChosenMessage msg = new CharacterChosenMessage();
            msg.mCharacterID = currentImage;
            msg.mClientID = type.ToString();
            Client.GetClient().Send(ClientMessages.CharacterChosen, msg);
        }
    }
}
