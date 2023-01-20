using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CozyGame
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DialogPlayer : MonoBehaviour
    {
        [SerializeField]
        [TextArea(10, 50)]
        private string _dialogText;
        [SerializeField]
        private string _buttonText;

        public string DialogText => _dialogText;
        public string ButtonText => _buttonText;
    }
}
