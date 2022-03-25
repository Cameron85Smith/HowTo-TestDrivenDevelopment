# What is Test-Driven Development?

Unit testing is a mechanism which allows us to have a suite of tests that can be automatically run, where the results can be verified automatically as well.

Usually, without a well defined approach to software development, developers can find themselves in the circle of hell. The circle of hell can look like this, in practice:

A developer writes production code and delivers the product, but now there is a bug in production. The developer gets back to the code and fixes the bug. **The developer then writes a unit test to ensure that the bug does not come back**, and like this, the circle of hell repeats itself indefinitely.

It is possible to break this circle, and this comes in the form of Test-Driven Development, also known as TDD.

Test-Driven Development is the approach of writing tests ahead of the production code. In other words, tests drive the production code. The goal is to keep the design well-structured and modular to enable the writing of unit tests. Thus, tests form the shape of the production code.

Unit tests are specifications of what the code should do. When developers write unit tests they only implement the production code that satisfies the unit tests. Otherwise, developers tend to write generalized, and thus, more complex code. TDD helps to avoid all these problems. When you write unit tests first, you can't avoid thinking of how to make the production code more testable, since in the first place, you need to make the unit test pass.

## Red/Green/Refactor

The main technique of TDD is called Red/Green/Refactor. These are short names of repeateable steps.

**Red** - When writing a unit test, we first make it fail with dummy logic in the valling method. This is known as the Red Phase.

**Green** - In the second step, we remove the dummy logic where we write the production code that will turn the unit test green. This is known as the Green Phase.

**Refactor** - In the third step, we refactor our code.