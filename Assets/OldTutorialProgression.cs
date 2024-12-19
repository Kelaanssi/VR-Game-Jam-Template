using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OldTutorialProgression : MonoBehaviour
{
    public TextMeshProUGUI textBox; // Text of the hand panel

    int page = 1;

    // The buttons for selecting the language at the start of the tutorial
    public Button buttonFinnish;
    public Button buttonEnglish;

    // The buttons for flipping through pages
    public Button previousPage;
    public Button nextPage;

    // If the player selects the Finnish language, the tutorial's text will be in Finnish.
    public void Finnish()
    {
        textBox.text = "Selected Finnish";
        buttonFinnish.gameObject.SetActive(false);
        buttonEnglish.gameObject.SetActive(false);
    }

    // If the player selects the English language, the tutorial's text will be in English.
    public void English()
    {
        textBox.text = "Selected English";
        buttonFinnish.gameObject.SetActive(false);
        buttonEnglish.gameObject.SetActive(false);
    }

    // Functions for the page flipping buttons, which change the value of the page, then call to the PageFlip function to attach the according text to the panel's textbox.
    public void pageFlip1()
    {
        page--;
        PageFlip();
    }

    public void pageFlip2()
    {
        page++;
        PageFlip();
    }

    //public void KeyInserted()
    //{
    //    textBox.text = "Great Job!";
    //}

    // The switch statement containing the text of each page, to be called after a page is flipped.
    public void PageFlip()
    {
        switch (page)
        {
            case 1:
                textBox.text = "Welcome to virtual reality! Through this panel, you can go through a quick tutorial about the properties of virtual reality.";
                break;
            case 2:
                textBox.text = "First, choose your preferred language for the tutorial.";
                break;
        }
    }
}