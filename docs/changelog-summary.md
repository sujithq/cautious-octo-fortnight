# Official GitHub Changelog — Copilot Features Since Build 2026

> This document consolidates findings from the official GitHub changelogs.
> Sources checked:
> - **[github/copilot-cli changelog](https://github.com/github/copilot-cli/blob/main/changelog.md)**
> - **[github.blog/changelog — copilot label](https://github.blog/changelog/label/copilot/)**
> - **[VS Code 1.125 release notes](https://code.visualstudio.com/updates)**
> - **[GitHub Copilot in Visual Studio Code — May releases](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/)**
> - **[Copilot App generally available](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/)**
> - **[Copilot SDK generally available](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/)**
> - **[Copilot CLI: Improved UI, rubber duck, prompt scheduling, and voice input](https://github.blog/changelog/2026-06-02-copilot-cli-improved-ui-rubber-duck-prompt-scheduling-and-voice-input/)**
> - **[Updates to GitHub Copilot billing and plans](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/)**

---

## VS Code

| Date | Feature | Source |
|------|---------|--------|
| Jun 17 2026 | VS Code 1.125 released — smarter integrated browser, managed Copilot settings for enterprise | [release notes](https://code.visualstudio.com/updates) |
| Jun 3 2026 | Multi-agent orchestration: multiple specialized agents run in parallel via Agent HQ | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Background agents run in isolated git worktrees | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Remote agents via SSH and Dev Tunnels (session persists after disconnect) | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Nested sub-agents: decompose large tasks into parallel workstreams | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Integrated browser debugger with breakpoint support | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Language Models editor: discover and install model providers (BYOK) | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Agent Skills Management panel: discover, edit, navigate, and search skills | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Context usage visualization: see context window consumption, trigger summarization | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Plan Agent: collaborate on an implementation plan before any code is written | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Jun 3 2026 | Multi-file change diff: view summary, accept/undo changes at file or hunk level | [changelog](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) |
| Apr 8 2026 | Cloud Coding Agent: assign GitHub Issues to Copilot, get back a PR | [changelog](https://github.blog/changelog/2026-04-08-github-copilot-in-visual-studio-code-march-releases/) |
| Apr 8 2026 | Session Chronicle: `/chronicle` queries session history, generates standup reports | [changelog](https://github.blog/changelog/2026-04-08-github-copilot-in-visual-studio-code-march-releases/) |

---

## CLI (`gh copilot`)

> Primary source: [github/copilot-cli changelog](https://github.com/github/copilot-cli/blob/main/changelog.md)

### UI & Navigation
- **New tab-based terminal UI** (home tabs) now enabled for all users — Chat, Issues, Pull Requests, Gists tabs.
- **GitHub theme** applied by default; adapts to system light/dark mode automatically.
- **WCAG AA** colour contrast compliance across all built-in themes.
- **`/settings` interactive dialog** — browse and edit all user settings from one screen.
- **`/diagnose`** — analyze session logs to find problems.
- **Inline image rendering** in the CLI timeline.
- **Prompt frame** visible for all users.

### Agentic & Workflow
- **`/rubber-duck`** — cross-model critic; `/subagents` picker lets you configure the complementary model strategy (opposite-family model selection).
- **`/security-review`** — now available to **all users** without `--experimental`.
- **`/worktree` / `/move`** — create a git worktree and switch into it; move uncommitted changes along.
- **`--worktree [-w]` flag** (experimental) — start a session in a new/existing worktree automatically.
- **`/rewind`** (experimental) — restores only the files Copilot changed (leaves your edits intact), with a conversation-only or conversation+files choice.
- **`/fork` / `/branch`** — create a fork; `/branch` is an alias matching Claude Code's naming.
- Press **`W`** from an issue or PR detail view to create a worktree for that issue/PR instantly.
- **Autopilot mode** handles elicitation, ask_user, sampling, and permission prompts automatically; returns to interactive mode after `task_complete`.

### Scheduling & History
- **`/every` / `/loop`** — schedule recurring prompts; now supports slash commands (e.g. `/every 1d /chronicle standup`) and **natural language** (e.g. "every weekday at 9 am").
- **`/after`** — schedule one-shot delayed prompt; also supports natural language.
- **`/schedules`** — list and cancel scheduled prompts.
- **`/chronicle standup`** — includes recent local sessions in the report.

### Diff & Code Review
- **`/diff`** improvements:
  - File tree sidebar with click-to-jump navigation.
  - Inline comment editor directly in the diff.
  - `w` key to hide whitespace-only changes.
  - Content search with `n`/`N` match navigation.
  - Stacked diffs; wrap long lines.
- **`/app`** — open the GitHub App or browser fallback.

### Models & Integrations
- **Multi-model switching**: model family aliases (`opus`, `sonnet`, `haiku`, `gpt`, `gemini`); `polaris-preview` available.
- **BYOK** (Bring Your Own Key) for OpenAI-compatible providers, including websocket responses support.
- **MCP (Model Context Protocol)**:
  - `/mcp registry` — browse and install MCP servers from a marketplace.
  - Auto-load MCP servers from `.github/mcp.json` workspace config.
  - Plugin-provided MCP servers discovered automatically.
  - OAuth, mTLS, private-CA support for MCP servers.
- **OpenTelemetry** tracing support (GenAI semantic conventions).

### Billing & Access
- **Pay-as-you-go budget** shown at launch; friendly message when additional usage limit is reached.
- **Content exclusion** no longer blocks access during transient rule-service outages.
- **Kerberos/SPNEGO** auto-authentication through corporate forward proxies.

---

## GitHub Copilot App

| Date | Feature | Source |
|------|---------|--------|
| Jun 17 2026 | **Generally available** on Windows, macOS, Linux | [changelog](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) |
| Jun 17 2026 | **Cloud Automations**: schedule recurring agent work in the cloud | [changelog](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) |
| Jun 17 2026 | **BYOK models**: run sessions against your own API keys (OpenAI, Azure, Anthropic) | [changelog](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) |
| Jun 17 2026 | **Plugin Marketplace**: browse, install, and publish Canvas/skill extensions | [changelog](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/) |
| Jun 2 2026 | Expanded technical preview for all paid plans | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **Canvas**: bidirectional visual workspace (checklist, kanban, timeline, markdown) | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **My Work** dashboard: unified view of agents, issues, PRs across repositories | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **Agent Merge**: auto-merge PRs when configurable policy conditions are met | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **Isolated git worktrees** per agent session | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **Sandbox mode**: run generated code in a cloud container before it touches your machine | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |
| Jun 2 2026 | **Canvas preserved** across reconnects/restarts | [changelog](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/) |

---

## Copilot SDK

| Date | Feature | Source |
|------|---------|--------|
| Jun 2 2026 | **Generally available** in Node.js, Python, Go, .NET, Rust, Java | [changelog](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/) |
| Jun 2 2026 | Custom tools, fine-tuned prompt customization, flexible authentication | [changelog](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/) |
| Jun 2 2026 | OpenTelemetry tracing (GenAI semantic conventions) | [changelog](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/) |
| Jun 2 2026 | Cloud and remote session support | [changelog](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/) |
| Jun 2 2026 | Host-provided OAuth tokens for remote MCP servers | [changelog](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/) |

---

## Billing & Plans

| Date | Change | Source |
|------|--------|--------|
| Jun 1 2026 | **Usage-based billing** (AI Credits) replaces flat-rate for all plans | [changelog](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/) |
| Jun 1 2026 | **User-level budget controls** for organizations and enterprises | [changelog](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/) |
| Jun 1 2026 | **Copilot Max** plan introduced for high-usage power users | [changelog](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/) |
| Apr 20 2026 | Student / Pro / Pro+ new signups paused; Copilot Free remains open | [changelog](https://github.blog/changelog/2026-04-20-changes-to-github-copilot-plans-for-individuals/) |

---

## Models

| Date | Change | Source |
|------|--------|--------|
| Aug 2026 (planned) | **Project Polaris** (Microsoft in-house) replaces GPT-4 Turbo as default | Build 2026 keynote |
| Jun 2026 | Claude Fable 5 support added to CLI | CLI changelog |
| Jun 2026 | Gemini 3.5 Flash available in model picker | Changelog |
| Jun 2026 | **BYOK** for OpenAI-compatible providers (incl. Azure) available across CLI and App | Changelog |
