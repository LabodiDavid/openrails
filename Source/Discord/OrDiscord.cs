using System;
/* DISCORD RICH PRESENCE 
 * In this file, you can specify the texts for the rich presence, and the client ID for Discord App.
 * https://discord.com/rich-presence
 * https://discord.com/developers/docs/rich-presence/how-to
 */
namespace Discord
{
    public class OrDiscord
    {
        private DiscordRpc.EventHandlers handlers;  // EVENT HANDLERS
        private DiscordRpc.RichPresence presence; // DISCORD RICH PRESENCE PROPERTIES - List of properties: DiscordRpc.cs - Line 62
        private string CLIENT_ID = "789239264336543814"; // DISCORD APP CLIENT ID

        public OrDiscord()
        {
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize(this.CLIENT_ID, ref this.handlers, true, null);
            UpdateStatus(false);
        }
        private long getCurrentTime() //UNIX FORMAT - for DISCORD API needs.
        {
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)timeSpan.TotalSeconds;
        }
        public void UpdateStatus(bool inGame, string startAt = "", string HeadTo = "")
        {
            if (inGame == true) {
                this.presence.details = "Driving train between:";
                this.presence.state = startAt + " - " + HeadTo;
                this.presence.largeImageKey = "in-game-image";
                this.presence.smallImageKey = "orts-image";
                this.presence.startTimestamp = this.getCurrentTime();
            }else{
                this.presence.details = "In Main Menu";
                this.presence.state = "";
                this.presence.largeImageKey = "orts-image";
            }
            this.presence.largeImageText = "Open Rails (MSTS) - Train Simulator";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

    }
}
