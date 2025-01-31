﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using ducker.Commands.Attributes;
using ducker.DiscordData;
using ducker.Logs;

namespace ducker.Commands.AdministrationModule;

public partial class AdministrationCommands
{
    [Command("add-role")]
    [Description("Add a role to mentioned user")]
    [RequireAdmin]
    public async Task AddRoleCommand(CommandContext msg, DiscordMember member, DiscordRole role,
        [RemainingText] string reason = "noneReason")
    {
        if (member.Roles.ToArray().Contains(role))
        {
            await msg.Channel.SendMessageAsync(new DiscordEmbedBuilder
            {
                Description = "This member currently has this role",
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    IconUrl = msg.User.AvatarUrl,
                    Text = msg.User.Username
                },
                Color = Bot.WarningColor
            });
            return;
        }

        try
        {
            await member.GrantRoleAsync(role);
            await msg.Message.CreateReactionAsync(DiscordEmoji.FromName(msg.Client, Bot.RespondEmojiName));
            await Log.Audit(msg.Guild, $"{msg.Member.Mention} added role {role.Mention} to {member.Mention}.", reason);
        }
        catch
        {
            await msg.Channel.SendMessageAsync(new DiscordEmbedBuilder
            {
                Description = "You can't add this role",
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    IconUrl = msg.User.AvatarUrl,
                    Text = msg.User.Username
                },
                Color = Bot.WarningColor
            });
        }
    }

    [Command("add-role")]
    public async Task AddRoleCommand(CommandContext msg, [RemainingText] string text)
    {
        await msg.Channel.SendMessageAsync(Embed.IncorrectCommand(msg,
            "add-role <member> <role> <reason>"));
    }
}