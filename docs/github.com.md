# GitHub Copilot on GitHub.com — Cloud Agent Demo Guide

> **Target audience:** Developers and reviewers who want to run Copilot cloud agent directly on GitHub.com.
> **Sample project:** This repository (`cautious-octo-fortnight`).
> **Primary source:** [Using Copilot cloud agent on GitHub](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/use-cloud-agent-on-github)

---

## Prerequisites

| Requirement | Notes |
|-------------|-------|
| GitHub Copilot plan | Paid plan required for cloud-agent coding tasks |
| Repository access | Write access to target repository/branch |
| Copilot cloud agent enabled | Must be enabled for the repository/org |

---

## Demo 2 — GitHub.com Cloud Agent (Updated)

**What it shows:** Start Copilot cloud-agent sessions in the browser, assign issues to Copilot, and iterate on pull requests without leaving GitHub.com.

### Option A: Start from Agents tab/panel

1. Open [github.com/copilot/agents](https://github.com/copilot/agents) or open the Agents panel on GitHub.com.
2. In the prompt form, choose the target repository.
3. Enter a task prompt, for example:

	```
	Implement friendlier error messages for common API failures in the Todo API.
	Open a pull request when complete.
	```

4. Optionally select a base branch.
5. Optionally choose a model.
6. Start the task.
7. Monitor session logs and open/create the pull request from the session UI.

### Option B: Assign an issue to Copilot (public preview)

1. Open an issue in the repository.
2. In **Assignees**, select **Copilot**.
3. In the assignment dialog:
	- Add an optional prompt with constraints, testing, and style requirements.
	- Optionally change repository/branch.
	- Optionally choose model.
4. Submit assignment.
5. Copilot creates a branch and opens a pull request, then requests review when finished.

> **Important:** Copilot receives the issue title/body/current comments and your optional prompt at assignment time. If requirements change later, comment on the pull request.

### Option C: Start from Copilot Chat on GitHub.com

1. Open Copilot Chat on GitHub.com.
2. Use `/task` with a PR-oriented request, for example:

	```
	/task Create a pull request that adds pagination to GET /todos with page and pageSize query params.
	```

3. Optionally choose a base branch and model.
4. Start task and monitor progress in session logs.

---

## Iterating After PR Creation

1. Review Copilot's pull request as normal.
2. To request follow-up changes, comment on the PR and mention `@copilot`.
3. Copilot pushes new commits to the PR branch and updates the timeline.

---

## Workflow and Security Notes

1. GitHub Actions workflows do not run automatically by default on Copilot-created PR changes.
2. Use **Approve and run workflows** in the merge box after reviewing changes.
3. Be extra careful with proposed changes under `.github/workflows/`.

---

## Related Docs

- [Starting GitHub Copilot sessions](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/start-copilot-sessions)
- [Managing and tracking agent sessions](https://docs.github.com/en/copilot/how-tos/copilot-on-github/use-copilot-agents/manage-and-track-agents)
- [Troubleshooting Copilot cloud agent](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/cloud-agent/troubleshoot-cloud-agent)

