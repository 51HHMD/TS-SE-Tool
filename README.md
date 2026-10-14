# TS SE Tool — Truck Simulator Save Editor

A Windows save editor for **Euro Truck Simulator 2** and **American Truck Simulator**.

> [!IMPORTANT]
> **This fork was modified with AI assistance.**
> The changes that add support for game version 1.60 (save version 102) were written with the help of an AI coding assistant (Claude by Anthropic) and then tested on a real ETS2 save.
> Always **back up your saves** before editing them.

This is a fork of [LIPtoH/TS-SE-Tool](https://github.com/LIPtoH/TS-SE-Tool). All credit for the original tool goes to its author.

---

## Contents

- [What's new in this fork](#whats-new-in-this-fork)
- [Features](#features)
- [Requirements](#requirements)
- [Building from source](#building-from-source)
- [Running the tool](#running-the-tool)
- [Tested with](#tested-with)
- [Roadmap](#roadmap)
- [License](#license)

---

## What's new in this fork

Support for **save version 102** (game version 1.60):

- **Lossless saving.** Each part of the save keeps its original lines. Values you edit are written from the editor, and everything the editor doesn't know about is written back exactly as it was. Unknown or newer data is no longer lost.
- **New 1.60 data.** Added the new economy, player, vehicle and trailer properties, plus the `player_vehicles`, `car_job_log` and `car_job_generator` blocks.
- **More robust loading.** One unreadable value (such as `game_time_initial: nil`) no longer stops the rest of the save from loading.
- **Safer writing.** The new save is fully built before it replaces `game.sii`, so an error can't leave the save truncated.
- **Profile fixes.** `profile.sii` now handles any number of `user_data` entries and no longer loses or blanks values when saved.
- **Updated decoder.** Ships `SII_Decrypt.dll` 1.5.2.57, which can read 1.60 saves.

## Features

**Saves and profiles**
- Add custom paths for save files
- Edit local and Steam saves

**Player**
- Edit player level and skills
- Edit the money in your account

**World**
- Visit cities and take cargo from discovered cities
- Buy and upgrade garages

**Trucks and trailers**
- Repair and refuel your truck
- Repair trailers
- Share truck paint jobs
- Edit and share saved user colors for trucks and trailers

**Jobs and cargo**
- Create custom jobs for the Freight Market
- Make basic edits to the Cargo Market

**Sharing**
- Share truck positions
- Share GPS routes
- Share several truck positions as one Convoy Control pack

## Requirements

| | |
|---|---|
| **OS** | Windows (x64) |
| **Runtime** | .NET Framework 4.7.2 or newer |
| **To build** | Visual Studio 2019 or newer |

## Building from source

1. Clone the repository:
   ```bash
   git clone https://github.com/51HHMD/TS-SE-Tool.git
   ```
2. Open `TS SE Tool.sln` in Visual Studio.
3. Build the **Debug** configuration.
4. Copy the `img`, `lang` and `dbs` folders from an official TS SE Tool release into `TS SE Tool\bin\Debug`.

> [!NOTE]
> Step 4 is required. These resource folders are not part of the repository, and the tool crashes on startup without them.

## Running the tool

1. Start `TS SE Tool\bin\Debug\TS SE Tool.exe` (double-click it, or use a shortcut).
2. Pick your profile and a save.
3. Click **Load**.
4. Make your changes.
5. Click **Save**.

> [!TIP]
> Test your edits on a copy of a save first, then load that copy in the game.

## Tested with

| Game | Version | Save version | Status |
|---|---|---|---|
| Euro Truck Simulator 2 | 1.60 | 102 | ✅ Loads, edits, saves and loads in game |
| American Truck Simulator | 1.60 | 102 | ⚠️ Not tested yet |

## Roadmap

**Short term**
- Finish the sharing features for truck parts
- Add editing and sharing for trailers

**Long term**
- Create jobs for the Cargo Market
- Read map data from the game's files
- Scan mods for data (trucks, cargo and more)

## License

Licensed under the [Apache License 2.0](LICENSE).
Original work © LIPtoH. Modifications in this fork are released under the same license.
