using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class selectSubject_UI : MonoBehaviour
{
    // Selected box
    public WiggleBox box;

    // Game subject UI
    public GameObject gameSubjectUI;
    public TextMeshProUGUI gameSubjectTitle;
    public TextMeshProUGUI gameSubjectExplain;

    // Used to set image
    public Image gameSubjectImg;
    public Sprite[] spriteList;

    // Game subject data
    string[] subjectList = new string[] {"행운", "사막", "고진감래", "씨앗", "OP", "천리길도 한걸음부터", "좌충우돌",
                                           "A", "양심", "우리", "휴식", "기억", "네모", "기습",
                                           "숭배", "장난감", "백짓장도 맞들면 낫다", "반전", "비행", "조화"};
    string[] subjectExplain  = new string[] {"럭키비키잖아ㅋㅋ", "지구온난화 이슈", "기말이 끝나면 종강이 온다!", "풀seed", "OP.GG", "코드롤 한줄씩 짜봅시다", "우당탕탕",
                                           "에이", "이건 주제 정하기 어려울듯요ㅎ", "learnUS", "쉬고싶다...", "ㄱ", "사각형!", "샤샤샥 (닌자인듯ㅋㅋ)",
                                           "Faker...", "toy", "help...", "두둥!", "파닥파닥", "harmony"};

    // Sound effects
    public GameObject myAudio;
    public GameObject drumAudio;


    // Start is called before the first frame update
    void Start()
    {
        if (subjectList.Length != subjectExplain.Length)
            Debug.Log("ERROR : subjectList length and subject explain length different!");
        gameSubjectUI.SetActive(false);
        myAudio.SetActive(false);
        drumAudio.SetActive(false);
    }

    // Click select subject
    public void OnClickSelectSubject()
    {
        if (!gameSubjectUI.activeSelf)
        {
            box.clickBtn = true;
            drumAudio.SetActive(true);
            SetGameSubjectUI();
            StartCoroutine(ShowSubjectAfterDelay(2f));
        }
    }

    // Set gamesubject UI
    public void SetGameSubjectUI()
    {
        // Generate random number
        Random.InitState((int)System.DateTime.Now.Ticks);
        int randomNumber = Random.Range(0, subjectList.Length);

        // Set texts
        gameSubjectTitle.text = subjectList[randomNumber];
        gameSubjectExplain.text = subjectExplain[randomNumber];

        // Set pictures
        SetGameSubjectImage("img_" + randomNumber.ToString());
    }

    // Change picture in UI
    private void SetGameSubjectImage(string imageName)
    {
        foreach (Sprite sprite in spriteList)
        {
            if (sprite.name == imageName)  // Check if the sprite name matches the input
            {
                gameSubjectImg.sprite = sprite;  // Change the displayed image
                return;
            }
        }

        Debug.Log("ERROR : Image not found [" + imageName + "]");  // Log if no matching image is found
    }

    // Click return to lobby button
    public void OnClickReturnLobby()
    {
        SceneManager.LoadScene("scene1");
    }

    // Wait for the specified delay
    IEnumerator ShowSubjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        drumAudio.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        myAudio.SetActive(true);
        gameSubjectUI.SetActive(true);
    }
}
