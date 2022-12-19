using _Scripts.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class CardDisplay : MonoBehaviour
    {
        public Text nameText;
        public Text descriptionText;
        public Image artworkImage;
        public Text manaText;
        public Text attackText;
        public Text healtText;
        public void SetCard(CardsBase card)
        {
            nameText.text = card.name;
            descriptionText.text = card.Description;
            artworkImage.sprite = card._sprite;
            manaText.text = card.Cost.ToString();
            attackText.text = card.Damage.ToString();
            healtText.text = card.Name.ToString();

        }

        

    }
}
