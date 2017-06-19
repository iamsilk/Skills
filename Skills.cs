using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using Rocket.Unturned.Skills;

namespace Skills
{
    public class Skills : RocketPlugin
    {
        public static Skills Instance;

        protected override void Load()
        {
            Instance = this;
        }

        public static UnturnedSkill GetSkill(string skill)
        {
            switch (skill.ToLower())
            {
                case "overkill": return UnturnedSkill.Overkill;
                case "sharpshooter": return UnturnedSkill.Sharpshooter;
                case "dexterity": return UnturnedSkill.Dexerity;
                case "cardio": return UnturnedSkill.Cardio;
                case "exercise": return UnturnedSkill.Exercise;
                case "diving": return UnturnedSkill.Diving;
                case "parkour": return UnturnedSkill.Parkour;
                case "sneakybeaky": return UnturnedSkill.Sneakybeaky;
                case "vitality": return UnturnedSkill.Vitality;
                case "immunity": return UnturnedSkill.Immunity;
                case "toughness": return UnturnedSkill.Toughness;
                case "strength": return UnturnedSkill.Strength;
                case "warmblooded": return UnturnedSkill.Warmblooded;
                case "survival": return UnturnedSkill.Survival;
                case "healing": return UnturnedSkill.Healing;
                case "crafting": return UnturnedSkill.Crafting;
                case "outdoors": return UnturnedSkill.Outdoors;
                case "cooking": return UnturnedSkill.Cooking;
                case "fishing": return UnturnedSkill.Fishing;
                case "agriculture": return UnturnedSkill.Agriculture;
                case "mechanic": return UnturnedSkill.Mechanic;
                case "engineer": return UnturnedSkill.Engineer;
            }
            return null;
        }

        public static byte GetMaxLevel(UnturnedSkill skill)
        {
            if (skill == UnturnedSkill.Overkill) return 7;
            if (skill == UnturnedSkill.Sharpshooter) return 7;
            if (skill == UnturnedSkill.Dexerity) return 5;
            if (skill == UnturnedSkill.Cardio) return 5;
            if (skill == UnturnedSkill.Exercise) return 5;
            if (skill == UnturnedSkill.Diving) return 5;
            if (skill == UnturnedSkill.Parkour) return 5;
            if (skill == UnturnedSkill.Sneakybeaky) return 7;
            if (skill == UnturnedSkill.Vitality) return 5;
            if (skill == UnturnedSkill.Immunity) return 5;
            if (skill == UnturnedSkill.Toughness) return 5;
            if (skill == UnturnedSkill.Strength) return 5;
            if (skill == UnturnedSkill.Warmblooded) return 5;
            if (skill == UnturnedSkill.Survival) return 5;
            if (skill == UnturnedSkill.Healing) return 7;
            if (skill == UnturnedSkill.Crafting) return 3;
            if (skill == UnturnedSkill.Outdoors) return 5;
            if (skill == UnturnedSkill.Cooking) return 3;
            if (skill == UnturnedSkill.Fishing) return 5;
            if (skill == UnturnedSkill.Agriculture) return 7;
            if (skill == UnturnedSkill.Mechanic) return 5;
            if (skill == UnturnedSkill.Engineer) return 3;
            return 0;
        }

        public static void GiveMaxSkills(UnturnedPlayer player)
        {
            SetSkill(player, UnturnedSkill.Overkill, 7);
            SetSkill(player, UnturnedSkill.Sharpshooter, 7);
            SetSkill(player, UnturnedSkill.Dexerity, 5);
            SetSkill(player, UnturnedSkill.Cardio, 5);
            SetSkill(player, UnturnedSkill.Exercise, 5);
            SetSkill(player, UnturnedSkill.Diving, 5);
            SetSkill(player, UnturnedSkill.Parkour, 5);
            
            SetSkill(player, UnturnedSkill.Sneakybeaky, 7);
            SetSkill(player, UnturnedSkill.Vitality, 5);
            SetSkill(player, UnturnedSkill.Immunity, 5);
            SetSkill(player, UnturnedSkill.Toughness, 5);
            SetSkill(player, UnturnedSkill.Strength, 5);
            SetSkill(player, UnturnedSkill.Warmblooded, 5);
            SetSkill(player, UnturnedSkill.Survival, 5);
            
            SetSkill(player, UnturnedSkill.Healing, 7);
            SetSkill(player, UnturnedSkill.Crafting, 3);
            SetSkill(player, UnturnedSkill.Outdoors, 5);
            SetSkill(player, UnturnedSkill.Cooking, 3);
            SetSkill(player, UnturnedSkill.Fishing, 5);
            SetSkill(player, UnturnedSkill.Agriculture, 7);
            SetSkill(player, UnturnedSkill.Mechanic, 5);
            SetSkill(player, UnturnedSkill.Engineer, 3);
        }

        public static void SetSkill(UnturnedPlayer player, UnturnedSkill skill, byte level)
        {
            player.SetSkillLevel(skill, level);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "command_skill_help", "/skill [player] <skill> <level | max> - Modify your own or someone else's skill." },
            { "command_maxskills_help", "/maxskills [player] - Give yourself or someone max skills." },
            { "command_zeroskills_help", "/zeroskills [player] - Set your own or someone else's skills to zero." },

            { "skill_success", "Successfully modified the skill." },
            { "maxskills_success", "Successfully maxed out skills." },
            { "zeroskills_success", "Successfully zeroed skills." },

            { "unknown_skill", "The specified skill does not exist." },
            { "invalid_level", "The specified level is invalid." },

            { "console_must_specify_player", "Console must specify a player to set skills for." },
            { "player_not_found", "Cannot find the specified player." },
            { "no_permission", "You do not have permission to do this." },
            { "invalid_parameters", "Invalid parameters." },
        };
    }
}
