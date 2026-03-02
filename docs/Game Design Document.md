# Game Design Document: OmniLink (Systems Archeologist)

###### Version: 1.5.1 

###### Status: Planning and Phase 1 Dev

(Most planning and initial documentation utilized the Gemini Brainstormer Gem)

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 1\. Executive Summary

OmniLink is a 2.5D puzzle-adventure game set in a satirical corporate dystopia. Players act as a "Junior Systems Archeologist" for OmniCorp, repairing ancient OS circuits (Directory Dungeons) using Computer Science logic.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 2\. High-Level Concept

 	• **Genre**: Puzzle-Adventure / Narrative Lite (Visual Novel elements)/ Idle-Incremental.

 	• **Platform**: Android (Primary), PC/Web (Secondary).

 	• **Visual Style**: 2D Top-Down (2.5D aesthetic). High-quality pixel art or clean vector assets (Kenney.nl).

 	• **Target Audience**: Students, aspiring developers, and fans of classic logic puzzles and idle games (e.g., Cell to Singularity, Math Blaster).

 	• **Core Hook**: Solving puzzles via actual Computer Science logic integrated into a physical world, fueled by a meta-game of background resource optimization.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 3\. Narrative \& World-Building



#### 3.1 The Premise

The year is 20XX. OmniCorp owns the digital infrastructure of the world. You are hired to "debug" the ancient sectors of the server-city. As you build relationships with your coworkers and "Sync" with the game world, you discover that the safety protocols may be a lie and a high-stakes contest for control of the network is underway.



#### 3.2 Key Locations

 	• **The Hub (The Breakroom)**: Basic Version (Phase 1) serves as a menu/story hub. Later, a Visual Novel-style environment for "Coffee Breaks," relationship building, and lore delivery.

 	• **Directory Dungeons**: Top-down exploration areas (possibly themed after hardware e.g., The Silicon Sands, The Optical Forest).

 	• **The Command Prompt**: A specialized interface for managing your "Background Processes" (The Idle Meta-Game).

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 4\. Development Roadmap (Phasing)



##### 🟢 Phase 1: The Functional Core (Priority 1)

 	• **The Logic Engine**: C# implementation of AND, OR, NOT, XOR gates with Unit Testing.

 	• **Dungeon Alpha**: 2D Top-down movement, basic collision, and "Terminal" interactions.

 	• **UI/UX**: Puzzle overlay interface and basic HUD.

 	• **Persistence**: Save/Load system for player progress and JSON-based level loading.

 	• **Monetization Foundation**: Implementation of the Ad-Middleware and Subscription verification logic.

##### 🟡 Phase 2: Content \& Polish

 	• **Visual Novel Elements**: Expanded dialogue system and character portraits.

 	• **Advanced Puzzles**: Introduction of Arithmetic and Networking modules.

 	• **Audio/Visual FX**: Sound effects, music, and particle systems for "Syncing."

##### 🔴 Phase 3: Social Meta \& Replayability (Future Implementation)

 	• **Office Culture**: Global Morale and Individual Trust systems. hopefully we can tie in software or acedemia environment related humor

 	• **The Resistance**: Unionization mechanics and Solidarity Buffs.

 	• **System Instability**: Rogue-lite "Recursive Run" mode and Kernel Patches.

 	• **Sabotage Elements**: High-risk mechanics triggered by low morale.

&nbsp;	• **Elements of Chance**: Updates to other game mechanics to make things stay fresh, unique, and keep late-game difficulty scaling possible

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 5\. Gameplay Mechanics (Core)

#### 5.1 Exploration



 	• Top-down 2D movement.

 	• Interacting with "Terminals" to trigger puzzle overlays.

 	• Environmental hazards that require "Logic Buffs" to bypass.



#### 5.2 The Logic Engine

 	• **Logic Gates**: Puzzles require connecting inputs to outputs using AND, OR, NOT, XOR gates.

&nbsp;		- **Input/Output**: Connect gates to satisfy the "Target Boolean" of the sector.

 	• **Difficulty Scaling**: Puzzles evolve from basic boolean logic to algebra, networking, and eventually compiler-level syntax puzzles.

&nbsp;	• **Evaluation:** Real-time feedback via the C# Logic Engine.

 	• **Achievements**: Rewarding "Perfect Syncs" (solving puzzles in the minimum number of moves).

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 6\. Monetization Strategy: "Corporate Compliance Tiers"

&nbsp;	• **Agreeable Integration**: The monetization is designed to be thematic and non-intrusive.

&nbsp;		- Ads are framed as in-universe lore or "Mandatory Compliance," maintaining immersion.

&nbsp;		- Should be thematic, should almost be enjoyable; short, and if possible, have messaging I prefer.

 	• "**Sponsorship**" Mode (Free): Ad-Supported Free Play with minor benefit for mandatory ad-activity and bigger perks for optional ad-watching.

 	• "**Supervisory**, **Admin**, or **Executive Overrides**" (small IAP): short-term ad-free passes ($0.99/day or 1.99/14 days 2.99/30 days respectively)

 	• **Corporate Subsidized Employee Subscriptions** (subscriptions through Google Play or other supporting service): longer term ad-free (2.69/mo for 6 months or 1.69/mo for 12 months)

 	• **VIP Access:** $19.99 Permanent Unlock

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 7\. Project Goals

 	•**Professionalism**: Maintain a clean, atomic commit history on GitHub.

 	•**Scalability**: Design a modular, decoupled system where new feature can be added.

 	•**Quality**: High emphasis on Test-Driven Development (TDD) and clean, documented C# code.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 7\. Sample Flow Chart (Phase 0 Conceptual)

 	Start Game -> Authentication \& Check Subscription Status.



1. **The Hub (Breakroom)** -> Select "Available Tickets" (Level Selection) or access Command Prompt (Idle Gains).
2. **Enter Dungeon** -> Top-down navigation through Directory Dungeons.
3. **Encounter Terminal** -> Interaction triggers the Puzzle Overlay.
4. **Logic Interface** -> Connect I/O Gates -> Click "Sync" (Validation Check).
5. **Resolution** -> Success: Door/Path Unlocks \& Cache Earned -> Failure: Alarm sounds/Hazard triggers.
6. **Exit Sector** -> Sync Data (Save Progress) -> Server Sync (Ad Opportunity) -> Return to Hub.
