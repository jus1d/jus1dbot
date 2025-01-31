﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using ducker.Commands.Attributes;
using ducker.DiscordData;
using ducker.Logs;

namespace ducker.Commands.AdministrationModule;

public partial class AdministrationCommands
{
    [Command("kick")]
    [Description("Kick mentioned user from current server")]
    [RequireAdmin]
    public async Task KickCommand(CommandContext msg, DiscordMember member,
        [RemainingText] string reason = "noneReason")
    {
        try
        {
            await member.RemoveAsync(reason);
            await msg.Message.CreateReactionAsync(DiscordEmoji.FromName(msg.Client, Bot.RespondEmojiName));
            await Log.Audit(msg.Guild, $"{msg.Member.Mention} kicked {member.Mention}.", reason);
        }
        catch
        {
            await msg.Channel.SendMessageAsync(new DiscordEmbedBuilder
            {
                Description = "You can't kick this member",
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    IconUrl = msg.User.AvatarUrl,
                    Text = msg.User.Username
                },
                Color = Bot.IncorrectEmbedColor
            });
        }
    }

    [Command("kick")]
    public async Task KickCommand(CommandContext msg, [RemainingText] string text)
    {
        await msg.Channel.SendMessageAsync(Embed.IncorrectCommand(msg, "kick <member> <reason>"));
    }
}