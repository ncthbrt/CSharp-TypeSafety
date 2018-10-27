using LanguageExt;
using LanguageExt.TypeClasses;
using System;
using System.Diagnostics.Contracts;

namespace Safety
{
  [Serializable]
  public struct Domain<UnderlyingType, Pred>
      where Pred : Pred<UnderlyingType>, new()
  {
    internal static Pred Predicate = new Pred();
    private readonly UnderlyingType _value;
    public UnderlyingType Value => AssertValid(_value);

    private static UnderlyingType AssertValid(UnderlyingType value) =>
        Predicate.True(value)
        ? value
        : throw new ArgumentException($"{value} is not valid");

    public Domain(UnderlyingType value)
    {
      _value = AssertValid(value);
    }

    [Pure]
    public static implicit operator Domain<UnderlyingType, Pred>(Some<UnderlyingType> value) =>
        new Domain<UnderlyingType, Pred>(value);

    [Pure]
    public static implicit operator Domain<UnderlyingType, Pred>(UnderlyingType value) =>
        new Domain<UnderlyingType, Pred>(value);

    [Pure]
    public static implicit operator UnderlyingType(Domain<UnderlyingType, Pred> value) =>
        value.Value;

    public static Option<UnderlyingType> TryCreate(UnderlyingType value)
    {
      return Domain.TryCreate<UnderlyingType, Pred>(value);
    }
  }

  public static class Domain
  {
    public static Option<UnderlyingType> TryCreate<UnderlyingType, Pred>(UnderlyingType value)
        where Pred : Pred<UnderlyingType>, new() =>
            new Pred().True(value)
            ? value
            : Option<UnderlyingType>.None;
  }
}