# SoftGames Unity Assignment

## 💡 Project Overview

This Unity project was developed with clarity and simplicity as top priorities.

I intentionally avoided complex architectural patterns.
The goal was to make the code clean, readable, and easy to understand for any Unity developer regardless of experience level.

---

## 📁 Project Structure

Assets/

├── _Project/

│ ├── 0-Main/ ← Main UI and menu navigation

│ ├── 1-AceOfShadows/ ← Card stacking and smooth movement

│ ├── 2-MagicWords/ ← Emoji-based dialogue system

│ ├── 3-PhoenixFlame/ ← Particle effect with color cycling

│ └── Shared (Core)/ ← Common assets (UI components, fonts, materials)


---

## 🧩 External Tools / Assets

- The only third-party tool used is **DOTween** (for tweening animations)
- No additional external plugins or assets were added to keep the project lightweight and transparent

---

## 🔤 Unicode Emoji Rendering

In the **“Magic Words”** task, I updated the TextMeshPro emoji sprite asset to allow parsing and replacing custom placeholders such as `{laughing}` or `{win}` with actual Unicode emojis like 😂 or 🏆.

---

## 🌈 Color Cycling (Phoenix Flame)

The fire color changes are handled via **Animator Controller**, transitioning between animated Particle System `Start Color` values:
- Orange → Green → Blue → back to Orange
- Smooth transitions and looping behavior
- Controlled via a single UI button using trigger-based animation transitions

---

## 🌐 Live WebGL Demo

You can test the project here:

🔗 https://6820248d9490e13466bf1a1c--shimmering-gumdrop-0b112d.netlify.app/

- Built with Unity WebGL
- Responsive for both desktop and mobile browsers

---

## 🧪 How to Run Locally

1. Open `Main.unity` scene
2. Press Play to launch the main menu
3. Choose one of the three tasks:
   - “Ace of Shadows”
   - “Magic Words”
   - “Phoenix Flame”

Each module is implemented and tested as a standalone demo.

---

## 📦 Tech Stack

- Unity 6
- C# (clean, readable coding style)
- DOTween (for smooth movement and transitions)
- TextMeshPro (for Unicode emoji rendering)
- WebGL Build

---

## ✉️ Contact

Feel free to reach out if you'd like to collaborate, give feedback, or ask questions about the implementation.
