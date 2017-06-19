using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace Skills
{
    public class CommandZeroSkills : IRocketCommand
    {
        public string Name => "zeroskills";

        public string Syntax => "[player]";

        public string Help => "Set your own or someone else's skills to zero.";

        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public List<string> Permissions => new List<string>() { "skills.zeroskills" };

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
                if (!player.HasPermission("skills.zeroskills.other"))
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

            Skills.SetAllSkills(target, 0);
            UnturnedChat.Say(player, Skills.Instance.Translate("zeroskills_success"));
        }
    }
}
