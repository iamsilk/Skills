using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using Rocket.Unturned.Skills;
using System.Collections.Generic;

namespace Skills
{
    public class CommandSkill : IRocketCommand
    {
        public string Name => "skill";

        public string Syntax => "[player] <skill> <level | max>";

        public string Help => "Modify someone's skill sets.";

        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public List<string> Permissions => new List<string>() { "skills.skill" };

        public List<string> Aliases => new List<string>();

        public void Execute(IRocketPlayer player, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                UnturnedChat.Say(player, Skills.Instance.Translate("command_skill_help"));
                return;
            }

            if (parameters.Length < 2 || parameters.Length > 3)
            {
                UnturnedChat.Say(player, Skills.Instance.Translate("invalid_parameters"), UnityEngine.Color.red);
                return;
            }
            
            UnturnedPlayer target;
            int offset = 0;

            if (parameters.Length == 2)
            {
                if (player is ConsolePlayer)
                {
                    UnturnedChat.Say(player, Skills.Instance.Translate("console_must_specify_player"), UnityEngine.Color.red);
                    return;
                }

                target = (UnturnedPlayer)player;
            }
            else
            {
                if (!player.HasPermission("skills.skill.other"))
                {
                    UnturnedChat.Say(player, Skills.Instance.Translate("no_permission"), UnityEngine.Color.red);
                    return;
                }

                target = UnturnedPlayer.FromName(parameters[0]);
                if (target == null)
                {
                    UnturnedChat.Say(player, Skills.Instance.Translate("player_not_found"), UnityEngine.Color.red);
                    return;
                }
                offset++;
            }

            UnturnedSkill skill = Skills.GetSkill(parameters[0 + offset]);
            if (skill == null)
            {
                UnturnedChat.Say(player, Skills.Instance.Translate("unknown_skill"), UnityEngine.Color.red);
                return;
            }

            byte level;
            if (parameters[1 + offset].ToLower() == "max")
            {
                level = Skills.GetMaxLevel(skill);
            }
            else if (!byte.TryParse(parameters[1 + offset], out level))
            {
                UnturnedChat.Say(player, Skills.Instance.Translate("invalid_level"), UnityEngine.Color.red);
                return;
            }

            Skills.SetSkill(target, skill, level);
            UnturnedChat.Say(player, Skills.Instance.Translate("skill_success"));
        }
    }
}
