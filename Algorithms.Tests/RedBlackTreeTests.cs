global using FluentAssertions;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Tests;

public class RedBlackTreeTests
{
    readonly ITestOutputHelper output;

    public RedBlackTreeTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void InsertFirstTree_Test()
    {
        var tree = new RedBlackTree<int>();

        // Act
        tree.Insert(5);

        // Assert
        tree.Search(5).Should().NotBeNull();
    }

    [Fact]
    public void InsertSmallerNodes_Test()
    {
        // Arrange
        var tree = new RedBlackTree<int>();

        // Act
        tree.Insert(5);
        tree.Insert(3);

        // Assert
        tree.Root!.Value.Should().Be(5);
        tree.Root!.Left!.Value.Should().Be(3);

        tree.Should().Be(RedBlackTree<int>.Build(
            new(5, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(3),
            }));
    }

    [Fact]
    public void InsertWithRedUncle_Test()
    {
        // Arrange
        var tree = new RedBlackTree<int>();

        // Act
        tree.Insert(20);
        tree.Insert(15);
        tree.Insert(25);
        tree.Insert(10);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Black)
                {
                    Left = new(10, color: RedBlackTree<int>.Color.Red),
                },
                Right = new(25, color: RedBlackTree<int>.Color.Black),
            }
        ));
    }

    [Fact]
    public void InsertWithRedUncle2_Test()
    {
        // Arrange
        var tree = new RedBlackTree<int>();

        // Act
        tree.Insert(20);
        tree.Insert(25);
        tree.Insert(15);
        tree.Insert(23);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Black),
                Right = new(25, color: RedBlackTree<int>.Color.Black)
                {
                    Left = new(23, color: RedBlackTree<int>.Color.Red),
                },
            }
        ));
    }

    [Fact]
    public void InsertLeftLeftCase_Test()
    {
        // Arrange
        var tree = RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Red),
                Right = new(25, color: RedBlackTree<int>.Color.Black),
            }
        );

        // Act
        tree.Insert(10);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(15, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(10, color: RedBlackTree<int>.Color.Red),
                Right = new(20, color: RedBlackTree<int>.Color.Red)
                {
                    Right = new(25, color: RedBlackTree<int>.Color.Black),
                },
            }
        ));
    }

    [Fact]
    public void InsertRightRightCase_Test()
    {
        // Arrange
        var tree = RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Black),
                Right = new(25, color: RedBlackTree<int>.Color.Red),
            }
        );

        // Act
        tree.Insert(30);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(25, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(20, color: RedBlackTree<int>.Color.Red)
                {
                    Left = new(15, color: RedBlackTree<int>.Color.Black)
                },
                Right = new(30, color: RedBlackTree<int>.Color.Red),
            }
        ));
    }

    [Fact]
    public void InsertLeftRightCase_Test()
    {
        // Arrange
        var tree = RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Red),
                Right = new(25, color: RedBlackTree<int>.Color.Black),
            }
        );

        // Act
        tree.Insert(17);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(17, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Red),
                Right = new(20, color: RedBlackTree<int>.Color.Red)
                {
                    Right = new(25, color: RedBlackTree<int>.Color.Black)
                },
            }
        ));
    }

    [Fact]
    public void InsertRightLeftCase_Test()
    {
        // Arrange
        var tree = RedBlackTree<int>.Build(
            new(20, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(15, color: RedBlackTree<int>.Color.Black),
                Right = new(25, color: RedBlackTree<int>.Color.Red),
            }
        );

        // Act
        tree.Insert(23);

        // Assert
        tree.Should().Be(RedBlackTree<int>.Build(
            new(23, color: RedBlackTree<int>.Color.Black)
            {
                Left = new(20, color: RedBlackTree<int>.Color.Red)
                {
                    Left = new(15, color: RedBlackTree<int>.Color.Black)
                },
                Right = new(25, color: RedBlackTree<int>.Color.Red),
            }
        ));
    }

    [Fact]
    public void LargeTreeShouldBeBalanced_Test()
    {
        // Arrange
        var tree = new RedBlackTree<int>();
        var numberOfNodes = 10_000_000;

        // Act
        for (int i = 0; i < numberOfNodes; i++)
        {
            tree.Insert(i);
        }

        // Assert
        tree.Count().Should().Be(numberOfNodes);
        tree.Height().Should().Be((int)Math.Log2(numberOfNodes));
    }
}