using UnityEngine;
using UnityEngine.UI;

namespace Dilemmas
{
    public class FillDilemmaPanel : MonoBehaviour
    {
        [SerializeField] private Text _titleField;
        [SerializeField] private Text[] _optionsField;
        [SerializeField] private Text[] _rewardField;
        [SerializeField] private Text[] _consequencesField;

        public void FillPanel(DilemmaSO dilemma)
        {
            _titleField.text = dilemma.Title;

            for (int i = 0; i < dilemma.Options.Length; i++)
                _optionsField[i].text = dilemma.Options[i];

            for (int i = 0; i < dilemma.Reward.Length; i++)
                _rewardField[i].text = dilemma.Reward[i];

            for (int i = 0; i < dilemma.Consequences.Length; i++)
                _consequencesField[i].text = dilemma.Consequences[i];
        }
    }
}