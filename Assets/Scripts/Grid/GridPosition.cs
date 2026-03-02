using System;

public struct GridPosition : IEquatable<GridPosition>
{
    public int x;
    public int z;

    public GridPosition (int x, int z) 
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return $"x:{x}, z:{z}";
    }

    public override bool Equals(object obj)
    {
        if (obj is GridPosition other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public static bool operator ==(GridPosition lhs, GridPosition rhs)
    {
        return (lhs.x == rhs.x) && (lhs.z == rhs.z);
    }

    public static bool operator !=(GridPosition lhs, GridPosition rhs)
    {
        return !(lhs == rhs);
    }
}
