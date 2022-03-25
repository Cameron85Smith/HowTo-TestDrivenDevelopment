# What is Test-Driven Development?

Unit testing is a mechanism which allows us to have a suite of tests that can be automatically run, where the results can be verified automatically as well.

Usually, without a well defined approach to software development, developers can find themselves in the circle of hell. The circle of hell can look like this, in practice:

A developer writes production code and delivers the product, but now there is a bug in production. The developer gets back to the code and fixes the bug. **The developer then writes a unit test to ensure that the bug does not come back**, and like this, the circle of hell repeats itself indefinitely.

It is possible to break this circle, and this comes in the form of Test-Driven Development, also known as TDD.

Test-Driven Development is the approach of writing tests ahead of the production code. In other words, tests drive the production code. The goal is to keep the design well-structured and modular to enable the writing of unit tests. Thus, tests form the shape of the production code.

Unit tests are specifications of what the code should do. When developers write unit tests they only implement the production code that satisfies the unit tests. Otherwise, developers tend to write generalized, and thus, more complex code. TDD helps to avoid all these problems. When you write unit tests first, you can't avoid thinking of how to make the production code more testable, since in the first place, you need to make the unit test pass.

## Red/Green/Refactor

The main technique of TDD is called Red/Green/Refactor. These are short names of repeateable steps.

- **Red** - When writing a unit test, we first make it fail with dummy logic in the valling method. This is known as the Red Phase.

- **Green** - In the second step, we remove the dummy logic where we write the production code that will turn the unit test green. This is known as the Green Phase.

- **Refactor** - In the third step, we refactor our code.

## Laws of TDD

As can be seen, TDD implies that we should write tests before the implementation of a particular feature. There are three very important laws of TDD, that being:

1. Never write a line of production code before writing a failing test.
2. Write a minimal test which is enough to see the failure.
3. Don't write production code more than enough to pass the failing test.

## Design Smells

Turning off a test because you can't fix it right now is symptomatic of a design/code smell.

We need to keep the design as clean as possible, in other words, as maintainable as possible. A design smell can come in the form of:

1. Rigidity - The software is rigid if the cost of making a single change is high. The reason for this can be due to tight-coupling between modules. When modules are tightly coupled, then it is very difficult to introduce changes with ease.

2. Fragility - The software is fragile if small changes in our module causes bugs in another module. The smell is also often caight when there is a tight-coupling between modules.

3. Immobility - Software is immobile when its components can't be reused in other systems. This smell is caused by tight-coupling between components.

4. Viscosity - The software is said to be viscose when adding a single feature evokes dealing with tons of aspects. This is due to tight-coupling as well.

5. Needless Complexity - Software is needlessly complex if developers are trying to forecast the future by introducing excessive points of extension. Adding "not-needed" points of extension is bad practice that leads to needless complexity. Developers should instead focus on current requirements, constructing the supple architecture which can bend to meet new requirements.

## F.I.R.S.T.

Unit tests form the safety net because it helps us to verify the correctness of the system with one-click that will run the whole suite of tests. Therefore, we don't have a fear of introducing changes into the existing code base.

All unit tests we write should run fast. There are five characteristics which define a good unit test.

- Fast - A test should not run for more than 100 milliseconds.
- Independent - Tests should not depend on each other. There should be no ordered tests.
- Repeatable - Tests should produce the same results, no matter how many times you run them.
- Self-Validatable - Tests should either pass or fail.
- In-Time - Tests should be written before production code.

## Types of tests

- Unit Tests - It verifies the behaviour of a unit under test (in isolation).
- Integration Tests - Verifies the behaviour of either a part of a system or a whole system. They are brittle, hard to maintain, and slow.
- Acceptance Tests - Verifies the software from the users point of view.