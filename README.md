# The BODMAS-Engine ⚙️🧮

An industrial-grade String Expression Evaluator and Mathematical Parser built entirely in C# from scratch.

This engine processes complex mathematical strings by implicitly building an **Abstract Syntax Tree (AST)** using **Recursive Descent Parsing**. It completely avoids built-in evaluation scripts (like `DataTable.Compute`), demonstrating a deep understanding of core algorithm logic, operator precedence, and tree-traversal execution under the hood.

## 🧠 Under the Hood (Architecture)

Instead of relying on simple string manipulation, The BODMAS-Engine evaluates math the way a compiler does:

* **Strict Precedence Rules:** Accurately implements BODMAS/PEMDAS by dynamically searching for the weakest operator to serve as the root node of the current sub-tree.
* **Left-Associativity Enforcement:** Utilizes a reverse-traversal algorithm (Right-to-Left loop) to guarantee expressions like `10 - 5 + 2` evaluate correctly to `7` (and not `3`).
* **Depth & Scope Tracking:** Intelligently handles deeply nested brackets `()` by tracking scope depth, preserving sub-expression priority without corrupting the main AST structure.
* **Implicit Multiplication Handling:** Automatically sanitizes input by detecting missing operators and injecting them (e.g., smoothly converting `8(7-9)` into `8*(7-9)` before parsing).
* **Bulletproof Base Cases:** Uses explicit Sentinel Values (e.g., `-1`) to prevent Out-of-Bounds crashes and safely resolve terminal leaf nodes (pure operands).

## 💻 Features
- Supports decimal floating-point arithmetic (`double`).
- Handles basic operators: `+`, `-`, `*`, `/`.
- Robust handling of nested parenthesis.
- Whitespace sanitization.
- Completely dependency-free (pure C# logic).

## 🚀 Getting Started

### Prerequisites
- .NET SDK installed on your machine.
- Visual Studio, VS Code, or any C# IDE.

### Installation & Execution
1. Clone the repository:
   ```bash
   git clone [https://github.com/hashir1881/The-BODMAS-Engine.git](https://github.com/hashir1881/The-BODMAS-Engine.git)
2. Open the project directory.
3. Run the Console Application: `dotnet run`
4. Enter your mathematical expression when prompted by the console!

**📝 Example Usage**

**Input:**
Enter your expression: `2*6/4-6+2*9/8(7-9)`

**Output:**
Cleaned Expression: `2*6/4-6+2*9/8*(7-9)`
Final Answer: `-7.5`


   
