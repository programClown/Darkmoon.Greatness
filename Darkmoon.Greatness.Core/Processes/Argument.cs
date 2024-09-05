using OneOf;

namespace Darkmoon.Greatness.Core.Processes;

[GenerateOneOf]
public partial class Argument : OneOfBase<string, (string, string)>
{
}