# GitHub Copilot CLI — Build 2026 Demo Guide

> **Target audience:** Developers who live in the terminal and want to see Copilot CLI's new features from Microsoft Build 2026.
> **Sample project:** The `.NET 10` TodoApi in `src/TodoApi` of this repository.
> **Changelog source:** [github/copilot-cli changelog](https://github.com/github/copilot-cli/blob/main/changelog.md) · [Copilot CLI June 2026 blog post](https://github.blog/changelog/2026-06-02-copilot-cli-improved-ui-rubber-duck-prompt-scheduling-and-voice-input/)

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

## Demo 7 — Security Review (now available to all users)

**What it shows:** `/security-review` was previously behind `--experimental`; as of June 2026 it is available to every paid Copilot subscriber.

### Steps

1. Start a chat session:

   ```bash
   gh copilot chat
   ```

2. Open `src/TodoApi/Program.cs` in the editor and attach it:

   ```
   @src/TodoApi/Program.cs
   /security-review
   ```

3. Copilot performs a static security analysis and reports findings grouped by severity (Critical, High, Medium, Low).
4. For each finding, ask Copilot to fix it:

   ```
   Fix the High severity finding about missing input validation on the POST /todos endpoint.
   ```

5. Review the suggested patch and accept it.

> **Key point:** `/security-review` is now a first-class command — no flags needed.

---

## Demo 8 — Worktree Management (`/worktree`)

**What it shows:** Create a git worktree and jump into it without leaving the CLI session — the changelog-confirmed `/worktree` (alias `/move`) command.

### Steps

1. Start a CLI session from the repository root:

   ```bash
   cd /path/to/cautious-octo-fortnight
   gh copilot chat
   ```

2. Create a new worktree for a feature branch:

   ```
   /worktree feature/search-endpoint
   ```

   The CLI creates `../cautious-octo-fortnight.worktrees/feature-search-endpoint`, checks out a new branch there, and moves your session into it.

3. Any uncommitted changes from the main working copy are carried along automatically.

4. Ask Copilot to implement the feature:

   ```
   Add GET /todos/search?q={keyword} — case-insensitive title search. Write the xUnit test.
   ```

5. When done, switch back to your main session:

   ```
   /session main
   ```

6. The worktree branch is ready for a PR — without ever touching your main working copy.

#### Alternative: press `W` from an issue detail

1. Switch to the Issues tab and open any issue.
2. Press **`W`** — the CLI creates a worktree pre-named after the issue number and moves your session into it immediately.

---

## Demo 9 — Diff View Improvements

**What it shows:** The changelog documents significant `/diff` enhancements: file tree, inline comments, whitespace toggle, and content search.

### Steps

1. After Copilot makes code changes, review them with the enhanced diff view:

   ```
   /diff
   ```

2. The diff opens with a **file tree sidebar** on the left. Click any filename to jump to its first change.

3. Press **`w`** to toggle whitespace-only changes on/off — useful when Copilot reformats code.

4. Press **`/`** to open the content search bar inside the diff. Type a term and use **`n`** / **`N`** to jump between matches.

5. Place the cursor on a changed line and press **`c`** to open the **inline comment editor** — add review notes directly in the diff without switching to GitHub.com.

6. Use **stacked diffs** to compare multiple sequential changes:

   ```
   /diff --stacked
   ```

---

## Demo 10 — Session Diagnostics (`/diagnose`)

**What it shows:** Analyze session logs to find problems — a new command added in the June 2026 CLI changelog.

### Steps

1. If a session behaves unexpectedly (slow responses, tool errors), run:

   ```
   /diagnose
   ```

2. The CLI scans the current session log and reports:
   - Tool call failures and their error codes.
   - Slow request latencies (> 5 s highlighted).
   - Model switches and their triggers.
   - Content-exclusion events.

3. Ask Copilot to fix the most common issue:

   ```
   The diagnose output shows repeated content-exclusion events on src/TodoApi/Program.cs.
   Can you help me adjust the exclusion config?
   ```

---

## Demo 11 — MCP Registry (`/mcp registry`)

**What it shows:** Browse and install Model Context Protocol servers from the built-in marketplace — added in the June 2026 CLI changelog.

### Steps

1. Open the MCP registry:

   ```
   /mcp registry
   ```

2. A searchable list of MCP servers appears (Jira, Datadog, Slack, Docker, AWS …).

3. Search for `dotnet`:

   ```
   /mcp registry search dotnet
   ```

4. Install the `.NET diagnostics` server:

   ```
   /mcp registry install dotnet-diagnostics
   ```

5. The server is added to your session. Now ask:

   ```
   Use the dotnet-diagnostics tool to check for memory leaks in the running TodoApi process.
   ```

6. Copilot calls the MCP tool and returns diagnostics inline.

> **Key point:** MCP servers extend Copilot with any external tool — no custom code required.

---

## Demo 12 — Rewind (`/rewind`)

**What it shows:** Restore only the files Copilot changed — leaving your own edits intact — using the experimental `/rewind` command.

### Steps

1. Enable experimental features:

   ```
   /experimental
   ```

2. Let Copilot make some changes, then decide you want to roll back:

   ```
   /rewind
   ```

3. Choose the rewind mode:
   - **Conversation only** — undo the chat context but keep file changes.
   - **Conversation + files** — revert files to their state before the turn, your own edits are preserved.

4. Confirm the operation. Copilot shows exactly which files will be restored.

> **Key point:** Unlike `git checkout`, `/rewind` is Copilot-change aware — it only touches what the agent wrote.

---

## Demo 13 — Settings Dialog (`/settings`)

**What it shows:** Browse and edit all user settings interactively from one screen — no JSON editing needed.

### Steps

1. Open the settings dialog:

   ```
   /settings
   ```

2. Navigate with arrow keys through categories: **Appearance**, **Models**, **Agents**, **MCP**, **Billing**, **Accessibility**.

3. Change the default model:
   - Navigate to **Models → Default model** → press **Enter** → select `polaris-preview`.

4. Enable the rubber-duck complementary model strategy:
   - Navigate to **Agents → Rubber Duck → Complementary model** → toggle **On** → select `gpt-5-mini`.

5. Save with **Ctrl+S** or the **Save** button — changes take effect immediately without restarting.

---

## Quick-reference cheat sheet

| Command | Description |
|---------|-------------|
| `/experimental` | Enable experimental features |
| `/voice` | Enable local voice input |
| `/rubber-duck` | Cross-model review of last response |
| `/security-review` | Static security analysis (all users, no flag needed) |
| `/worktree [branch]` | Create git worktree and switch into it |
| `/rewind` | Restore files Copilot changed (experimental) |
| `/diff` | Enhanced diff with file tree, inline comments, search |
| `/diagnose` | Analyze session logs for problems |
| `/settings` | Interactive settings dialog |
| `/mcp registry` | Browse and install MCP servers |
| `/every <interval>` | Schedule a recurring prompt (natural language OK) |
| `/after <delay>` | Schedule a one-shot delayed prompt |
| `/loop` | Alias for `/every` |
| `/schedules` | List active schedules |
| `/cancel <id>` | Cancel a schedule |
| `/chronicle [today\|standup]` | Session history and summaries |
| `/models` | List available AI models |
| `/model <name>` | Switch active model |
| `/theme <name>` | Change UI colour theme |
| `/issues` | Switch to Issues tab |
| `/prs` | Switch to Pull Requests tab |
| `/gists` | Switch to Gists tab |
| `/fork` / `/branch` | Create a fork / branch |
| `W` (in issue/PR) | Create worktree for that issue/PR |

