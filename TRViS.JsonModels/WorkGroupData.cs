using System;
using System.Linq;

namespace TRViS.JsonModels;

public class WorkGroupData(
	string Name,
	int? DBVersion,
	WorkData[] Works
) : IEquatable<WorkGroupData>
{
	public string Name { get; } = Name;
	public int? DBVersion { get; } = DBVersion;
	public WorkData[] Works { get; } = Works;

	public override string ToString() =>
		$"{nameof(WorkGroupData)}{{'{Name}', {nameof(DBVersion)}:{DBVersion}, {nameof(Works)}: {Works.Length} works}}";

	public bool Equals(WorkGroupData? other)
	{
		if (other is null)
			return false;
		if (ReferenceEquals(this, other))
			return true;

		return (
			Name == other.Name &&
			DBVersion == other.DBVersion &&
			Works.SequenceEqual(other.Works)
		);
	}

	public override bool Equals(object? obj) => Equals(obj as WorkGroupData);

	public override int GetHashCode() =>
		Name.GetHashCode() ^
		DBVersion.GetHashCode() ^
		Works.GetHashCode();
}
