//using System.Collections.Generic;
//using UnityEngine;

//namespace RPG.LevelSystem
//{
//    [CreateAssetMenu(menuName = "RPG Generator/Player/Create Skills")]
//    public class Skills : ScriptableObject
//    {
//        public string Description;
//        public Sprite Icon;
//        public int levelNeeded;
//        public int xpNeeded;

//        public List<PlayerAttributes> AffectedAttributes = new List<PlayerAttributes>();


//        public void SetValues(GameObject SkillDisplayObject, PlayerStats Player)
//        {
//            if(Player)
//            {
//                CheckSkills(Player);
//            }


//            if (SkillDisplayObject)
//            {
//                SkillDisplay SD = SkillDisplayObject.GetComponent<SkillDisplay>();
//                SD.skillName.text = name;

//                if(SD.skillDescription)
//                {
//                    SD.skillDescription.text = Description;
//                }

//                if(SD.skillIcon)
//                {
//                    SD.skillIcon.sprite = Icon;
//                }

//                if(SD.skillLevel)
//                {
//                    SD.skillLevel.text = levelNeeded.ToString();
//                }

//                if(SD.skillXPNeeded)
//                {
//                    SD.skillXPNeeded.text = xpNeeded.ToString() + "XP";
//                }

//                if(SD.skillAttribute)
//                {
//                    SD.skillAttribute.text = AffectedAttributes[0].attribute.ToString();
//                }

//                if(SD.skillAttributeAmount)
//                {
//                    SD.skillAttributeAmount.text = " + " + AffectedAttributes[0].amount.ToString();
//                }
//            }
//        }

//        //Check if player is able to get skill
//        public bool CheckSkills(PlayerStats Player)
//        {
//            //Checks if the player is right level
//            if (Player.playerLevel < levelNeeded)
//            {
//                return false;
//            }

//            //Checks if the player got the right xp needed
//            if (Player.playerXp < xpNeeded)
//            {
//                return false;
//            }

//            return true;
//        }
//    }

//}
