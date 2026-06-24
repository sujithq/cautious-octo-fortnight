# GitHub Copilot CLI — Build 2026 Demo Guide

> **Target audience:** Developers who live in the terminal and want to see Copilot CLI's new features from Microsoft Build 2026.
> **Sample project:** The `.NET 10` TodoApi in `src/TodoApi` of this repository.

---

## Prerequisites

| Requirement | Notes |
|-------------|-------|
| GitHub CLI | ≥ 2.72 — `gh --version` |
| gh-copilot extension | `gh extension install github/gh-copilot` |
| GitHub Copilot subscription | Pro / Pro+ / Business / Enterprise |
| .NET SDK | 10.0 |
| Microphone (optional) | Required for voice input demo |

### Verify installation

```bash
gh copilot --version
# github.com/github/gh-copilot v2.x.x
```

### Authenticate

```bash
gh auth login
gh copilot auth
```

---

## Demo 1 — Redesigned Terminal UI

**What it shows:** The new tab-based terminal interface introduced in June 2026.

### Steps

1. Launch Copilot CLI in experimental UI mode:

   ```bash
   gh copilot chat
   /experimental
   ```

2. Notice the **tab bar** at the top of the interface:
   - `Chat` — main conversation
   - `Issues` — browse and create GitHub Issues without leaving the terminal
   - `Pull Requests` — list, open, and comment on PRs
   - `Gists` — manage your gists

3. Switch to the **Issues** tab:

   ```
   Press Tab (or type /issues)
   ```

4. Browse open issues for this repository:

   ```
   list issues sujithq/cautious-octo-fortnight
   ```

5. Navigate back to `Chat` and ask:

   ```
   Explain the TodoItem record in src/TodoApi/Models/TodoItem.cs
   ```

6. Observe the **theme-aware colours** — try changing theme:

   ```bash
   /theme github
   /theme high-contrast
   /theme colorblind
   ```

> **Key point:** You never need to leave the terminal to check Issues or PRs — everything is accessible via tabs.

---

## Demo 2 — Voice Input

**What it shows:** Speak your prompts instead of typing them; all transcription is done locally.

### Steps

1. Inside `gh copilot chat`, enable voice:

   ```
   /voice
   ```

2. Follow the one-time prompt to download the local voice runtime (~150 MB, English + Spanish models included).

3. **Short prompt** — hold `Space` and speak:

   > *"Add a search endpoint that filters todos by title keyword."*

   Release `Space` to submit.

4. **Longer prompt** — press `Ctrl+X` then `V` to start recording, speak, then press `Ctrl+X V` again to stop:

   > *"Add a PATCH endpoint to mark a single todo item as complete. Write the xUnit test for it as well. Use the same pattern as the existing endpoints in Program.cs."*

5. Copilot transcribes locally (no audio sent over the network) and responds with a code plan.

> **Key point:** 100% local transcription — no audio ever leaves your machine.

---

## Demo 3 — Rubber Duck Cross-Model Review

**What it shows:** Your main Copilot agent passes its output to a second AI model from a different family for critique, catching blind spots before you accept any code.

### Steps

1. In `gh copilot chat`, ask Copilot to generate something non-trivial:

   ```
   Write a middleware for the TodoApi that rate-limits requests to 60 per minute per IP address.
   Show me the implementation in a code block.
   ```

2. Once Copilot responds, trigger Rubber Duck review:

   ```
   /rubber-duck
   ```

3. A second model (different AI family) critiques the generated code — for example:
   - *"The in-memory dictionary won't work in a multi-instance deployment."*
   - *"The sliding window logic has an off-by-one in the expiry check."*

4. Ask Copilot to incorporate the feedback:

   ```
   Apply the Rubber Duck suggestions and fix the identified issues.
   ```

5. Run `/rubber-duck` again to confirm the revised code passes critique.

> **Key point:** Two AI models are better than one — the Rubber Duck catches issues invisible to the first model.

---

## Demo 4 — Prompt Scheduling

**What it shows:** Schedule recurring or delayed prompts — like a cron job for AI tasks.

### Steps

#### Recurring task

1. In `gh copilot chat`, schedule a daily build-health check:

   ```
   /every 1h
   Run dotnet build in src/TodoApi and report any warnings or errors.
   ```

2. Copilot acknowledges the schedule. Every hour it re-runs the build and summarises the output.

3. List active schedules:

   ```
   /schedules
   ```

4. Cancel the schedule:

   ```
   /cancel <schedule-id>
   ```

#### Delayed one-shot task

1. Schedule a reminder to run the tests after a short delay:

   ```
   /after 5m
   Run dotnet test and show me the results.
   ```

2. After 5 minutes, Copilot executes the prompt and prints the test results.

---

## Demo 5 — Session History with `/chronicle`

**What it shows:** Query the history of your Copilot CLI sessions to generate a standup report or review what was accomplished.

### Steps

1. Have a few exchanges with Copilot (ask it to explain code, generate endpoints, etc.).
2. Request a summary of the session so far:

   ```
   /chronicle today
   ```

3. Copilot produces a bullet-point summary — e.g.:
   - Added `DueDate` field to `TodoItem`.
   - Created `/todos/overdue` endpoint.
   - Wrote 2 xUnit tests.

4. Request a standup format:

   ```
   /chronicle standup
   ```

   Output example:
   > **Yesterday:** Added overdue endpoint and tests.
   > **Today:** Planning to add rate-limiting middleware.
   > **Blockers:** None.

---

## Demo 6 — Multi-Model Switching

**What it shows:** Switch AI models mid-session to pick the best model for each task.

### Steps

1. Start a session and check available models:

   ```
   /models
   ```

   Example output:
   ```
   Available models:
     * claude-sonnet-4-5  (current)
       gpt-5-mini
       gemini-3-5-flash
       polaris-preview      (Project Polaris – Microsoft in-house)
   ```

2. Switch to a different model:

   ```
   /model polaris-preview
   ```

3. Ask the same question you asked before:

   ```
   Explain the rate-limiting middleware we discussed earlier.
   ```

4. Compare the quality and style of the responses.

5. Switch back:

   ```
   /model claude-sonnet-4-5
   ```

---

## Quick-reference cheat sheet

| Command | Description |
|---------|-------------|
| `/experimental` | Enable new tab-based terminal UI |
| `/voice` | Enable local voice input |
| `/rubber-duck` | Cross-model review of last response |
| `/every <interval>` | Schedule a recurring prompt |
| `/after <delay>` | Schedule a one-shot delayed prompt |
| `/schedules` | List active schedules |
| `/cancel <id>` | Cancel a schedule |
| `/chronicle [today\|standup]` | Session history and summaries |
| `/models` | List available AI models |
| `/model <name>` | Switch active model |
| `/theme <name>` | Change UI colour theme |
| `/issues` | Switch to Issues tab |
| `/prs` | Switch to Pull Requests tab |
| `/gists` | Switch to Gists tab |
