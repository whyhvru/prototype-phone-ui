using UnityEngine;

namespace Module.UI.Messenger.Bot
{
    public static class FriendMessagePool
    {
        private static readonly string[] _messages = new[]
        {
            "Hey, just checking in on you.",
            "I saw something funny today.",
            "Hope your day is going well.",
            "Do you want to catch up soon?",
            "I found a neat idea recently.",
            "Have you heard any good news?",
            "I was thinking about our plans.",
            "That story made me smile.",
            "Everything is quiet here today.",
            "I found a new song I like.",
            "I hope you are feeling good.",
            "Do you have any free time?",
            "I liked that thing you said.",
            "It would be nice to talk later.",
            "I just finished a small task.",
            "Do you want to share something?",
            "I’m around if you want to chat.",
            "Did you see that update?",
            "I’m sending a quick hello.",
            "I’m curious what you think about this."
        };

        public static string GetRandomMessage() => _messages[Random.Range(0, _messages.Length)];
    }
}