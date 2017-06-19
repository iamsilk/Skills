using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace Skills
{
    public class CommandMaxSkills : IRocketCommand
    {
        public string Name => "maxskills";

        public string Syntax => "[player]";

        public string Help => "Give yourself or another player max skills.";

        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public List<string> Permissions => new List<string>() { "skills.maxskills" };

        public List<string> Aliases => new List<string>();

        public void Execute(IRocketPlayer player, string[] parameters)
        {
            if (parameters.Length > 1)
            {
                UnturnedChat.Say(player, Skills.Instance.Translate("invalid_parameters"), UnityEngine.Color.red);
                return;
            }

            UnturnedPlayer target;

            if (parameters.Length == 0)
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
                if (!player.HasPermission("skills.maxskills.other"))
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
            }

            Skills.GiveMaxSkills(target);
            UnturnedChat.Say(player, Skills.Instance.Translate("maxskills_success"));
        }
    }
}
