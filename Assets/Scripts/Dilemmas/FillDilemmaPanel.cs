using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dilemmas
{
    public class FillDilemmaPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _dilemmaPanel;
        [SerializeField] private GameObject _dialogPanel;

        [Header("Dilemma parameters")]
        [SerializeField] private Text _titleField;
        [SerializeField] private Text[] _optionsField;
        [SerializeField] private Text[] _consequencesField;

        [Header("Dialog")]
        [SerializeField] private Text _person1NameField;
        [SerializeField] private Text _person2NameField;
        [SerializeField] private Image _person1PhotoField;
        [SerializeField] private Image _person2PhotoField;
        [SerializeField] private Text _phraseField;
        [SerializeField] private float _generationTime = 0.06f;
        [SerializeField] private float _interwallBetweenPhrases = 2f;

        public void FillPanel(DilemmaSO dilemma)
        {
            _dilemmaPanel.SetActive(true);

            _titleField.text = dilemma.Title;

            for (int i = 0; i < dilemma.Options.Length; i++)
                _optionsField[i].text = dilemma.Options[i];


            for (int i = 0; i < dilemma.Consequences.Length; i++)
                _consequencesField[i].text = dilemma.Consequences[i];
        }

        public void StartDialog(DilemmaSO dilemma)
        {
            _dialogPanel.SetActive(true);
            StartCoroutine(FillDialog(dilemma));
        }

        public IEnumerator FillDialog(DilemmaSO dilemma, int phraseNum = 0, bool isPerson1 = true)
        {
            int phraseCount = phraseNum;

            if(isPerson1)
            {
                _person2NameField.enabled = false;
                _person2PhotoField.enabled = false;

                _person1PhotoField.sprite = dilemma.Person1Photo;
                _person1PhotoField.enabled = true;
                _person1NameField.text = dilemma.Person1;
                _person1NameField.enabled = true;
            }

            else
            {
                _person1NameField.enabled = false;
                _person1PhotoField.enabled= false;

                _person2PhotoField.sprite = dilemma.Person2Photo;
                _person2PhotoField.enabled = true;
                _person2NameField.text = dilemma.Person2;
                _person2NameField.enabled = true;
            }

            for (int i = 0; i < dilemma.Phrases[phraseCount].Length; i++)
            {
                _phraseField.text = dilemma.Phrases[phraseCount].Substring(0, i + 1); 
                yield return new WaitForSeconds(_generationTime);
            }

            if (phraseCount < dilemma.Phrases.Length - 1)
            {
                yield return new WaitForSeconds(_interwallBetweenPhrases);
                yield return StartCoroutine(FillDialog(dilemma, phraseCount + 1, !isPerson1));
            }

            else
            {
                _dialogPanel.SetActive(false);
                FillPanel(dilemma);
            }
        }
    }
}