using NUnit.Framework;
using Pathfinding2D.TopDownView.BlazorGL.Application.TileMap;

namespace Pathfinding2D.TopDownView.BlazorGL.Tests.Application.TileMap;

[TestFixture]
[TestOf(typeof(Cell))]
public class CellTest
{
    [Test]
    public void TestIsWalkableChanged()
    {
        var cell = new Cell(0, 0, false);

        var actionCallCount = 0;
        cell.WalkabilityChanged += () => actionCallCount++;

        Assert.That(actionCallCount, Is.EqualTo(0));
        cell.IsWalkable = false;
        Assert.That(actionCallCount, Is.EqualTo(0));
        cell.IsWalkable = true;
        Assert.That(actionCallCount, Is.EqualTo(1));
        cell.IsWalkable = true;
        Assert.That(actionCallCount, Is.EqualTo(1));
        cell.IsWalkable = false;
        Assert.That(actionCallCount, Is.EqualTo(2));
    }
}