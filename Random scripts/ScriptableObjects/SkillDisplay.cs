//using UnityEngine.UI;
//using UnityEngine;
//namespace RPG.LevelSystem
//{
//    public class SkillDisplay : MonoBehaviour
//    {
//        //Get the scriptable object for Skill
//        public Skills skill;
//        public Text skillName;
//        public Text skillDescription;
//        public Image skillIcon;
//        public Text skillLevel;
//        public Text skillXPNeeded;
//        public Text skillAttribute;
//        public Text skillAttributeAmount;

//        [SerializeField]
//        private PlayerStats m_PlayerHandler;

//        private void Start()
//        {
//            m_PlayerHandler = GetComponentInParent<PlayerHandler>().Player;
//            m_PlayerHandler.OnXPChange += ReactToChange;
//            m_PlayerHandler.OnLevelChange += ReactToChange;

//            if (skill)
//                skill.SetValues(this.gameObject, m_PlayerHandler);
//        }
//    }

//}
