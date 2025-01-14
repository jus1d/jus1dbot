﻿using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using ducker.Commands.Attributes;
using ducker.DiscordData;

namespace ducker.Commands.AdministrationModule;

public partial class AdministrationCommands
{
    [Command("reaction-role")]
    [Description("Send an embed with buttons, by press there you will granted a role")]
    [Aliases("rr")]
    [RequireAdmin]
    [RequireMainGuild]
    public async Task ReactionRoleCommand(CommandContext msg, [RemainingText] string text)
    {
        await msg.Message.DeleteAsync();

        var twitchRgbEmoji = DiscordEmoji.FromName(msg.Client, ":twitchrgb:");
        var chelEmoji = DiscordEmoji.FromName(msg.Client, ":chel:");
        var followButton = new DiscordButtonComponent(ButtonStyle.Secondary, "get_follow_role", "", false,
            new DiscordComponentEmoji(twitchRgbEmoji));
        var chelButton = new DiscordButtonComponent(ButtonStyle.Secondary, "get_chel_role", "", false,
            new DiscordComponentEmoji(chelEmoji));

        await msg.Channel.SendMessageAsync(new DiscordMessageBuilder()
            .AddEmbed(Embed.ReactionRolesEmbed(msg.Client, msg.Guild))
            .AddComponents(followButton, chelButton));
    }
}