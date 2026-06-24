# GitHub Copilot App — Build 2026 Demo Guide

> **Target audience:** Developers who want to explore the new **agent-native desktop experience** introduced at Microsoft Build 2026.
> **Sample project:** The `.NET 10` TodoApi in `src/TodoApi` of this repository.
> **Changelog sources:** [Copilot App GA (Jun 17 2026)](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) · [Expanded technical preview (Jun 2 2026)](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/)

---

## Prerequisites

| Requirement | Notes |
|-------------|-------|
| GitHub Copilot App | [Download](https://github.com/github/app) — Windows, macOS, Linux |
| GitHub Copilot subscription | Pro / Pro+ / Business / Enterprise (GA) |
| .NET SDK | 10.0 |
| Git | ≥ 2.45 (worktree support) |

### Install and sign in

1. Download the Copilot App from [github.com/github/app](https://github.com/github/app).
2. Install it (`.exe` / `.dmg` / `.AppImage`).
3. Sign in with your GitHub account.
4. Grant access to this repository (`sujithq/cautious-octo-fortnight`).

---

## Demo 1 — My Work Dashboard

**What it shows:** A unified, real-time view of all agent sessions, issues, and pull requests across your repositories.

### Steps

1. Open the Copilot App — you land on the **My Work** dashboard.
2. Observe the layout:
   - **Active sessions** — running agents and their current task.
   - **Recent PRs** — pull requests opened by agents or by you, with their CI status.
   - **Open Issues** — issues assigned to you or to Copilot agents.
   - **Repositories** — quick-access tiles for your most active repos.
3. Pin this repository (`cautious-octo-fortnight`) to your dashboard:
   - Click **⊕ Add repository** → search for and select `sujithq/cautious-octo-fortnight`.
4. Click into the repository tile to see its specific issues, PRs, and active agents.

---

## Demo 2 — Starting an Agent Session

**What it shows:** Launch a Copilot agent that runs in an isolated git worktree — no risk of overwriting your local work.

### Steps

1. From the **My Work** dashboard, click **[+ New Session]**.
2. Select repository: `cautious-octo-fortnight`.
3. Choose session type:
   - **Local** — runs on your machine, instant feedback.
   - **Background** — runs in an isolated worktree on your machine.
   - **Cloud** — runs on GitHub's infrastructure.
4. Select **Background** for this demo.
5. Enter the task:

   ```
   Add a `Priority` field (enum: Low, Medium, High) to the TodoItem record.
   Update the seed data in Program.cs with sample priorities.
   Add a GET /todos/high-priority endpoint returning only High-priority items.
   Write the xUnit test. Run dotnet build and dotnet test before finishing.
   ```

6. Click **Start** — the agent card appears in **Active Sessions**.
7. The status indicator cycles: `Planning → Coding → Testing → Done`.
8. Click the session card at any time to see the live log.

> **Key point:** Your working copy is untouched. The agent operates in a separate git worktree created automatically by the App.

---

## Demo 3 — Canvas: Collaborative Visual Workspace

**What it shows:** Canvas is a shared, editable surface where humans and agents collaborate on plans, checklists, and task boards.

### Steps

1. Inside an active session, click the **Canvas** tab (top-right of the session pane).
2. The agent populates the Canvas with its execution plan — e.g. a Markdown checklist:

   ```markdown
   ## Implementation Plan: Priority feature
   - [x] Update TodoItem record with Priority enum
   - [x] Update seed data
   - [ ] Add /todos/high-priority endpoint
   - [ ] Write xUnit test
   - [ ] dotnet build ✓
   - [ ] dotnet test ✓
   ```

3. **Human edit:** Click any checklist item and add a note:
   > _"Also add a filter query param ?priority= to GET /todos"_

4. The agent reads your edit on its next iteration and incorporates the change.
5. Switch the Canvas view to **Kanban**:
   - Drag the _"Write xUnit test"_ card to the **In Review** column.
   - The agent acknowledges the status change in chat.
6. Switch to **Timeline** view to see elapsed time per task.

---

## Demo 4 — Parallel Agent Sessions

**What it shows:** Run multiple agents simultaneously on the same repository with zero file conflicts.

### Steps

1. From the **My Work** dashboard, start a **second** session on `cautious-octo-fortnight`:

   ```
   Add XML doc comments to every public type in src/TodoApi.
   Verify the project still builds cleanly.
   ```

2. Now you have two sessions running in parallel — each with its own worktree:
   - Session A: adding `Priority` feature.
   - Session B: adding doc comments.
3. Monitor both cards in the **Active Sessions** column.
4. When Session B finishes first, click **Review** → inspect the diff.
5. Click **Open Pull Request** — the App creates a PR directly from the session's worktree.
6. Merge Session B's PR; the worktree is automatically cleaned up.
7. Session A continues unaffected.

---

## Demo 5 — Agent Merge

**What it shows:** Agent Merge monitors a PR through CI checks and merges it automatically when all conditions are met.

### Steps

1. Open the PR created in Demo 4 (Session B's doc-comment PR).
2. In the **PR details** pane inside the App, toggle **Agent Merge: On**.
3. Configure the merge rules:
   - ✅ All CI checks pass.
   - ✅ At least 1 approving review.
   - ✅ No unresolved conversations.
4. Approve the PR yourself (or have a teammate approve it).
5. Once CI turns green and all rules are satisfied, Agent Merge automatically merges the PR and posts a comment:
   > *"Merged by Agent Merge — all conditions satisfied."*
6. The worktree and branch are cleaned up.

> **Key point:** You set the policy once; Agent Merge does the watching and merging for you.

---

## Demo 6 — Issue to Pull Request (end-to-end)

**What it shows:** The full agentic workflow — from a GitHub Issue to a merged PR — entirely within the Copilot App.

### Steps

1. In the **Issues** section of the `cautious-octo-fortnight` tile, click **[+ New Issue]**:
   - **Title:** `Add search endpoint for todos by keyword`
   - **Body:**
     > _Implement GET /todos/search?q={keyword} that returns todos whose Title contains the keyword (case-insensitive). Include an xUnit integration test._

2. Click **Assign to Copilot** in the issue sidebar.
3. The App creates a **Cloud Session** automatically.
4. Watch the Canvas: the agent plans, codes, and tests in real time.
5. Leave a comment on the Canvas or in the Issue:
   > _"Make the search case-insensitive."_
6. The agent reads the comment and updates its implementation.
7. When done, click **Review Pull Request** — inspect the diff in the App.
8. Enable **Agent Merge** and approve — the PR is merged and the issue is closed automatically.

---

## Demo 7 — Copilot SDK (Custom Agent Skills)

**What it shows:** Use the generally available Copilot SDK (GA since Build 2026) to create a custom skill and register it with the App.

### Steps

1. Clone the SDK sample (outside this repo):

   ```bash
   git clone https://github.com/github/copilot-sdk-samples
   cd copilot-sdk-samples/dotnet
   ```

2. Inspect `SkillDefinition.cs` — skills are plain .NET 10 classes annotated with `[CopilotSkill]`.
3. Run the sample skill host:

   ```bash
   dotnet restore
   dotnet run
   # Listening on http://localhost:6789
   ```

4. In the Copilot App, go to **Settings → Extensions → Add Skill Host**:
   - URL: `http://localhost:6789`
   - Name: `My Todo Skills`

5. In a new session on `cautious-octo-fortnight`, use the custom skill:

   ```
   @my-todo-skills generate a release note summary for this week's merged PRs
   ```

6. The App routes the request to your local skill, which calls the GitHub API, and returns a formatted release note.

---

## Demo 8 — Cloud Automations (GA feature)

**What it shows:** Schedule recurring agent work to run in GitHub's cloud on a timed basis — independent of your local machine. Added at GA (June 17 2026).

### Steps

1. In the Copilot App, navigate to **Settings → Cloud Automations**.
2. Click **[+ New Automation]** and configure:
   - **Repository:** `cautious-octo-fortnight`
   - **Schedule:** Every Monday at 09:00 UTC
   - **Task:**
     ```
     Run dotnet test on the repository.
     If any tests fail, open a GitHub Issue titled "Automated test failure — {date}"
     with the failing test names and stack traces in the body.
     ```
3. Click **Save**. The automation is stored in GitHub's cloud — it runs even if your machine is off.
4. Trigger a manual run immediately by clicking **▶ Run Now** to verify the setup.
5. Check the **Automation Runs** tab to see the log of previous executions and their outcomes.
6. View any Issues created by the automation directly from the My Work dashboard.

> **Key point:** Cloud Automations turn recurring chores (nightly test runs, weekly security scans) into zero-maintenance scheduled agents.

---

## Demo 9 — BYOK Models (Bring Your Own Key)

**What it shows:** Run Copilot agent sessions against your own model provider (OpenAI, Azure OpenAI, Anthropic) so data stays in your tenancy. Added at GA (June 17 2026).

### Steps

1. Go to **Settings → Models → Add Provider**.
2. Choose **Azure OpenAI** and fill in:
   - **Endpoint:** `https://my-company.openai.azure.com/`
   - **API Key:** _(your key)_
   - **Deployment:** `gpt-5-turbo`
3. Click **Test Connection** — the App verifies the credentials.
4. Click **Save** — your provider appears in the model picker.
5. Start a new session on `cautious-octo-fortnight` and select **my-company / gpt-5-turbo** from the model dropdown.
6. Run a prompt — the App routes inference to your Azure deployment. No tokens leave your tenancy.
7. Switch back to a GitHub-hosted model at any time via the picker.

> **Key point:** Enterprises with strict data-residency requirements can now use the full Copilot UX with their own models.

---

## Demo 10 — Plugin Marketplace

**What it shows:** Browse, install, and use Canvas extensions and custom skills from the plugin marketplace. Added at GA (June 17 2026).

### Steps

1. In the Copilot App, open **Settings → Extensions → Marketplace**.
2. Browse categories: **Canvas extensions**, **Skills**, **MCP Servers**, **Integrations**.
3. Search for `Jira` → click **Install** on the official Jira plugin.
4. The plugin adds:
   - A **Jira Canvas** type — create a Canvas that shows a live Jira board.
   - A `jira` skill — agents can now create and update Jira tickets.
5. Create a new session on `cautious-octo-fortnight` and open a Canvas → click **+ New Canvas → Jira Board**.
6. Log in to your Jira instance when prompted.
7. The Canvas shows your Jira sprint board — agents can move cards and create tickets as they complete tasks.

> **Key point:** The marketplace makes the Copilot App extensible — your team's tools come to you, not the other way round.

---

## Architecture summary

```
┌─────────────────────────────────────────────────────┐
│                 Copilot App (desktop)                │
│  ┌──────────────┐  ┌───────────┐  ┌──────────────┐  │
│  │  My Work     │  │  Canvas   │  │ Agent Merge  │  │
│  │  dashboard   │  │ workspace │  │  engine      │  │
│  └──────────────┘  └───────────┘  └──────────────┘  │
│                                                      │
│  ┌────────────────────────────────────────────────┐  │
│  │            Plugin Marketplace                  │  │
│  │  Canvas extensions · Skills · MCP · Integrations│ │
│  └────────────────────────────────────────────────┘  │
│                                                      │
│  Session A (worktree-a)   Session B (worktree-b)     │
│  └─ Local agent           └─ Background agent        │
│         │                         │                  │
│  ┌──────▼─────────────────────────▼──────────────┐   │
│  │           Git worktree isolation layer         │   │
│  └────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────┘
         │                      │
    GitHub.com              GitHub Actions
    (Issues / PRs)      Cloud Automations / Cloud agents
```

---

## Tips

- **Pause All** — stop all active agents instantly if you spot a problem (Agent HQ toolbar).
- **Steer mid-run** — click a running session and type a follow-up message; the agent adjusts without restarting.
- **Sandbox mode** — toggle **Sandbox** on a session to run generated code in a cloud container before it touches your local machine.
- **Session export** — export a Canvas as a Markdown file to share the plan with your team.
- **MCP integration** — connect Model Context Protocol servers in **Settings → MCP** to give agents access to Jira, Slack, Datadog, and more.
- **Canvas persists** — Canvas state is preserved across app restarts and reconnects, so long-running sessions pick up exactly where they left off.
- **Cloud Automations** — schedule recurring tasks (nightly tests, weekly security scans) that run on GitHub's infrastructure without your machine being on.
- **BYOK** — use your own Azure / Anthropic / OpenAI key to keep all data inside your tenancy.

