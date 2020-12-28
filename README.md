# KamDiscordBee v1.0.0
A plugin enabling Discord rich presence for MusicBee

Supports custom Applications (album covers in rich presence!)

# Rich presence
![Rich presence](https://i.imgur.com/dh7NpEC.png)

# Settings
![Settings](https://i.imgur.com/0X7J2WR.png)

### Large Image
- textbox - controls the text shown when hovering over image in rich presence
- checkbox "Use custom asset" - controls whether to dynamically change the large image (if you would like to have album covers show up in rich presence)
  - application Id - your application id (you need to upload your album covers to discord app)
  - asset key - key used to access album covers (you can use song metadata tag for this)

### Rich presence info
- top textbox - the top line in rich presence
- bottom textbox - the bottom line in rich presence
- checkbox "Display time playing" - controls whether to show time in rich presence at all
  - checkbox "Show remaining time" - show remaining time (default is elapsed)
- checkbox "Show track number and count" - controls whether to show currently playing track's number

# How to use custom album covers and make them change?
1. Head over to [Discord developer page](https://discord.com/developers/applications) and create your own application
2. Upload album covers to your app
3. Put image keys into metadata tags of songs (For example Custom1)
4. Copy your app id to plugin settings, press save
5. Restart musicbee

Application example:
![Application](https://i.imgur.com/WIXWOKx.png)
![Musicbee tags](https://i.imgur.com/s2CJTzM.png)
