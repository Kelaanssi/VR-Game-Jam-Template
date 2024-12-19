using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI textBox; // Text of the tutorial panel.

    private int page = 0; // Integer value for the page index, used for each list of the tutorial's contents.

    // List to store the text of tutorial pages.
    private List<string> pages = new List<string>();

    // List to store tutorial videos for different pages.
    public List<VideoClip> pageVideos = new List<VideoClip>();

    // List to store the guiding objects for each page.
    public List<GameObject> guidance = new List<GameObject>();

    // Buttons for language selection.
    public GameObject languageButtons;

    // Video player for the tutorial videos.
    public VideoPlayer videoPlayer;

    // Buttons for flipping through pages. Referred separately to control their functionality depending on the current page.
    public Button previousPageButton;
    public Button nextPageButton;

    // Button for playing the video tutorial, which is set visible after the user reaches the second page of the tutorial.
    public Button videoButton;

    // UI elements to control during transitions to and from the video player.
    public GameObject tutorialUI; // Parent GameObject for the tutorial UI.
    public GameObject videoUI; // Parent GameObject for the video player, as well as the button to close the video early.

    private void Start()
    {
        // Subscribe to the loopPointReached event, automatically triggering the OnVideoEnd function once the tutorial video ends.
        videoPlayer.loopPointReached += StopVideo;
    }

    // Function to bring back the video UI, also used by the button to end the video early.
    public void StopVideo(VideoPlayer vp)
    {
        videoPlayer.Stop();
        videoUI.SetActive(false);
        tutorialUI.SetActive(true);
    }

    // Function to trigger through the panel's video button, used to call the PlayVideo function, giving the information of the current page.
    public void PlayVideoClip()
    {
        PlayVideo(page);
    }

    // Function to hide the tutorial UI, set the correct video for the page, and play the video.
    private void PlayVideo(int page)
    {
        if (page >= 0 && page < pageVideos.Count)
        {
            tutorialUI.SetActive(false); // Hide tutorial elements
            videoUI.SetActive(true); // Show video and controls
            videoPlayer.clip = pageVideos[page];
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Video index is out of range.");
        }
    }

    // Functions to set the tutorial's language and activate the UI.
    // Function, which sets the tutorial's language as Finnish.
    public void SetFinnishText()
    {
        languageButtons.gameObject.SetActive(false);

        previousPageButton.gameObject.SetActive(true);
        nextPageButton.gameObject.SetActive(true);

        pages.Clear();
        pages.Add("Tervetuloa virtuaalitodellisuuteen! \nTämän paneelin kautta voit käydä läpi virtuaalitodellisuuden ominaisuuksia. \nJokaisella sivulla selitetään eri ominaisuuksista, joita voit selata painamalla paneelin alanurkissa sijaitsevia painikkeita. \nMene seuraavalle sivulle aloittaaksesi.");
        pages.Add("Tekstillisen selityksen lisäksi, jokaisella ominaisuuksia opettavalla sivulla on oma video, jossa näytetään ominaisuudet käytännössä virtuaalisen todellisuuden sisällä. \nVideon voit avata painamalla paneelin alaosassa olevaa nappia.");
        pages.Add("Voit liikkua ja kääntyä virtuaalisessa todellisuudessa oman kehosi avulla, mutta todellisen maailman rajallisen tilan vuoksi on hyvä hyödyntää ohjaimia liikkumiseen.");
        pages.Add("Käyttämällä oikean käden ohjaimen ohjaussauvaa peukalollasi, voit kääntää kameraa työntämällä sitä sivulle, sekä liikkua osoittamaasi sijaintiin teleportaation kautta työntämällä sitä eteenpäin.");
        pages.Add("Vasemman käden ohjaimen ohjaussauva liikuttaa sinua siihen suuntaan mihin painat sitä. \nLiikkumiseen kannattaa silti useammin käyttää oikean käden ohjaussauvan teleportaatio ominaisuutta, jotta voidaan välttää liikkeestä johtuvaa pahoinvointia.");
        pages.Add("Voit nostaa löytämiäsi esineitä painamalla ohjaimessa keskisormen kohdalla sijaitsevan liipaisimen pohjaan. \nNämä esineet pysyvät kädessäsi, kunnes päästät liipaisimesta irti.");
        pages.Add("Joillakin esineillä saattaa olla erityisiä ominaisuuksia. \nNäitä voi käyttää painamalla etusormen kohdalla sijaitsevan liipaisimen pohjaan, samalla kun pidät esinettä kädessäsi.");

        UpdatePageText();
        UpdatePageButtons();
        UpdatePageObjects();
    }

    // Function, which sets the tutorial's language as English.
    public void SetEnglishText()
    {
        languageButtons.gameObject.SetActive(false);

        previousPageButton.gameObject.SetActive(true);
        nextPageButton.gameObject.SetActive(true);

        pages.Clear();
        pages.Add("Welcome to virtual reality! \nThrough this panel, you can go through a quick tutorial about the properties of virtual reality. \nEach page explains different properties, which you can scroll through by interacting with the buttons at the bottom corners of this panel. \nGo to the next page to begin.");
        pages.Add("In addition to the textual explanation, each page about features contains a video, showcasing the features in practice, within virtual reality. \nYou can open the video by pressing the button at the bottom of the panel.");
        pages.Add("In virtual reality, you can move and turn through movements of your own body, though it’s often better to use the controllers for movement, due to the lack of space in the real world.");
        pages.Add("By using the joystick on the right-hand controller with your thumb, you can turn the camera by pushing it to the side, or move to the location you’re pointing to through teleportation by pushing it forward.");
        pages.Add("The joystick on the left-hand controller moves you towards the pressed direction. \nIt is recommended to primarily use the teleportation feature of the right hand controller, though, in order to avoid motion sickness.");
        pages.Add("You can pick up objects you find by pulling the lower trigger, located under your middle finger on each controller. \nThe objects will stay within your grip, as long as you hold down the trigger.");
        pages.Add("Some objects may have special functions. \nThese can be activated by pulling the trigger under your index finger, while the object is picked up.");

        UpdatePageText();
        UpdatePageButtons();
        UpdatePageObjects();
    }
    // If you want to add new pages for languages in between existing ones, you will also have to change the order of assets within the pageVideos and guidance lists as well.
    // If you want to add a new language for the tutorial, copy either of the functions above, change the name and page texts, and add a new button under the LanguageButtons game object, with a trigger for the function for your new language.

    // Functions triggering all of the necessary methods to update the page's contents upon flipping the page.
    public void PreviousPage()
    {
        if (page > 0)
        {
            page--;
            UpdatePageText();
            UpdatePageButtons();
            UpdatePageObjects();
        }
    }

    public void NextPage()
    {
        if (page < pages.Count - 1)
        {
            page++;
            UpdatePageText();
            UpdatePageButtons();
            UpdatePageObjects();
        }

        if (page == 1)
        {
            videoButton.gameObject.SetActive(true);
        }
    }

    // Function to update the page's displayed text based on the current page index.
    private void UpdatePageText()
    {
        if (page >= 0 && page < pages.Count)
        {
            textBox.text = pages[page];
        }
    }

    // Function to enable or disable page-flipping buttons based on the current page.
    // If the user is on the first page, the previous page button is disabled. If the user is on the last page, the next page button is disabled.
    private void UpdatePageButtons()
    {
        previousPageButton.interactable = page > 0;
        nextPageButton.interactable = page < pages.Count - 1;
    }

    // Function to activate the guiding objects relevant to the current page.
    private void UpdatePageObjects()
    {
        for (int i = 0; i < guidance.Count; i++)
        {
            if (guidance[i] != null)
            {
                guidance[i].SetActive(i == page);
            }
        }
    }
}
