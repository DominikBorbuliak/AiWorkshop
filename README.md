# AI Workshop — Fix the Warnings

Welcome to the AI Workshop! Your task is to use an AI coding agent to fix **10 compiler warnings** in a .NET Inventory System — one warning at a time, following a structured cycle.

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Git
- An AI coding agent (e.g. [GitHub Copilot](https://github.com/features/copilot) in agent mode, Cursor, etc.)

---

## Project Overview

This is a simple **Inventory Management Console Application** written in C#. It lets you manage products, categories, discounts, and generate reports.

**Solution structure:**

```
AiWorkshop.Inventory/
  Models/
    Product.cs
    Category.cs
  Services/
    InventoryService.cs
    DiscountCalculator.cs
  Reports/
    InventoryReport.cs
  Program.cs

AiWorkshop.Inventory.Tests/
  InventoryServiceTests.cs
  DiscountCalculatorTests.cs
  InventoryReportTests.cs
```

---

## Your Task

The solution builds successfully but produces **exactly 10 compiler warnings**. Your job is to fix all of them using an AI coding agent.

Run this to see the current warnings:

```bash
dotnet build
```

> **Tip:** If warnings don't appear (due to incremental builds), use `dotnet build --no-incremental` to force a full recompile.

You should see output ending with:

```
Build succeeded with 10 warning(s)
```

---

## The Autonomous AI Cycle

The key idea is that you give the AI agent **one prompt** to kick off the entire workflow, then step back while it works. The AI should:

1. **Create a branch** — `fix/remove-warnings` from `main`
2. **For each warning** (repeat until 0 warnings remain):
   - Run `dotnet build` and identify the next warning in the output
   - Fix that warning (and any duplicate occurrences of the same warning code together)
   - Run `dotnet build` again to confirm the warning is gone
   - Run `dotnet test` to confirm all tests still pass
   - Create a commit following **[Conventional Commits](https://www.conventionalcommits.org/)** format:
     ```
     fix: <WARNING_CODE> <short description of what was fixed and where>
     ```
     Examples:
     ```
     fix: CS8618 initialize non-nullable property 'Name' in Product
     fix: CS0168 remove unused exception variable 'ex' in InventoryService.RemoveProduct
     fix: CS0618 replace obsolete ApplyDiscount call with CalculateDiscount in DiscountCalculator
     ```
3. **Open a Pull Request** from `fix/remove-warnings` to `main` titled **"Fix all compiler warnings in the Inventory System"**

You will end up with **1 branch**, **10 commits** (one per warning), and **1 Pull Request**.

---

## Tips for Reviewing the AI's Work

After the agent finishes, review the Pull Request:

- ✅ Does the PR have exactly 10 commits?
- ✅ Does `dotnet build` now show `0 warnings`?
- ✅ Does `dotnet test` still show all tests passing?
- ✅ Does each commit message clearly state which warning code was fixed?
- ✅ Are the fixes correct — not just suppressed with `#pragma warning disable`?
- ✅ Did the AI understand the *intent* of the code, or did it change behavior?

Good luck! 🚀
