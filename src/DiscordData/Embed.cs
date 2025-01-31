﻿using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;
using Microsoft.VisualBasic;

namespace ducker.DiscordData;

public class Embed
{
    public static DiscordMessageBuilder NowPlaying(DiscordClient client, LavalinkTrack track, DiscordUser user)
    {
        var playEmbed = new DiscordEmbedBuilder
        {
            Title = "Now playing",
            Description = $"[{track.Title}]({track.Uri})",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = "Ordered by " + user.Username
            },
            Color = Bot.MainEmbedColor
        };
        var playButton = new DiscordButtonComponent(ButtonStyle.Secondary, "play_button", "Play", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(client, ":arrow_forward:")));
        var pauseButton = new DiscordButtonComponent(ButtonStyle.Secondary, "pause_button", "Pause", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(client, ":pause_button:")));
        var nextButton = new DiscordButtonComponent(ButtonStyle.Secondary, "next_button", "Skip", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(client, ":track_next:")));
        var queueButton = new DiscordButtonComponent(ButtonStyle.Secondary, "queue_button", "Queue", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(client, ":page_facing_up:")));

        return new DiscordMessageBuilder()
            .AddEmbed(playEmbed)
            .AddComponents(pauseButton, playButton, nextButton, queueButton);
    }

    public static DiscordEmbedBuilder NowPlayingEmbed(LavalinkTrack track, DiscordUser user)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Now playing",
            Description = $"[{track.Title}]({track.Uri})",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = "Ordered by " + user.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordMessageBuilder IncorrectMusicChannel(CommandContext msg, ulong musicChannelId)
    {
        var incorrectMusicChannel = new DiscordEmbedBuilder
        {
            Title = "Incorrect channel for music commands",
            Description = $"This command can be used only in <#{msg.Guild.GetChannel(musicChannelId).Id}>",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(incorrectMusicChannel);
    }

    public static DiscordMessageBuilder IncorrectMusicChannel(InteractionContext msg, ulong musicChannelId)
    {
        var incorrectMusicChannel = new DiscordEmbedBuilder
        {
            Title = "Incorrect channel for music commands",
            Description = $"This command can be used only in {msg.Guild.GetChannel(musicChannelId).Mention}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(incorrectMusicChannel);
    }

    public static DiscordEmbedBuilder IncorrectMusicChannelEmbed(InteractionContext msg, ulong musicChannelId)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Incorrect channel for music commands",
            Description = $"This command can be used only in {msg.Guild.GetChannel(musicChannelId).Mention}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder IncorrectMusicChannelEmbed(CommandContext msg, ulong musicChannelId)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Incorrect channel for music commands",
            Description = $"This command can be used only in {msg.Guild.GetChannel(musicChannelId).Mention}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordMessageBuilder NotInVoiceChannel(CommandContext msg)
    {
        var notInVoiceChannel = new DiscordEmbedBuilder
        {
            Description = "You are not in a voice channel",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(notInVoiceChannel);
    }

    public static DiscordMessageBuilder NotInVoiceChannel(InteractionContext msg)
    {
        var notInVoiceChannel = new DiscordEmbedBuilder
        {
            Description = "You are not in a voice channel",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(notInVoiceChannel);
    }

    public static DiscordEmbedBuilder NotInVoiceChannelEmbed(InteractionContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "You are not in a voice channel",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder NotInVoiceChannelEmbed(CommandContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "You are not in a voice channel",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordMessageBuilder NoConnection(CommandContext msg)
    {
        var noConnection = new DiscordEmbedBuilder
        {
            Description = "I'm is not connected",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(noConnection);
    }

    public static DiscordMessageBuilder NoConnection(InteractionContext msg)
    {
        var noConnection = new DiscordEmbedBuilder
        {
            Description = "I'm is not connected",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(noConnection);
    }

    public static DiscordEmbedBuilder NoConnectionEmbed(InteractionContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "I'm is not connected",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder NoConnectionEmbed(CommandContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "I'm is not connected",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordMessageBuilder SearchFailed(CommandContext msg, string search)
    {
        var searchFailed = new DiscordEmbedBuilder
        {
            Description = $"Track search failed for: {search}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(searchFailed);
    }

    public static DiscordMessageBuilder SearchFailed(InteractionContext msg, string search)
    {
        var searchFailed = new DiscordEmbedBuilder
        {
            Description = $"Track search failed for: {search}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(searchFailed);
    }

    public static DiscordEmbedBuilder SearchFailedEmbed(InteractionContext msg, string search)
    {
        return new DiscordEmbedBuilder
        {
            Description = $"Track search failed for: {search}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordMessageBuilder NoTracksPlaying(CommandContext msg)
    {
        var noPlayingTracks = new DiscordEmbedBuilder
        {
            Description = "There are no tracks loaded",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(noPlayingTracks);
    }

    public static DiscordMessageBuilder NoTracksPlaying(InteractionContext msg)
    {
        var noPlayingTracks = new DiscordEmbedBuilder
        {
            Description = "There are no tracks loaded",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(noPlayingTracks);
    }

    public static DiscordEmbedBuilder NoTracksPlayingEmbed(InteractionContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "There are no tracks loaded",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder NoTracksPlayingEmbed(CommandContext msg)
    {
        return new DiscordEmbedBuilder
        {
            Description = "There are no tracks loaded",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordMessageBuilder IncorrectCommand(CommandContext msg, string usage)
    {
        var incorrectCommand = new DiscordEmbedBuilder
        {
            Title = "Missing argument",
            Description = $"**Usage:** {usage}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.IncorrectEmbedColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(incorrectCommand);
    }

    public static DiscordEmbedBuilder Queue(DiscordUser user)
    {
        var title = "Queue:";
        try
        {
            var lavalinkTrack = Bot.Queue[0]; // try use list's element to catch exception
        }
        catch (Exception exception)
        {
            title = "Queue is clear";
        }

        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = title,
            Description = totalQueue,
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = user.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordMessageBuilder InvalidChannel(CommandContext msg)
    {
        var invalidChannel = new DiscordEmbedBuilder
        {
            Description = "Not a valid voice channel",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = msg.User.Username
            },
            Color = Bot.WarningColor
        };
        return new DiscordMessageBuilder()
            .AddEmbed(invalidChannel);
    }

    public static DiscordMessageBuilder TrackQueued(CommandContext msg)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        var trackQueued = new DiscordEmbedBuilder
        {
            Title = $"Track **{Bot.Queue[0].Title}** queued, position - {Bot.Queue.Count}",
            Description = $"Queue:\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = "Queued by " + msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
        var nextButton = new DiscordButtonComponent(ButtonStyle.Secondary, "next_button", "Skip", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(msg.Client, ":track_next:")));
        var queueButton = new DiscordButtonComponent(ButtonStyle.Secondary, "queue_button", "Queue", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(msg.Client, ":page_facing_up:")));

        return new DiscordMessageBuilder()
            .AddEmbed(trackQueued)
            .AddComponents(nextButton, queueButton);
    }

    public static DiscordMessageBuilder TrackQueued(InteractionContext msg)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        var trackQueued = new DiscordEmbedBuilder
        {
            Title = $"Track **{Bot.Queue[0].Title}** queued, position - {Bot.Queue.Count}",
            Description = $"Queue:\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = "Queued by " + msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
        var nextButton = new DiscordButtonComponent(ButtonStyle.Secondary, "next_button", "Skip", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(msg.Client, ":track_next:")));
        var queueButton = new DiscordButtonComponent(ButtonStyle.Secondary, "queue_button", "Queue", false,
            new DiscordComponentEmoji(DiscordEmoji.FromName(msg.Client, ":page_facing_up:")));

        return new DiscordMessageBuilder()
            .AddEmbed(trackQueued)
            .AddComponents(nextButton, queueButton);
    }

    public static DiscordEmbedBuilder TrackQueuedEmbed(InteractionContext msg)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = $"Track **{Bot.Queue[0].Title}** queued, position - {Bot.Queue.Count}",
            Description = $"Queue:\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = "Queued by " + msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder TrackQueuedEmbed(CommandContext msg)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = $"Track **{Bot.Queue[0].Title}** queued, position - {Bot.Queue.Count}",
            Description = $"Queue:\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = msg.User.AvatarUrl,
                Text = "Queued by " + msg.User.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder ClearQueueEmbed(DiscordUser user)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Queue is clear",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = user.Username
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder ReactionRolesEmbed(DiscordClient client, DiscordGuild guild)
    {
        var vibeEmoji = DiscordEmoji.FromName(client, ":vibe:");
        var twitchRgbEmoji = DiscordEmoji.FromName(client, ":twitchrgb:");
        var chelEmoji = DiscordEmoji.FromName(client, ":chel:");
        return new DiscordEmbedBuilder
        {
            Title = $"{vibeEmoji} Welcome, tap buttons to get roles {vibeEmoji}",
            Description =
                $"Roles list:\n{twitchRgbEmoji} - twitch follower(by having this reaction, u will get stream notifications)\n{chelEmoji} - default role for this server\n\nGL",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = guild.GetMemberAsync(Bot.Id).Result.DisplayName,
                IconUrl = guild.GetMemberAsync(Bot.Id).Result.AvatarUrl
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder StreamAnnouncementEmbed(CommandContext msg, string description)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Stream online!",
            Description = $"{description} \nhttps://www.twitch.tv/itakash1",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = msg.Guild.GetMemberAsync(Bot.Id).Result.DisplayName,
                IconUrl = msg.Guild.GetMemberAsync(Bot.Id).Result.AvatarUrl
            },
            ImageUrl = msg.Guild.GetMemberAsync(857687574281453598).Result.AvatarUrl,
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder StreamAnnouncementEmbed(InteractionContext msg, string description)
    {
        return new DiscordEmbedBuilder
        {
            Title = "Stream online!",
            Description = $"{description} \nhttps://www.twitch.tv/itakash1",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = msg.Guild.GetMemberAsync(Bot.Id).Result.DisplayName,
                IconUrl = msg.Guild.GetMemberAsync(Bot.Id).Result.AvatarUrl
            },
            ImageUrl = msg.Guild.GetMemberAsync(857687574281453598).Result.AvatarUrl,
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder TrackRepeatEmbed(DiscordUser user)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = "Track will repeat",
            Description = $"**Queue:**\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = $"Ordered by {user.Username}"
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder TrackRemovedFromQueueEmbed(DiscordUser user)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = "Track removed from queue",
            Description = $"**Queue:**\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl, Text = $"Removed by {user.Username}"
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder InvalidTrackPositionEmbed(DiscordUser user)
    {
        var totalQueue = "";
        for (var i = 0; i < Bot.Queue.Count; i++)
            totalQueue += $"{i + 1}. " + Bot.Queue[i].Title + "\n";

        return new DiscordEmbedBuilder
        {
            Title = "Invalid track position in queue",
            Description = $"**Queue:**\n{totalQueue}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl, Text = $"Removed by {user.Username}"
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder NoMusicChannelConfigured(DiscordUser user)
    {
        return new DiscordEmbedBuilder
        {
            Title = "No music channel configured for your server",
            Description = "Type `-set-music-channel` to configure",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl, Text = $"Removed by {user.Username}"
            },
            Color = Bot.WarningColor
        };
    }

    public static DiscordEmbedBuilder ChannelConfiguredEmbed(DiscordUser user, string channelTypeIn,
        DiscordChannel channel)
    {
        var channelType = "";
        if (channelTypeIn == "music")
            channelType = "Music channel";
        else if (channelTypeIn == "cmd")
            channelType = "Command channel";
        else if (channelTypeIn == "logs")
            channelType = "Logs channel";

        return new DiscordEmbedBuilder
        {
            Description = $"{channelType} configured to {channel.Mention}",
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                IconUrl = user.AvatarUrl,
                Text = user.Username
            },
            Color = Bot.MainEmbedColor
        };
    }

    public static DiscordEmbedBuilder AboutMemberEmbed(DiscordMember member)
    {
        var roleString = from r in member.Roles
            select $"<@&{r.Id}>";

        return new DiscordEmbedBuilder()
            .WithTitle("About")
            .WithAuthor($"{member.Username}", $"https://discord.com/users/{member.Id}", member.AvatarUrl)
            .AddField("Member's ID:", member.Id.ToString(), true)
            .AddField("Member's display name on server:", member.DisplayName, true)
            .AddField("Member's account created at ", $"{member.CreationTimestamp:dd.MM.yyyy - hh:mm:ss}")
            .AddField("Member joined at ", $"{member.JoinedAt:dd.MM.yyyy - hh:mm:ss}")
            .AddField("Member's roles ", string.Join(", ", roleString));
    }
}