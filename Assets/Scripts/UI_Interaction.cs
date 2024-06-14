using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Interaction : MonoBehaviour
{
    // UIs
    public GameObject subjectListUI;

    // Dimm UI
    public GameObject dimmUI;

    // Start is called before the first frame update
    void Start()
    {
        subjectListUI.SetActive(false);
        dimmUI.SetActive(false);
    }

    // Check if any UI is on
    private bool IsUIOn()
    {
        bool res = false;

        if (subjectListUI.activeSelf)
            res = true;

        return res;
    }

    // Open subject list UI if no other UI is on
    public void OnClickSubjectList()
    {
        if (!IsUIOn())
        {
            dimmUI.SetActive(true);
            subjectListUI.SetActive(true);
        }
    }

    // Close subject list UI
    public void OnClickSubjectListExit()
    {
        dimmUI.SetActive(false);
        subjectListUI.SetActive(false);
    }

    // Open choose subject UI if no other UI is on
    public void OnClickChooseSubject()
    {
        if (!IsUIOn())
            SceneManager.LoadScene("scene2");
    }

    // Exit program if no other UI is on
    public void OnClickExit()
    {
        if (!IsUIOn())
            Application.Quit();
    }
}
